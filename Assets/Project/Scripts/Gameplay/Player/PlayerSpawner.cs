using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Project.Gameplay.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;

        [Inject] private DiContainer _diContainer;
        [Inject] private CameraAnchor _cameraAnchor;

        public UnityEvent<Player> playerSpawned;

        private Player _currentPlayer;

        public Player CurrentPlayer => _currentPlayer;

        private void Start()
        {
            var transform1 = transform;
            var player = _diContainer.InstantiatePrefabForComponent<Player>(playerPrefab, transform1.position, transform1.rotation, null);
            var cam = player.GetComponentInChildren<Camera>();
            _cameraAnchor.SetCamera(cam);
            _currentPlayer = player;
            playerSpawned.Invoke(player);
        }
    }
}
using System;
using UnityEngine;
using Zenject;

namespace Project.Gameplay.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;

        [Inject] private DiContainer _diContainer;
        [Inject] private CameraAnchor _cameraAnchor;
        
        private void Start()
        {
            var transform1 = transform;
            var player = _diContainer.InstantiatePrefab(playerPrefab, transform1.position, transform1.rotation, null);
            var cam = player.GetComponentInChildren<Camera>();
            _cameraAnchor.SetCamera(cam);
        }
    }
}
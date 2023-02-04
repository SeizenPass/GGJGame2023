using System;
using Project.Levels;
using Project.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private FirstPersonController fpsController;
        

        [Inject] private HealthUI _healthUI;
        [Inject] private LevelLogic _logic;
        [Inject] private PauseBehaviour _pauseBehaviour;

        private void Start()
        {
            _healthUI.SetMax(health.MaxHealth);
        }

        public void UpdateHealth()
        {
            _healthUI.SetCurrent(health.CurrentHealth);
        }

        public void MarkDead()
        {
            _logic.MarkPlayerDead();
        }

        private void OnPause(InputValue value)
        {
            _pauseBehaviour.PauseToggle();
        }

        private void OnEnable()
        {
            _pauseBehaviour.onPauseChanged.AddListener(HandlePause);
        }

        private void OnDisable()
        {
            _pauseBehaviour.onPauseChanged.RemoveListener(HandlePause);
        }

        private void HandlePause(bool pause)
        {
            fpsController.enabled = !pause;
        }
    }
}
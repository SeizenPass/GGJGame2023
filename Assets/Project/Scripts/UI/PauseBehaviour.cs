using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Project.UI
{
    public class PauseBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject pauseScreen;

        private bool _pause;

        public bool Pause => _pause;

        public UnityEvent<bool> onPauseChanged;

        public void PauseToggle()
        {
            _pause = !_pause;
            onPauseChanged.Invoke(_pause);
            HandlePause();
        }

        private void HandlePause()
        {
            if (_pause)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        public void ForcePause()
        {
            _pause = true;
            onPauseChanged.Invoke(_pause);
            HandlePause();
        }

        private void OnDestroy()
        {
            _pause = false;
            onPauseChanged.Invoke(_pause);
            HandlePause();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
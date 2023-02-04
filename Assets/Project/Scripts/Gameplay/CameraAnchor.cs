using UnityEngine;
using UnityEngine.Events;

namespace Project.Gameplay
{
    public class CameraAnchor : MonoBehaviour
    {
        private Camera _currentCamera;

        public Camera CurrentCamera => _currentCamera;

        public UnityEvent<Camera> onCameraChanged;

        public void SetCamera(Camera targetCamera)
        {
            if (!targetCamera)
            {
                Debug.LogWarning("No camera provided.");
                return;
            }

            _currentCamera = targetCamera;
            onCameraChanged.Invoke(_currentCamera);
        }

        private void Start()
        {
            SetCamera(Camera.main);
        }
    }
}
using UnityEngine;
using Zenject;

namespace Project.Gameplay
{
    public class SpriteBillboard : MonoBehaviour
    {
        [Inject] private CameraAnchor _cameraAnchor;

        private Camera _targetCamera;
        private void Start()
        {
            _targetCamera = _cameraAnchor.CurrentCamera;
        }

        private void OnEnable()
        {
            _cameraAnchor.onCameraChanged.AddListener(OnCameraChange);
        }

        private void OnDisable()
        {
            _cameraAnchor.onCameraChanged.RemoveListener(OnCameraChange);
        }

        private void OnCameraChange(Camera targetCamera)
        {
            _targetCamera = targetCamera;
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(0f, _targetCamera.transform.rotation.eulerAngles.y, 0f);
        }
    }
}
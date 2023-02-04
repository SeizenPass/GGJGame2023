using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.LevelSelector
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float zoomAmount = 1;
        [SerializeField] private Camera gameCamera;

        private Transform _cameraTransform;
        private Vector2 _dir;
        
        private void Start()
        {
            _cameraTransform = gameCamera.transform;
        }

        private void Update()
        {
            var pos = _cameraTransform.position;
            pos.x += _dir.x * speed * Time.deltaTime;
            pos.y += _dir.y * speed * Time.deltaTime;
            _cameraTransform.position = pos;
        }


        public void OnMove(InputValue value)
        {
            _dir = value.Get<Vector2>();
        }

        public void Zoom()
        {
            gameCamera.orthographicSize -= zoomAmount;
            if (gameCamera.orthographicSize < 1) gameCamera.orthographicSize = 1;
        }
        
        public void UnZoom()
        {
            gameCamera.orthographicSize += zoomAmount;
        }
    }
}
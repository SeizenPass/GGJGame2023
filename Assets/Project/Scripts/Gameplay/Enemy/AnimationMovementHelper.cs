using System;
using UnityEngine;

namespace Project.Gameplay.Enemy
{
    public class AnimationMovementHelper : MonoBehaviour
    {
        private Vector3 _cached;
        [SerializeField] private Animator animator;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Start()
        {
            _cached = transform.position;
        }

        private void Update()
        {
            var position = transform.position;
            var speed = Mathf.Abs(Vector3.Distance(position, _cached)) / Time.deltaTime;
            animator.SetFloat(Speed, speed);
            _cached = position;
        }
    }
}
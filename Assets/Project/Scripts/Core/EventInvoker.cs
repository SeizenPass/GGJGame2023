using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Core
{
    public class EventInvoker : MonoBehaviour
    {
        public UnityEvent onAwake, onStart, onDestroy, onEnable, onDisable;

        private void Awake()
        {
            onAwake.Invoke();
        }

        private void Start()
        {
            onStart.Invoke();
        }

        private void OnDestroy()
        {
            onDestroy.Invoke();
        }

        private void OnEnable()
        {
            onEnable.Invoke();
        }

        private void OnDisable()
        {
            onDisable.Invoke();
        }
    }
}
using System;
using Project.Levels;
using UnityEngine;
using Zenject;

namespace Project.Gameplay.Enemy
{
    public class EnemyLevelCommunicator : MonoBehaviour
    {
        [Inject] private LevelLogic _logic;

        private void Start()
        {
            Increment();
        }

        public void Increment()
        {
            _logic.Increment();
        }

        public void Decrement()
        {
            _logic.Decrement();
        }
    }
}
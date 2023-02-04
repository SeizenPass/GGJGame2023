using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Project.Levels
{
    public class LevelLogic : MonoBehaviour
    {
        public UnityEvent onWin, onLose;

        private int _currentNumberOfEnemies;
        private bool _changeCalled;

        [Inject] private LevelManager _levelManager;

        public void Increment()
        {
            _currentNumberOfEnemies++;
        }
        
        public void Decrement()
        {
            _currentNumberOfEnemies--;
            if (_currentNumberOfEnemies <= 0)
            {
                if (!_changeCalled)
                {
                    _changeCalled = true;
                    onWin.Invoke();
                }
            }
        }

        public void MarkPlayerDead()
        {
            if (!_changeCalled)
            {
                _changeCalled = true;
                onLose.Invoke();
            }
        }

        public void Restart()
        {
            _levelManager.PlayCurrentLevel();
        }
    }
}
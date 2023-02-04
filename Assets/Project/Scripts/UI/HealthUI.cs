using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image onScreenOverlay;

        private float _maxValue, _currentValue;

        [Range(0, 255)] 
        [SerializeField]
        private int maximumOpacity ;

        public void SetMax(float max)
        {
            _maxValue = max;
        }

        public void SetCurrent(float current)
        {
            _currentValue = current;
            var color = onScreenOverlay.color;
            color.a = (1 - _currentValue / _maxValue) * (maximumOpacity / 255f);
            onScreenOverlay.color = color;
        }
    }
}
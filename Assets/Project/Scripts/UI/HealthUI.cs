using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image onScreenOverlay, damageOverlay;
        [SerializeField] private Color damageColor;

        private Color _initColor;
        
        private float _maxValue, _currentValue;

        private void Start()
        {
            _initColor = damageOverlay.color;
        }

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

        public void DamageOverlay()
        {
            if (_damageTween != null) KillTween();
            damageOverlay.color = damageColor;
            _damageTween = DOTween.To(() => damageOverlay.color, x => damageOverlay.color = x,
                _initColor, 0.3f);
        }

        private Tween _damageTween;

        private void KillTween()
        {
            damageOverlay.color = _initColor;
            _damageTween.Kill();
            _damageTween = null;
        }

        private void OnDestroy()
        {
            KillTween();
        }
    }
}
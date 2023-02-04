using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Enemy
{
    public class EnemyVisualHelper : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float bleedTime;
        [SerializeField] private Color damageColor;

        private Tween _curTween;

        public void Bleed()
        {
            spriteRenderer.color = damageColor;
            if (_curTween != null) _curTween.Kill();
            _curTween = DOTween.To(() => spriteRenderer.color, x => spriteRenderer.color = x, Color.white, bleedTime);
        }

        private IEnumerator WaitAndExecute(Action call, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            
            call?.Invoke();
        }

        private void OnDestroy()
        {
            _curTween.Kill();
        }
    }
}
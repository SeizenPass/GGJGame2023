using System.Collections;
using Project.Utils;
using UnityEngine;

namespace Project.Gameplay.Enemy
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 1, damage = 1, lifetime = 5, damageRadius = 5;
        [SerializeField] private LayerMask targetLayerMask, collisionLayerMask;

        private bool _activated;
        private Vector3 _direction;
        
        public void Shoot(Vector3 direction)
        {
            _activated = true;
            _direction = direction;
            StartCoroutine(Lifetime());
        }

        private void Update()
        {
            if (!_activated) return;
            transform.position += _direction * speed * Time.deltaTime;
        }

        private IEnumerator Lifetime()
        {
            yield return new WaitForSeconds(lifetime);
            
            Explode();
        }

        private void OnTriggerEnter(Collider other)
        {
            LayerMask l = other.gameObject.layer;
            if (!LayerMaskUtils.CompareLayers(collisionLayerMask, l)) return;
            StopCoroutine(Lifetime());
            Explode();
        }

        private void Explode()
        {
            var targets = Physics.OverlapSphere(transform.position,
                damageRadius, targetLayerMask);
            if (targets.Length > 0)
            {
                foreach (var ta in targets)
                {
                    if (ta.TryGetComponent<Health>(out var h))
                    {
                        h.Damage(damage);
                    }
                }
            }
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, damageRadius);
        }
    }
}
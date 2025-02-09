﻿using Project.Gameplay.Player;
using Project.Zone;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Project.Gameplay.Enemy
{
    public class ShootingEnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private ZoneChecker playerLookupZone;
        [SerializeField] private LayerMask targetLayerMask;
        

        [Header("Combat")] 
        [SerializeField] 
        private Projectile projectilePrefab;
        [SerializeField] 
        private Transform projectileSpawnPoint;
        [SerializeField] private float cooldown = 5;
        [SerializeField] private float attackRange = 5;
        [SerializeField] private bool hasAttackAnimation;
        
        


        private float _lastAttackTime;

        [Inject] private DiContainer _diContainer;
        [Inject] private PlayerSpawner _playerSpawner;
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");

        private void Update()
        {
            if (!_playerSpawner.CurrentPlayer) return;
            if (_lastAttackTime + cooldown > Time.time) return;
            if (CheckPlayerAttackRange())
            {
                Stop();
                Attack();
                return;
            }
            if (playerLookupZone.Check(targetLayerMask))
            {
                ChasePlayer();
            }
        }

        private void ChasePlayer()
        {
            navMeshAgent.SetDestination(_playerSpawner.CurrentPlayer.transform.position);
        }

        private void Attack()
        {
            _lastAttackTime = Time.time;
            var spawnPoint = projectileSpawnPoint.position;
            var dir = (_playerSpawner.CurrentPlayer.transform.position - 
                       spawnPoint).normalized;
            var p = _diContainer.InstantiatePrefabForComponent<Projectile>(projectilePrefab,
                spawnPoint, projectilePrefab.transform.rotation, null);
            p.Shoot(dir);
            if (hasAttackAnimation)
            {
                animator.SetTrigger(AttackTrigger);
            }
        }
        
        private void Stop()
        {
            navMeshAgent.SetDestination(transform.position);
        }

        private bool CheckPlayerAttackRange()
        {
            var transform1 = projectileSpawnPoint;
            return Physics.Raycast(transform1.position,
                transform1.forward, out _, attackRange, targetLayerMask);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            var transform1 = projectileSpawnPoint;
            var position = transform1.position;
            Gizmos.DrawLine(position, position + transform1.forward * attackRange);
        }
    }
}
using Project.Gameplay.Player;
using Project.Zone;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Project.Gameplay.Enemy
{
    public class MeleeEnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private ZoneChecker playerLookupZone;
        [SerializeField] private LayerMask targetLayerMask;
        

        [Header("Combat")] 
        [SerializeField] 
        private Transform attackPoint;

        [SerializeField] private float damage;
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
            if (_lastAttackTime + cooldown < Time.time && CheckPlayerAttackRange())
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

        private void Stop()
        {
            navMeshAgent.SetDestination(transform.position);
        }

        private void Attack()
        {
            _lastAttackTime = Time.time;
            if (hasAttackAnimation)
            {
                animator.SetTrigger(AttackTrigger);
            }
        }

        private bool CheckPlayerAttackRange()
        {
            return Physics.CheckSphere(attackPoint.position, attackRange, targetLayerMask);
        }

        public void ExecuteDamaging()
        {
            if (CheckPlayerAttackRange())
            {
                if (_playerSpawner.CurrentPlayer.TryGetComponent<Health>(out var h))
                {
                    h.Damage(damage);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            if (!attackPoint) return;
            var transform1 = attackPoint;
            var position = transform1.position;
            Gizmos.DrawWireSphere(position, attackRange);
        }
    }
}
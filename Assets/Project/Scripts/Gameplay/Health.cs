using UnityEngine;
using UnityEngine.Events;

namespace Project.Gameplay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        public float MaxHealth => maxHealth;

        [Header("Events")] 
        public UnityEvent onDamageReceived;
        public UnityEvent onDeath;
        public UnityEvent onUpdated;

        private float _currentHealth;

        public float CurrentHealth => _currentHealth;

        public bool IsDead => _currentHealth <= 0;
        public bool IsFull => _currentHealth >= maxHealth;

        public float CurrentPercent => _currentHealth / maxHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
            onUpdated.Invoke();
        }

        public void Damage(float amount)
        {
            if (_currentHealth <= 0) return;
            _currentHealth -= amount;
            if (_currentHealth < 0) _currentHealth = 0;
            onUpdated.Invoke();
            onDamageReceived.Invoke();
            if (_currentHealth == 0) onDeath.Invoke();
        }

        public void Heal(float amount)
        {
            _currentHealth += amount;
            if (_currentHealth > maxHealth) _currentHealth = maxHealth;
            onUpdated.Invoke();
        }
    }

}
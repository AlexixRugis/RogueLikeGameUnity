using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Weapons;

namespace ARTEX.Rogue.Stats
{
    [System.Serializable]
    public class EntityInfo
    {
        [SerializeField] private Stat health;
        [SerializeField] private Stat protection;
        [SerializeField] private Stat damage;

        private int currentHealth;

        public int Health => currentHealth;
        public Stat MaxHealth => health;
        public Stat Protection => protection;
        public Stat Damage => damage;

        public delegate void OnDie();
        public event OnDie OnDieEvent;

        public delegate void OnHealthChanged(int health, int maxHealth);
        public event OnHealthChanged OnHealthChangedEvent;

        public void Initialize()
        {
            currentHealth = health.Value;
        }

        public void TakeDamage(int amount)
        {
            amount = Mathf.Clamp(amount - protection.Value, Mathf.CeilToInt((float)amount * 0.2f), amount);
            currentHealth -= amount;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                OnDieEvent?.Invoke();
            }
            OnHealthChangedEvent?.Invoke(currentHealth, MaxHealth.Value);
        }

        public void Heal(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, health.Value);
            OnHealthChangedEvent?.Invoke(currentHealth, MaxHealth.Value);
        }
    }
}
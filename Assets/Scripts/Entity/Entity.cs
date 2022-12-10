using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Stats;
using ARTEX.Rogue.Popups;
using UnityEngine.Events;

namespace ARTEX.Rogue.Entities
{
    public abstract class Entity : MonoBehaviour, IDamagable
    {
        [System.Serializable]
        public class EntityDieEvent : UnityEvent<Entity> { }

        [System.Serializable]
        public class Stage
        {
            [Range(0, 1)]
            [SerializeField] private float minHealthNormalized;
            public float MinHealthNormalized => minHealthNormalized;
            public UnityEvent OnStageEnter;
        }

        [SerializeField] protected EntityInfo stats;
        [SerializeField] protected bool isImmortal;
        [SerializeField] protected List<Stage> stages;
        protected int currentStage = -1;

        public EntityInfo Stats => stats;
        public EntityDieEvent OnDieEvent = new EntityDieEvent();

        public bool IsImmortal
        {
            get { return isImmortal; }
            set { isImmortal = value; }
        }

        protected virtual void Awake()
        {
            stats.Initialize();
        }

        protected virtual void OnEnable()
        {
            Stats.OnDieEvent += Die;
            Stats.OnHealthChangedEvent += HandleHealthChanging;
        }

        protected virtual void OnDisable()
        {
            Stats.OnDieEvent -= Die;
            Stats.OnHealthChangedEvent -= HandleHealthChanging;
        }

        protected virtual void Die()
        {
            OnDieEvent?.Invoke(this);
        }

        protected virtual void HandleHealthChanging(int health, int maxHealth)
        {
            float healthNormalized = (float)health / maxHealth;

            for (int i = 0; i < stages.Count; i++)
            {
                if(healthNormalized < stages[i].MinHealthNormalized && i > currentStage)
                {
                    currentStage = i;
                    stages[i].OnStageEnter?.Invoke();
                }
            }

        }

        public void TakeDamage(int amount)
        {
            if (isImmortal) return;

            PopupManager.MakePopupInArea(transform.position, 1f, amount.ToString(), Color.red);
            Stats.TakeDamage(amount);
        }
    }
}
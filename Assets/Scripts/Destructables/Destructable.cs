using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ARTEX.Rogue.Entities
{
    public class Destructable : MonoBehaviour, IDamagable
    {
        [SerializeField] private int health;
        public UnityEvent OnDestruct;

        public void TakeDamage(int amount)
        {
            health -= amount;
            if(health <= 0)
            {
                Destruct();
            } 
        }

        protected virtual void Destruct()
        {
            OnDestruct?.Invoke();
        }
    }
}
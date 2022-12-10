using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float cooldownTime;
        [SerializeField] protected int damage;

        public delegate void OnCooldownUpdate(float cooldownNormalized);
        public OnCooldownUpdate OnCooldownUpdateEvent;

        protected bool isReloading;
        protected float cooldownTimer;

        protected virtual void Awake()
        {
            isReloading = false;
            cooldownTimer = 0;
        }

        protected virtual void Update()
        {
            if (isReloading)
            {
                if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
                else isReloading = false;

                OnCooldownUpdateEvent?.Invoke(cooldownTimer / cooldownTime);
            }
        }

        public virtual void Attack()
        {
            if (isReloading) return;
            isReloading = true;
            cooldownTimer = cooldownTime;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Player;
using ARTEX.Rogue.Enemies;

namespace ARTEX.Rogue.Weapons
{
    public class ShootingWeapon : Weapon
    {
        protected enum DamagableType
        {
            Player,
            Enemy
        }

        [SerializeField] protected DamagableType damagableType;

        [SerializeField] protected Vector3 shootOffset;

        [SerializeField] protected BasicMagazine magazine;

        [SerializeField] protected AudioClip shootSound;
        protected AudioSource audioSource;

        protected Vector3 shootPoint => transform.TransformPoint(shootOffset);
        protected Vector3 shootDirection => transform.right*transform.lossyScale.x;
        protected float shootAngle => Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        protected override void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public override void Attack()
        {
            if (isReloading) return;
            base.Attack();

            Shoot();
        }

        protected virtual void Shoot()
        {
            Projectile projectile = ProjectileManager.ShootProjectile(magazine.GetProjectileType(), damage, shootPoint, shootDirection, CheckDamagable);
            audioSource?.PlayOneShot(shootSound);
        }

        protected bool CheckDamagable(IDamagable damagable)
        {
            switch(damagableType)
            {
                case DamagableType.Enemy:
                    return damagable is Enemy && !(damagable is Player.Player);
                case DamagableType.Player:
                    return damagable is Player.Player && !(damagable is Enemy);
                default:
                    return true;
            }
        }

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(shootPoint, 0.1f);
            Gizmos.DrawLine(shootPoint, shootPoint + shootDirection);
        }


    }
}
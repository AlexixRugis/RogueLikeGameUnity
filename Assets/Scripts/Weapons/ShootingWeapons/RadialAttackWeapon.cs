using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    public class RadialAttackWeapon : ShootingWeapon
    {
        [SerializeField] private float shootingAngle;
        [SerializeField] private float betweenTime;
        [SerializeField] private int projectileCount;

        protected override void Shoot()
        {
            StartCoroutine(ShootRoutine());
        }

        private IEnumerator ShootRoutine()
        {
            float halfShootingAngle = shootingAngle / 2;

            for (float i = -halfShootingAngle; i < halfShootingAngle; i += shootingAngle / projectileCount)
            {
                float angle = shootAngle + i;

                Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

                Projectile projectile = ProjectileManager.ShootProjectile(magazine.GetProjectileType(), damage, shootPoint, direction, CheckDamagable);

                if (betweenTime > 0)
                {
                    audioSource?.PlayOneShot(shootSound);
                    yield return new WaitForSeconds(betweenTime);
                }
            }
            if(betweenTime == 0) audioSource?.PlayOneShot(shootSound);

            yield return null;
        }
    }
}
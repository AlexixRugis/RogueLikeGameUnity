using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons {
    public class ProjectileManager : MonoBehaviour
    {
        private const string PROJECTILE_PREFAB_PATH = "Prefabs/Projectiles/Projectile";

        private static Projectile prefab;
        public static Projectile ShootProjectile(ProjectileInfo info, int damage, Vector3 position, Vector3 direction, Projectile.CanTakeDamage damagableChecker)
        {
            if (!prefab) prefab = Resources.Load<Projectile>(PROJECTILE_PREFAB_PATH);

            Projectile projectile = Instantiate(prefab);
            projectile.Initialize(info, damage, position, direction, damagableChecker);
            return projectile;
        }
    }
}
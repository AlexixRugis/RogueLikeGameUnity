using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    [System.Serializable]
    public class BasicMagazine : Magazine
    {
        [SerializeField] private ProjectileInfo projectileType;
        public override ProjectileInfo GetProjectileType()
        {
            return projectileType;
        }
    }
}
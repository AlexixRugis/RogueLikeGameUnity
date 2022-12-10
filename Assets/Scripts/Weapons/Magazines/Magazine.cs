using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    [System.Serializable]
    public class Magazine
    {
        public virtual ProjectileInfo GetProjectileType() { return null; }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    [CreateAssetMenu(fileName = "new ProjectileInfo", menuName = "Weapons/Projectile")]
    public class ProjectileInfo : ScriptableObject
    {
        public enum ProjectileType { AgainstPlayer, AgainstEnemy }

        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _speed;

        public Sprite Sprite => _sprite;
        public float Speed => _speed;
    }
}

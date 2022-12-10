using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Enemies.Waves
{
    [System.Serializable]
    public struct EnemyWave
    {
        [SerializeField] private List<Enemy> enemies;
        public List<Enemy> Enemies => enemies;
    }
}
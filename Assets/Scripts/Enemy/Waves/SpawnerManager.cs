using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Enemies.Spawners
{
    public class SpawnerManager : MonoBehaviour
    {
        private static SpawnerManager instance;

        [SerializeField] private Spawner spawnerPrebab;

        private void Awake()
        {
            if (instance != null) throw new System.Exception($"{GetType()}: Singleton error!");
            instance = this;
        }

        public static T Spawn<T>(T spawnObject, Vector3 position, float duration = 3f) where T : MonoBehaviour
        {
            Spawner spawner = Instantiate(instance.spawnerPrebab, position, Quaternion.identity);
            return spawner.Initialize(spawnObject, duration);
        }
    }
}
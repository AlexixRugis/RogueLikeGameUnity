using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Enemies.Spawners;
using ARTEX.Rogue.Entities;
using UnityEngine.Events;

namespace ARTEX.Rogue.Enemies.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private bool runOnStart;
        [SerializeField] private Vector2 spawnZoneSize;
        [SerializeField] private float waveSpawnTime;
        [SerializeField] private List<EnemyWave> waves;
        [SerializeField] private LayerMask spawnPointCheckMask;
        [SerializeField] private float spawnPointCheckRadius;

        public UnityEvent OnFinalEvent;

        private List<Entity> entities;
        private bool canContinue;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector3(spawnZoneSize.x, spawnZoneSize.y, 1));
        }

        private void Awake()
        {
            entities = new List<Entity>();
        }

        private void Start()
        {
            if (runOnStart) Run();
        }

        public void Run()
        {
            StartCoroutine(WaveRoutine());
        }

        private IEnumerator WaveRoutine()
        {
            foreach(var wave in waves)
            {
                foreach(var enemy in wave.Enemies)
                {
                    while (true)
                    {
                        Vector3 position;
                        if(GetPosition(out position))
                        {
                            Enemy spawned = SpawnerManager.Spawn(enemy, position, waveSpawnTime);
                            entities.Add(spawned);
                            spawned.OnDieEvent.AddListener(EnemyDieHandler);
                            break;
                        }
                        yield return null;
                    }
                }

                canContinue = false;
                yield return new WaitUntil(() => canContinue);
            }
            OnFinalEvent?.Invoke();
        }

        private bool GetPosition(out Vector3 position)
        {
            Vector2 halfZoneSize = spawnZoneSize / 2;

            position = transform.position + new Vector3(Random.Range(-halfZoneSize.x, halfZoneSize.x), Random.Range(-halfZoneSize.y, halfZoneSize.y), 0);
            return IsPositionReachable(position);
        }

        private void EnemyDieHandler(Entity entity)
        {
            entity.OnDieEvent.RemoveListener(EnemyDieHandler);
            entities.RemoveAll(x => x == entity || x == null);
            
            if(entities.Count == 0)
            {
                canContinue = true;
            }
        }

        private bool IsPositionReachable(Vector3 position)
        {
            return !Physics2D.OverlapCircle(position, spawnPointCheckRadius, spawnPointCheckMask);
        }
    }
}
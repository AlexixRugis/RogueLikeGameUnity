using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Enemies.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [Header("Highlight")]
        [SerializeField] private Transform highlight;
        [SerializeField] private float rotationSpeed;

        private bool isEnding = false;

        public T Initialize<T>(T spawnObject, float duration) where T : MonoBehaviour
        {
            T spawned = Instantiate(spawnObject, transform.position, Quaternion.identity);
            spawned.gameObject.SetActive(false);
            StartCoroutine(SpawnRoutine(spawned.gameObject, duration));
            return spawned;
        }

        private void Update()
        {
            HandleHightlight();
        }

        private void HandleHightlight()
        {
            highlight.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            if(isEnding)
            {
                transform.localScale = Vector3.Slerp(transform.localScale, Vector3.zero, Time.deltaTime * 10);
            }
        }

        private IEnumerator SpawnRoutine(GameObject spawned, float duration)
        {
            yield return new WaitForSeconds(duration);
            spawned.SetActive(true);
            isEnding = true;
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }

}
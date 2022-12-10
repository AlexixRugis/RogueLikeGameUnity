using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Spikes
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] private GameObject spikesRoot;

        private void Start()
        {
            StartCoroutine(SpikeRoutine());
        }

        private IEnumerator SpikeRoutine()
        {
            while(true)
            {
                spikesRoot.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                spikesRoot.SetActive(false);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
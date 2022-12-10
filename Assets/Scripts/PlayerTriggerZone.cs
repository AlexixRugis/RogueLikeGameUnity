using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ARTEX.Rogue.Player;

namespace ARTEX.Rogue.TriggerZones
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerTriggerZone : MonoBehaviour
    {
        [SerializeField] private bool destroyOnEnter;

        public UnityEvent OnPlayerEnter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<Player.Player>())
            {
                OnPlayerEnter?.Invoke();
                if (destroyOnEnter) Destroy(gameObject);
            }
        }
    }
}
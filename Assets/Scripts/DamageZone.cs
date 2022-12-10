using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.TriggerZones
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();

            if(damagable != null)
            {
                damagable.TakeDamage(damage);
            }
        }
    }
}
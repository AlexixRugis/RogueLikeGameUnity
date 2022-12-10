using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Player;

namespace ARTEX.Rogue.Heals
{
    [RequireComponent(typeof(Collider2D))]
    public class Heal : MonoBehaviour
    {
        [SerializeField] int amount;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();
            
            if(player)
            {
                player.Stats.Heal(amount);
                Destroy(gameObject);
            }
        }
    }
}
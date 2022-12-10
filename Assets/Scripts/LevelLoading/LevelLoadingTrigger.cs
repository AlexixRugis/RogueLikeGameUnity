using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Player;

namespace ARTEX.Rogue.LevelManagement
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelLoadingTrigger : MonoBehaviour
    {
        [SerializeField] private string targetLevel;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();

            if (player) LevelManager.LoadLevel(targetLevel);
        }
    }
}
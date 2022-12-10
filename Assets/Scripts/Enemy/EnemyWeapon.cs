using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Weapons;
using ARTEX.Rogue.Player;

namespace ARTEX.Rogue.Enemies
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponHolder holder;

        private Transform player;

        private bool isTargeting;
        public bool IsTargeting { 
            get { return isTargeting; }
            set { 
                if (value && player) HandleTargeting();
                isTargeting = value;
            } 
        }

        private void Awake()
        {
            IsTargeting = false;
        }

        private void Start()
        {
            player = PlayerManager.Instance.Player.transform;
        }

        private void Update()
        {
            if (IsTargeting && player)
                HandleTargeting();
        }

        private void HandleTargeting()
        {
            holder.SetDirectionTo(player.position);
        }

        public void Shoot()
        {
            holder.Weapon.Attack();
        }
    }
}

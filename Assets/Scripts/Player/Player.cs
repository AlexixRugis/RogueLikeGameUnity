using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Entities;
using ARTEX.Rogue.LevelManagement;

namespace ARTEX.Rogue.Player
{
    [RequireComponent(typeof(EntityMovementRigidbody))]
    [RequireComponent(typeof(PlayerWeapon))]
    public class Player : Entity
    {
        private EntityMovementRigidbody movement;
        protected override void Awake()
        {
            base.Awake();
            movement = GetComponent<EntityMovementRigidbody>();
        }

        protected override void Die()
        {
            LevelManager.OnPlayerDied();
        }
    }
}
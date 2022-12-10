using ARTEX.Rogue.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Player
{
    public class PlayerMovement : EntityMovementRigidbody
    {
        [SerializeField] private float speed;

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            Move(input, speed);
        }
    }
}
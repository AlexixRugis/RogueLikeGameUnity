using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Weapons;

namespace ARTEX.Rogue.Player {
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponHolder holder;

        private void Update()
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            holder.SetDirectionTo(worldPosition);

            if(Input.GetMouseButtonDown(0))
            {
                //Shoot
                holder.Weapon.Attack();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        private Weapon[] weapons;
        private int selectedWeapon;

        public Weapon[] Weapons => weapons;

        private void Awake()
        {
            InitializeWeapons();
            selectedWeapon = 0;
            SetWeapon(0); 
        }


        public void InitializeWeapons()
        {
            weapons = GetComponentsInChildren<Weapon>();
            foreach(var weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
        }

        public void SetWeapon(int index)
        {
            if (index < 0 || index >= weapons.Length) throw new System.IndexOutOfRangeException();

            this.Weapon.gameObject.SetActive(false);
            selectedWeapon = index;
            this.Weapon.gameObject.SetActive(true);
        }

        public void SetDirectionTo(Vector3 to)
        {
            var angle = Vector2.Angle(Vector2.up, to - transform.position);
            angle *= Mathf.Sign(transform.position.x - to.x);
            if (angle > 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                transform.eulerAngles = new Vector3(0, 0, angle - 90);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.eulerAngles = new Vector3(0, 0, angle + 90);
            }
        }

        public Weapon Weapon => weapons[selectedWeapon];
    }
}
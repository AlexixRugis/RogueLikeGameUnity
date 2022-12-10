using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Stats
{
    [System.Serializable]
    public struct Stat
    {
        [SerializeField] private int baseValue;

        private int modifier;

        public int Value => Mathf.Clamp(baseValue + modifier, 0, baseValue + modifier);

        public Stat(int baseValue)
        {
            this.baseValue = baseValue;
            modifier = 0;
        }

        public void AddModifier(int modifier)
        {
            this.modifier += modifier;
        }

        public void RemoveModifier(int modifier)
        {
            this.modifier -= modifier;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Popups;

namespace ARTEX.Rogue
{
    public interface IDamagable
    {
        void TakeDamage(int amount);
    }
}
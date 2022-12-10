using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.LevelManagement;

namespace ARTEX.Rogue.Menus
{
    public class Menu : MonoBehaviour
    {
        public void Play()
        {
            LevelManager.LoadLevel("level1");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
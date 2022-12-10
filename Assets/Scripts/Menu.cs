using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.LevelManagement;

namespace ARTEX.Rogue.Menus
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private string _gameSceneName = "";
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _aboutPanel;
        public void Play()
        {
            LevelManager.LoadLevel(_gameSceneName);
        }

        public void OpenSettingsMenu()
        {
            _settingsPanel.SetActive(true);
        }
        public void OpenAboutPanel()
        {
            _aboutPanel.SetActive(true);
        }

        public void ClosePanels()
        {
            _settingsPanel.SetActive(false);
            _aboutPanel.SetActive(false);
        }


        public void Quit()
        {
            Application.Quit();
        }
    }
}
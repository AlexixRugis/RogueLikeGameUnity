using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARTEX.Rogue.LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        private const string StartLevel = "level1";
        private const string LoadingLevel = "LevelLoadingScreen";

        private static int lifeCount = 3;
        public static int LifeCount => lifeCount;
        public static string TargetLevelName { get; private set; }
        public static string TargetLevelDescription { get; private set; }

        private static void Initialize()
        {
            lifeCount = 3;
        }

        public static void LoadLevel(string levelName)
        {
            TargetLevelDescription = LifeCount <= 0 ? "Вы проиграли! Запуск сначала.." : "Загрузка уровня...";
            TargetLevelName = levelName;
            SceneManager.LoadScene(LoadingLevel);
        }

        public static void OnPlayerDied()
        {
            lifeCount -= 1;

            if(LifeCount <= 0)
            {
                LoadLevel(StartLevel);
                Initialize();
            } 
            else
            {
                LoadLevel(SceneManager.GetActiveScene().name);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ARTEX.Rogue.LevelManagement
{
    public class LevelLoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lifeCountText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Image loadingBar;

        private AsyncOperation sceneLoading;

        private void Awake()
        {
            sceneLoading = null;
            StartCoroutine(LoadRoutine());
        }

        private void Update()
        {
            if (sceneLoading != null) loadingBar.fillAmount = sceneLoading.progress;
        }

        private IEnumerator LoadRoutine()
        {
            lifeCountText.text = $"Осталось жизней: {LevelManager.LifeCount}";
            descriptionText.text = LevelManager.TargetLevelDescription;
            yield return new WaitForSeconds(1.5f);
            sceneLoading = SceneManager.LoadSceneAsync(LevelManager.TargetLevelName);
            sceneLoading.allowSceneActivation = true;
        }
        
    }
}
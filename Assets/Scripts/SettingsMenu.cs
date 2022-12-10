using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace ARTEX.Rogue.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixer musicMixer;
        [SerializeField] private AudioMixer soundMixer;
        [SerializeField] private TMP_Dropdown qualityDropdown;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        public void SetQuality(int qualityIndex)
        {
            PlayerPrefs.SetInt("Quality", qualityIndex);
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetMusicVolume(float volume)
        {
            PlayerPrefs.SetFloat("MusicVolume", volume);
            musicMixer.SetFloat("Volume", volume);
        }

        public void SetSoundVolume(float volume)
        {
            PlayerPrefs.SetFloat("SoundVolume", volume);
            soundMixer.SetFloat("Volume", volume);
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey("Quality"))
            {
                int value = PlayerPrefs.GetInt("Quality");
                QualitySettings.SetQualityLevel(value);
                qualityDropdown.SetValueWithoutNotify(value);
            }
            else
            {
                qualityDropdown.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
            }

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                float value = PlayerPrefs.GetFloat("MusicVolume");
                SetMusicVolume(value);
                musicSlider.SetValueWithoutNotify(value);
            }
            else
            {
                SetMusicVolume(0);
                musicSlider.SetValueWithoutNotify(0);
            }

            if (PlayerPrefs.HasKey("SoundVolume"))
            {
                float value = PlayerPrefs.GetFloat("SoundVolume");
                SetSoundVolume(0);
                soundSlider.SetValueWithoutNotify(0);
            }
            else
            {
                SetSoundVolume(1);
                soundSlider.SetValueWithoutNotify(1);
            }
        }

        public void Awake()
        {
            Load();
        }

        private void OnEnable()
        {
            qualityDropdown.onValueChanged.AddListener(SetQuality);
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
        }

        private void OnDisable()
        {
            qualityDropdown.onValueChanged.RemoveListener(SetQuality);
            musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
            soundSlider.onValueChanged.RemoveListener(SetSoundVolume);
        }




    }
}
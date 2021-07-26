using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] languagesBtns = new GameObject[2];
    [SerializeField] private GameObject[] togglesBtns = new GameObject[2];
    [SerializeField] private AudioSource generalAudioSource;
    private void Awake()
    {
        UpdateFeaturesButtons();
        UpdateLanguageButtons();        
    }
    public void UpdateFeaturesBools(int id)
    {
        switch (id)
        {
            case 0:
                UserManager.soundOn = 1;
                PlayerPrefs.SetInt("SoundOnKey", 1);
                break;
            case 1:
                UserManager.musicOn = 1;
                PlayerPrefs.SetInt("MusicOnKey", 1);
                break;
            case 2:
                UserManager.soundOn = 0;
                PlayerPrefs.SetInt("SoundOnKey", 0);
                break;
            case 3:
                UserManager.musicOn = 0;
                PlayerPrefs.SetInt("MusicOnKey", 0);
                break;
        }
    }

    public void UpdateFeaturesButtons()
    {
        if (UserManager.soundOn == 1)
        {
            togglesBtns[0].GetComponent<ToggleController>().isOn = true;
        }
        else
        {
            togglesBtns[0].GetComponent<ToggleController>().isOn = false;
        }

        if (UserManager.musicOn == 1)
        {
            togglesBtns[1].GetComponent<ToggleController>().isOn = true;
            generalAudioSource.Play();
        }
        else
        {
            togglesBtns[1].GetComponent<ToggleController>().isOn = false;
            generalAudioSource.Stop();
        }
    }
    public void UpdateLanguageBools(int id)
    {
        switch (id)
        {
            case 0:               
                UserManager.englishOn = 1;
                UserManager.russianOn = 0;
                PlayerPrefs.SetInt("EnglishKey", 1);
                PlayerPrefs.SetInt("RussianKey", 0);
                break;
            case 1:
                UserManager.englishOn = 0;
                UserManager.russianOn = 1;
                PlayerPrefs.SetInt("EnglishKey", 0);
                PlayerPrefs.SetInt("RussianKey", 1);
                break;
        }
    }
    public void UpdateLanguageButtons()
    {
        if (UserManager.englishOn == 1)
        {
            languagesBtns[0].SetActive(true);
            languagesBtns[1].SetActive(false);
        }
        if (UserManager.russianOn == 1)
        {
            languagesBtns[0].SetActive(false);
            languagesBtns[1].SetActive(true);
        }
    }
}

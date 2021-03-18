using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invert;
    public AudioMixer audioMixer;
    public Slider BGMSlider;
    public Slider SFXSlider;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == 1)
        {
            invert.isOn = true;
        }
        else
        {
            invert.isOn = false;
        }
        if (PlayerPrefs.GetFloat("BGMVolume") != 0)
        {
            BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        }
        if (PlayerPrefs.GetFloat("SFXVolume") != 0)
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void Back()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    public void Apply()
    {
        if (invert.isOn)
        {
            PlayerPrefs.SetInt("Inverted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Inverted", 0);
        }
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }
}

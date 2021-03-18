using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public void Pause()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gameIsPaused = true;
        paused.TransitionTo(.01f);
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        unpaused.TransitionTo(.01f);
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        unpaused.TransitionTo(.01f);
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        unpaused.TransitionTo(.01f);
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        unpaused.TransitionTo(.01f);
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(4);
    }
}

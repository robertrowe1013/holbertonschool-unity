using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}

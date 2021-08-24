using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public GameObject popUpWindow;
    public string sceneName;
    public Animator anim;

    public void PopUpToggle()
    {
        if (popUpWindow.activeSelf)
        {
            popUpWindow.SetActive(false);
        }
        else
        {
            popUpWindow.SetActive(true);
        }
    }

    public void SwitchScene()
    {
        Debug.Log("Switch to scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    

    public void FadeIn()
    {
        popUpWindow.SetActive(false);
    }

    public void FadeOut()
    {
        Debug.Log("Button Click Scene: " + sceneName);
        popUpWindow.SetActive(true);
        anim.SetTrigger("FadeTrigger");
        StartCoroutine(wait(sceneName));
    }

    public void FadeOutCantina()
    {
        sceneName = "Cantina";
        Debug.Log("Button Click Scene: " + sceneName);
        popUpWindow.SetActive(true);
        anim.SetTrigger("FadeTrigger");
    }

    public void FadeOutCube()
    {
        sceneName = "Cube";
        Debug.Log("Button Click Scene: " + sceneName);
        popUpWindow.SetActive(true);
        anim.SetTrigger("FadeTrigger");
    }

    IEnumerator wait(string scene)
    {
        while (true)
        {
            Debug.Log("Load Scene: " + scene);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(scene);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject inGameUI;
    public GameObject cam;
    public GameObject ammo;
    public GameObject spawnAmmo;
    public Rigidbody rb;
    public GameObject snowball;
    public Text ScoreUI;
    public Text AmmoCountUI;
    public int score = 0;
    public int ammoCount = 7;

    public Vector3 mouseDownPos;
    public Vector3 mouseUpPos;

    public void Update()
    {
        if (snowball.transform.position.y < -10)
        {
            Reload();
        }
        ScoreUI.text = "Score: " + score;
        AmmoCountUI.text = "Snowballs: " + ammoCount;
    }

    public void PressStart()
    {
        startButton.SetActive(false);
        inGameUI.SetActive(true);
        snowball = Instantiate(ammo, spawnAmmo.transform.position, Quaternion.identity);
        snowball.transform.SetParent(cam.transform);
    }

    public void ShotTest()
    {
        mouseDownPos = Input.mousePosition;
    }

    public void ShotRelease()
    {
        mouseUpPos = Input.mousePosition;
        Shoot(mouseDownPos - mouseUpPos);
    }

    public void Shoot(Vector3 Force)
    {
        snowball.transform.SetParent(null);
        rb = snowball.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) / 4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        Destroy(snowball);
        ammoCount -= 1;
        if (ammoCount < 1)
        {
            // replay
        }
        snowball = Instantiate(ammo, spawnAmmo.transform.position, Quaternion.identity);
        snowball.transform.SetParent(cam.transform);
    }
}

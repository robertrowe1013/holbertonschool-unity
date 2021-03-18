using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject timerCanvas;
    GameObject[] coins;
    public Animator anim;
    bool splat = true;

    void Start()
    {
        foreach (Animator ani in player.GetComponentsInChildren<Animator>())
        {
            anim = ani;
        }
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }



    public void OnTriggerStay()
    {
        PlayerController pl = player.GetComponent<PlayerController>();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Happy Idle"))
        {
            pl.lockmove = false;
            splat = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Falling Flat Impact") && splat && pl.splat.isPlaying == false)
        {
            splat = false;
            anim.SetBool("isFalling", false);
            pl.splat.Play();
        }
    }

    public void OnTriggerExit()
    {
        timerCanvas.SetActive(true);
        player.GetComponent<Timer>().timerValue = 0f;
        player.GetComponent<Timer>().timerValueTrigger = true;
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}

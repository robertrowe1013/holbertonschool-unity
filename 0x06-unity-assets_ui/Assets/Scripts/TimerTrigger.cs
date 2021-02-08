using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    GameObject[] coins;

    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    void OnTriggerExit()
    {
        player.GetComponent<Timer>().timerValue = 0f;
        player.GetComponent<Timer>().timerValueTrigger = true;
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}

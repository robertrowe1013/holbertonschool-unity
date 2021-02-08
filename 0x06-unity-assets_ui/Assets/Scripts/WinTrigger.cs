using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter()
    {
        player.GetComponent<Timer>().timerValueTrigger = false;
        player.GetComponent<Timer>().TimerText.color = Color.green;
        player.GetComponent<Timer>().TimerText.fontSize = 60;
    }
}

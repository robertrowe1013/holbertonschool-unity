using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;

    void OnTriggerExit()
    {
        player.GetComponent<Timer>().timerValueTrigger = true;
    }
}

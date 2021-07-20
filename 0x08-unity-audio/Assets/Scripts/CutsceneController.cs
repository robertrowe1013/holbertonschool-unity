﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject TimerCanvas;

    public void endCutscene()
    {
        MainCamera.SetActive(true);
        TimerCanvas.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}

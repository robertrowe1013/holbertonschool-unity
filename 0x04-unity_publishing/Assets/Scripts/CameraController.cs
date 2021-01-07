﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 25.6f, -9f);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}

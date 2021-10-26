using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Not yet implemented
    bool isFalling = false;

    void OnTriggerEnter(Collider item)
    {
        if (item.tag == "Player")
        {
            Debug.Log("trigger fall");
            isFalling = true;
        }
    }
}

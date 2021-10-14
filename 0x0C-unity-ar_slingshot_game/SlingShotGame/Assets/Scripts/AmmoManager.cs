using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject ui;

    void Start()
    {
        ui = GameObject.FindWithTag("InGameUI");
    }

    public void OnTriggerEnter(Collider item)
    {
        if (item.tag == "Target")
        {
            ui.GetComponent<UIManager>().score += 10;
            ui.GetComponent<UIManager>().Reload();
        }
    }
}

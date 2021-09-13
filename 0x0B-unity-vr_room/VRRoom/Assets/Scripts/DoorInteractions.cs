using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractions : MonoBehaviour
{
    public bool isOpen = false;
    public bool unlocked = false;
    public Animator anim;
    public GameObject lockedSign;
    public GameObject panel;

    public void OnClick()
    {
        if (isOpen && unlocked)
        {
            anim.SetTrigger("doorstop");
            isOpen = false;
        }
        else if (unlocked)
        {
            anim.Play("glass_door_open");
            isOpen = true;
        }
        else
        {
            lockedSign.SetActive(true);
            panel.SetActive(true);
        }
    }
}

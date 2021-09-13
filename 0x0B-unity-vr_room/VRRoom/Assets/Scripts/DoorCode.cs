using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCode : MonoBehaviour
{
    public int[] codeArr = new int[3] {-1, -1, -1};
    public GameObject codeDisplay;
    public GameObject door;
    public GameObject lockedSign;

    public void codeCheck()
    {
        if (codeArr[2] != -1)
        {
            if (codeArr[0] == 3 && codeArr[1] == 0 && codeArr[2] == 3)
            {
                codeDisplay.GetComponent<Text>().text = "UNLOCKED";
                door.GetComponent<DoorInteractions>().unlocked = true;
                lockedSign.SetActive(false);
            }
            else
            {
                //wrong code message
                codeDisplay.GetComponent<Text>().text = "_ _ _";
                codeArr = new int[3] {-1, -1, -1};
            }

        }
        else
        {
            if (codeArr[1] == -1)
            {
                codeDisplay.GetComponent<Text>().text = codeArr[0].ToString() + " _ _";
            }
            else
            {
                codeDisplay.GetComponent<Text>().text = codeArr[0].ToString() + " " + codeArr[1].ToString() + " _";
            }

        }
    }
    public void EnterCode(int number)
    {
        if (codeArr[0] == -1)
        {
            codeArr[0] = number;
            codeCheck();
        }
        else if (codeArr[1] == -1)
        {
            codeArr[1] = number;
            codeCheck();
        }
        else
        {
            codeArr[2] = number;
            codeCheck();
        }
    }

    public void PressZero()
    {
        EnterCode(0);
    }

    public void PressOne()
    {
        EnterCode(1);
    }

    public void PressTwo()
    {
        EnterCode(2);
    }

    public void PressThree()
    {
        EnterCode(3);
    }
}
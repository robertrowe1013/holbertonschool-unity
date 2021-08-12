using UnityEngine;
using Vuforia;

public class DieManager : MonoBehaviour
{
    public bool isSpinning = true;
    public Animator anim;
    public GameObject test;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }
    }

    public void SpawnCube()
    {
        anim.SetTrigger("dieSpawn");
    }

    public void TopClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }

    public void GitClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
            Application.OpenURL("https://github.com/robertrowe1013");
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }

    public void FaceClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
            Application.OpenURL("https://www.facebook.com/groups/2385572485046288/");
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }

    public void LinkedClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
            Application.OpenURL("https://www.linkedin.com/in/robertrowe1013/");
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }

    public void GmailClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
            Application.OpenURL("mailto:robertrowe1013@gmail.com");
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }

    public void TwitterClick()
    {
        if (isSpinning == true)
        {
            isSpinning = false;
            anim.speed = 0;
            Application.OpenURL("https://twitter.com/RobertRowe1013");
        }
        else
        {
            isSpinning = true;
            anim.speed = 1;
        }
    }
}

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
        TopClick();
        Application.OpenURL("https://github.com/robertrowe1013");
    }

    public void FaceClick()
    {
        TopClick();
        Application.OpenURL("https://www.facebook.com/groups/2385572485046288/");
    }

    public void LinkedClick()
    {
        TopClick();
        Application.OpenURL("https://www.linkedin.com/in/robertrowe1013/");
    }

    public void GmailClick()
    {
        TopClick();
        Application.OpenURL("mailto:robertrowe1013@gmail.com");
    }

    public void TwitterClick()
    {
        TopClick();
        Application.OpenURL("https://twitter.com/RobertRowe1013");
    }
}

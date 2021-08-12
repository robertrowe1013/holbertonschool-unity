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
            // anim.speed = 0;
        }
        else
        {
            isSpinning = true;
            // anim.speed = 1;
        }
    }
}

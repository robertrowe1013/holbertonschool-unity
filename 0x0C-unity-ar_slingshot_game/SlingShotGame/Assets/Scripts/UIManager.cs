using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    //snowball physics
    public GameObject ammo;
    public Rigidbody rb;
    public bool isShot = false;

    Vector3 mouseDownPos;
    Vector3 mouseUpPos;

    public void PressStart()
    {
        startButton.SetActive(false);
        ammo.SetActive(true);
    }

    public void ShotTest()
    {
        mouseDownPos = Input.mousePosition;
    }

    public void ShotRelease()
    {
        mouseUpPos = Input.mousePosition;
        Shoot(mouseDownPos - mouseUpPos);
    }

    public void Shoot(Vector3 Force)
    {
        rb = ammo.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) / 5);
        isShot = true;
    }
}

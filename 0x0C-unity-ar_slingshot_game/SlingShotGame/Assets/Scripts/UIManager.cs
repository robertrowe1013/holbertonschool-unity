using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject cam;
    public GameObject ammo;
    public Rigidbody rb;
    public GameObject snowball;
    public bool isShot = false;

    Vector3 mouseDownPos;
    Vector3 mouseUpPos;

    public void Update()
    {
        if (snowball.transform.position.y < -10)
        {
            Destroy(snowball);
            snowball = Instantiate(ammo, new Vector3(0, 0, 0), Quaternion.identity);
            snowball.transform.SetParent(cam.transform);
            snowball.transform.position = new Vector3(0, -0.1f, 0.5f);
        }
    }

    public void PressStart()
    {
        startButton.SetActive(false);
        snowball = Instantiate(ammo, new Vector3(0, 0, 0), Quaternion.identity);
        snowball.transform.SetParent(cam.transform);
        snowball.transform.position = new Vector3(0, -0.1f, 0.5f);
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
        rb = snowball.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) / 5);
        isShot = true;
    }
}

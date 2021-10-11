using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public UIManager ammoButton;
    public float ammoTimer = 0f;
    public Vector3 reloadPos = new Vector3(0, -0.1f, 0.5f);
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoTimer > 300f)
        {
            ammoButton.isShot = false;
            ammoTimer = 0f;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.transform.position = reloadPos;

        }

        if (ammoButton.isShot)
        {
            ammoTimer += 1f;
        }
    }
}

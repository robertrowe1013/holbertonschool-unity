using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    private float distance = 6.25f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sensitivityX = 5f;
    private float sensitivityY = 5f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxisRaw("Mouse X");
        currentY -= Input.GetAxisRaw("Mouse Y");
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3 (0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * direction;
        camTransform.LookAt(lookAt.position);
    }
}

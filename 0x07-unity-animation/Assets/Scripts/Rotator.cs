using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// For spinning coins
public class Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.right * (45 * Time.deltaTime));
    }
}

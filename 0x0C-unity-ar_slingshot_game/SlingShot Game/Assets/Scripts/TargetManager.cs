using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TargetManager : MonoBehaviour
{
    ARPlane plane;
    Vector3 node;
    int randomNode;
    float timer = 0;

    void Start()
    {
        plane = GetComponentInParent<ARPlane>();
        randomNode = Random.Range(0, plane.boundary.Length);
        node = new Vector3(plane.boundary[randomNode].x, .1f, plane.boundary[randomNode].y);
    }

    void Update()
    {
        // random target movement
        if (timer > 40) {
            randomNode = Random.Range(0, plane.boundary.Length);
            node = new Vector3(plane.boundary[randomNode].x, .1f, plane.boundary[randomNode].y);
            timer = Random.Range(0, 5);
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, node, Time.deltaTime / 2);
        timer++;
    }
}

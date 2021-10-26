using UnityEngine;

public class MovingPlatformObj : MonoBehaviour
{
    public float platformPosition;
    public string platformDirection;
    public float speed;

    // Not yet implemented
    void FixedUpdate()
    {
        //vertical moving
        if (platformDirection == "up")
        {
            transform.Translate(Vector3.up * 5 * Time.deltaTime * speed, Space.World);
            platformPosition += (1f * Time.deltaTime * speed);
        }
        else if (platformDirection == "down")
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime * speed, Space.World);
            platformPosition -= (1f * Time.deltaTime * speed);
            
        }
        if (platformPosition > 2f && platformDirection == "up")
        {
            platformDirection = "down";
        }
        if (platformPosition < 0f && platformDirection == "down")
        {
            platformDirection = "up";
        }
        // horizontal moving
        if (platformDirection == "left")
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime * speed, Space.World);
            platformPosition += (1f * Time.deltaTime * speed);
        }
        else if (platformDirection == "right")
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime * speed, Space.World);
            platformPosition -= (1f * Time.deltaTime * speed);
            
        }
        if (platformPosition > 2f && platformDirection == "left")
        {
            platformDirection = "right";
        }
        if (platformPosition < 0f && platformDirection == "right")
        {
            platformDirection = "left";
        }
    }
    void OnTriggerEnter(Collider col)
    {
        col.transform.SetParent(transform);
        Debug.Log("enter triggered");
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exit Triggered");
        col.transform.parent = null;
    }
}
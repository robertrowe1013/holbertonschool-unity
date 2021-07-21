using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;

    void OnTriggerEnter(Collider item)
    {
        if (item.tag == "Player")
        {
            Debug.Log("trigger fall");
            isFalling = true;
        }
    }
}

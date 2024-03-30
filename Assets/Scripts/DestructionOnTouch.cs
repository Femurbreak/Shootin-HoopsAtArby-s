using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object touched by this object has a specific tag (replace "TargetObjectTag" with the tag of the object you want to collide with)
        if (other.gameObject.CompareTag("Basketball"))
        {
            // Destroy the other object
            Destroy(other.gameObject);
        }
    }
}

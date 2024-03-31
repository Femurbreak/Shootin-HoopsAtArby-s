using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestructionOnTouch : MonoBehaviour
{
    public Transform player;
    void OnTriggerEnter(Collider other)
    {
        // Check if the object touched by this object has a specific tag (replace "TargetObjectTag" with the tag of the object you want to collide with)
        if (other.gameObject.CompareTag("Basketball"))
        {
            // Destroy the other object
            Destroy(other.gameObject);
            player.GetComponent<ShootingController>().BallDestroyed();
        }
    }
}

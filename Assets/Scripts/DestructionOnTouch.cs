using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestructionOnTouch : MonoBehaviour
{
    public Transform player;

    void OnTriggerEnter(Collider other)
    {
        // Destroy the other object
        Destroy(other.gameObject);
        player.GetComponent<ShootingController>().BallDestroyed();   
    }
}

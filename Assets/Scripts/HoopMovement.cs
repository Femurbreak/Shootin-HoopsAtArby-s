using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMovement : MonoBehaviour
{
    public float moveDistance = 5f; // Total distance to move left and right
    public float moveSpeed = 2f; // Speed of movement
    private Vector3 originalPosition; // Initial position of the object
    private bool movingRight = true; // Initially start moving right

    void Start()
    {
        // Store the initial position of the object
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate the movement direction based on whether the object is currently moving right or left
        Vector3 movement = movingRight ? Vector3.right : Vector3.left;

        // Calculate the target position
        Vector3 targetPosition = movingRight ? originalPosition + Vector3.right * (moveDistance / 2) : originalPosition;

        // Move the object by the movement distance over time
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the object has reached the target position, change direction
        if (transform.position == targetPosition)
        {
            movingRight = !movingRight;
        }
    }
}

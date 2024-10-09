using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FlaskReset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public float tiltThreshold = 90.0f; // Degrees at which the flask will be reset
    private bool isGrounded = false; // Track if the flask is touching the ground
    public LayerMask groundLayer; // Layer mask to identify the ground

    void Start()
    {
        // Save the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the flask is tilted by 90 degrees
        if (Vector3.Angle(transform.up, Vector3.up) >= tiltThreshold)
        {
            ResetFlaskPosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the flask has collided with the ground
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = true;
            ResetFlaskPosition();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the flask is no longer touching the ground
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = false;
        }
    }

    public void ResetFlaskPosition()
    {
        // Reset the position and rotation to the initial values
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        isGrounded = false; // Reset grounded state
    }
}

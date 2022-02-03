using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speedFactor = 10f;
    public float rotationSpeedFactor = 180f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float rotationSpeed = rotationSpeedFactor * rotationInput;
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation * transform.up);
    }

    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float speed = speedFactor * forwardInput;
        float move = speed;
        rb.AddForce(move * transform.forward);

        /*
        // Not recommended: less pleasant control for the game expected here
        float rotationInput = Input.GetAxis("Horizontal");
        float rotationSpeed = rotationSpeedFactor * rotationInput;
        float rotation = rotationSpeed;
        rb.AddTorque(rotation * transform.up);
        */
    }
}

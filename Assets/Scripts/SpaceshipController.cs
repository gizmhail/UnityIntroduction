using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speedFactor = 10f;
    public float rotationSpeedFactor = 180f;

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float speed = speedFactor * forwardInput;
        float move = speed * Time.deltaTime;
        transform.position += move * transform.forward;

        float rotationInput = Input.GetAxis("Horizontal");
        float rotationSpeed = rotationSpeedFactor * rotationInput;
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation * transform.up);
    }
}

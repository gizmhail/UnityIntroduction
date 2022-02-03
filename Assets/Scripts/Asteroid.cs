using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;
    public float initialSpeed = 8;
    public float initialRotationSpeed = 6;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Random.insideUnitSphere * Random.Range(initialSpeed/2f, initialSpeed);
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(initialRotationSpeed/2f, initialRotationSpeed);
    }
}

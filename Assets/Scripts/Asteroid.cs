using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;
    public float initialSpeed = 8;
    public float initialRotationSpeed = 6;
    public GameObject childAsteroidPrefab;
    public string missileTag = "Missile";

    private void Awake()
    {
        // To prevent early collisions, we only activate the collider a few instant after the asteroid spawn
        DisableCollision();
        Invoke("EnableCollision", 1);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Random.insideUnitSphere * Random.Range(initialSpeed/2f, initialSpeed);
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(initialRotationSpeed/2f, initialRotationSpeed);
    }

    public void DisableCollision()
    {
        foreach (var collider in GetComponentsInChildren<Collider>()) collider.enabled = false;
    }

    public void EnableCollision()
    {
        foreach (var collider in GetComponentsInChildren<Collider>()) collider.enabled = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        GameObject other = collision?.rigidbody?.gameObject;
        if (other && other.tag == missileTag)
        {
            // We disable the projectile collider to avoid it destroying several objects (the Destroy call is not immediate)
            foreach (var collider in collision.rigidbody.gameObject.GetComponentsInChildren<Collider>()) collider.enabled = false;
            Destroy(collision.rigidbody.gameObject);
        }
        if (childAsteroidPrefab != null)
        {
            Vector3 offsetDirection = Vector3.Cross(rb.velocity, Vector3.up);
            var c1 = GameObject.Instantiate(childAsteroidPrefab, transform.position + offsetDirection, transform.rotation);
            var c2 = GameObject.Instantiate(childAsteroidPrefab, transform.position - offsetDirection, transform.rotation);
        }
    }
}

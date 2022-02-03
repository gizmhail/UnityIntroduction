using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDust : MonoBehaviour
{
    ParticleSystem ps;
    Rigidbody rb;

    [Tooltip("Min velocity for space dust spawn")]
    public float minVelocity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < minVelocity)
        {
            if (!ps.isPaused)
            {
                ps.Pause();
            }
        } else
        {
            if (ps.isPaused)
            {
                ps.Play();
            }
        }
    }
}

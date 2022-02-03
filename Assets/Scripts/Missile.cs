using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = speed* transform.forward;
        Destroy(this.gameObject, 2);
    }

}

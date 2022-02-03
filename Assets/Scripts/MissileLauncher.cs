using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform spawnPoint;


    private void Start()
    {
        if (spawnPoint == null) spawnPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject.Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

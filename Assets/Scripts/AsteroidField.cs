using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform fieldCenter;
    public List<GameObject> asteroids = new List<GameObject>();

    public float minSpawnDistance = 15;
    public float maxSpawnDistance = 25;
    public float maxAliveDistance = 30;

    public int minAsteroid = 20;

    // Update is called once per frame
    void Update()
    {
        PurgeFarAsteroids();

        FillAsteroidCount();
    }

    private void PurgeFarAsteroids()
    {
        foreach (var a in asteroids)
        {
            if (Vector3.Distance(a.transform.position, fieldCenter.position) > maxAliveDistance)
            {
                Destroy(a);
            }
        }
    }

    private void FillAsteroidCount()
    {
        if (asteroids.Count < minAsteroid)
        {
            // To visually test the spawn point : var a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var a = GameObject.Instantiate(asteroidPrefab);
            a.transform.parent = transform;
            var offset = Random.onUnitSphere;
            offset = new Vector3(offset.x, 0, offset.z).normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
            a.transform.position = fieldCenter.TransformPoint(offset);
        }
    }

}

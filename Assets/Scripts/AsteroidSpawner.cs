using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform destroyer;
    public GameObject[] asteroidPrefab;
    public Transform[] spawnpoints;
    public float spawnInterval = 1f;
    public float fallSpeed = 2f;
    public float rotationInterval = 120f;

    private float nextSpawnTime;
    private float nextRotationTime;

    void Start()
    {
        nextRotationTime = Time.time + rotationInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // if (Time.time >= nextRotationTime)
        // {
        //     RotateSpawner();
        //     nextRotationTime = Time.time + rotationInterval;
        // }
    }

    void SpawnAsteroid()
    {
        int randomSP = Random.Range(0, spawnpoints.Length);

        // Calculate random position within the spawn range
        Vector3 spawnPosition = spawnpoints[randomSP].position;

        int temp = Random.Range(0, asteroidPrefab.Length);

        // Instantiate the asteroid
        Astroids asteroid = Instantiate(asteroidPrefab[temp], spawnPosition, Quaternion.identity).GetComponent<Astroids>();
        asteroid.destroyer = destroyer;
    }

    void RotateSpawner()
    {
        // Rotate the spawner parent object to a new random direction
        float angle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
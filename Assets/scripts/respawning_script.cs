using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawning_script : MonoBehaviour
{
    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float maxZ; // New variable for max Z-axis value
    public float minZ; // New variable for min Z-axis value
    public float TimeBetweenSpawn;
    private float SpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime)
        {
            spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    void spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ); // Generate random Z-axis value

        Vector3 spawnPosition = new Vector3(x, y, z);

        Instantiate(Obstacle, spawnPosition, Quaternion.identity);
    }
}

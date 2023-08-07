using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawning_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
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
        float x = Random.Range(minX, maxY);
        float y = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}

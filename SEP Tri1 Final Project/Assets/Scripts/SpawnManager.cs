using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] objectPrefabs;

    private float startDelay = 1;
    private float spawnInterval = 1;

    private float spawnPosX = 12.5f;
    public float randX;
    private float spawnRangeY = 4;

    // Start is called before the first frame update
    void Start()
    {
        // spawn objects repeatedly
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomObject()
    {
        // determine which side object will spawn on
        randX = Random.Range(0, 2);
        if (randX >= 1)
        {
            randX = 1;
        }
        else
        {
            randX = -1;
        }

        // determine which object will spawn and object spawn position
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        Vector2 spawnPos = new Vector2(randX * spawnPosX, Random.Range(-spawnRangeY, spawnRangeY));

        // spawn object
        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);


    }
}

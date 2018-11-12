using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPool : MonoBehaviour
{

    public float spawnRate = 1f;
    public GameObject flock1Prefab;
    public GameObject flock2Prefab;
    public GameObject flock3Prefab;
    public GameObject flock4Prefab;
    public GameObject flock5Prefab;

    private float timeSinceLastSpawned;
    private float spawnXPosition = 18f;
    private float minYPos = -12f;
    private float maxYPos = -4f;
   
    private int currFlock = 0;
    private int numFlocks = 5;
    private GameObject[] flocks;

    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);   // Store pool offscreen

    void Start()
    {
        // Instantiate bird pool
        flocks = new GameObject[numFlocks];
        flocks[0] = (GameObject)Instantiate(flock1Prefab, objectPoolPosition, Quaternion.identity);
        flocks[1] = (GameObject)Instantiate(flock2Prefab, objectPoolPosition, Quaternion.identity);
        flocks[2] = (GameObject)Instantiate(flock3Prefab, objectPoolPosition, Quaternion.identity);
        flocks[3] = (GameObject)Instantiate(flock4Prefab, objectPoolPosition, Quaternion.identity);
        flocks[4] = (GameObject)Instantiate(flock5Prefab, objectPoolPosition, Quaternion.identity);
    }


    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;     // Keep track of time for respawn timer

        if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;               // Reset spawn rate

            float yPos = Random.Range(minYPos, maxYPos);

            // Spawn birds
            flocks[currFlock].transform.position = new Vector2(spawnXPosition, yPos);
            currFlock = currFlock == numFlocks - 1 ? 0 : currFlock + 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public int numTypesObstacles = 2;
    public int numIgloos = 3;
    public int numTrees = 3;
    public GameObject iglooPrefab;
    public GameObject treePrefab;
    public float spawnRate = 4f;

    // Arrays to keep track of each type of obstacle
    private GameObject[] igloos;
    private GameObject[] trees;
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private float iglooSpawnYPosition = -2.7f;
    private float treeSpawnYPosition = -3.2f;
    private int currIgloo = 0;
    private int currTree = 0;

    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);   // Store pool offscreen

	void Start () 
    {
        // Instantiate igloo pool
        igloos = new GameObject[numIgloos];
        for (int i = 0; i < numIgloos; i++) 
        {
            igloos[i] = (GameObject)Instantiate(iglooPrefab, objectPoolPosition, Quaternion.identity);
        }

        // Instantiate tree pool
        trees = new GameObject[numTrees];
        for (int i = 0; i < numTrees; i++)
        {
            trees[i] = (GameObject)Instantiate(treePrefab, objectPoolPosition, Quaternion.identity);
        }
    }
	

	void Update () 
    {
        timeSinceLastSpawned += Time.deltaTime;     // Keep track of time for respawn timer

        if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;               // Reset spawn rate
            float rand = Random.Range(0f, 1.0f);   
            int type = rand <= 0.5 ? 0 : 1;         // Get random number to determine type of obstacle

            // Spawn igloo
            if (type == 0) {
                igloos[currIgloo].transform.position = new Vector2(spawnXPosition, iglooSpawnYPosition);
                currIgloo = (currIgloo == numIgloos - 1) ? 0 : currIgloo + 1;       // increment igloo index
            }
            // Spawn tree
            else
            {
                trees[currTree].transform.position = new Vector2(spawnXPosition, treeSpawnYPosition);
                currTree = (currTree == numTrees - 1) ? 0 : currTree + 1;           // increment tree index
            }

        }
	}
}

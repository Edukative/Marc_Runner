using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab; // the obstacle prefab that spawns
    public int obstacleIndex; // the index of the GameObject in the Array

    private Vector3 spawnPos = new Vector3(25, 0, 0); // the position it will spawn

    private float startDelay = 2; // the seconds of the delay of the spawn after the start function
    private float repeatRate = 2; // the interval it will be called
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // call the function constantly
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle ()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation); //spawn obstacle
    }
}

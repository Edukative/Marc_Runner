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

    private PlayerContoller playerControllerScript;

    public int obstaclesDestroyCount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // call the function constantly
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
        // find the player in the scene by it's name and retrieve its script
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle ()
    {
        if (!playerControllerScript.isGameOver)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            GameObject obstacle = Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation); //spawn obstacle
            MoveLeft obsScript = obstacle.GetComponent<MoveLeft>(); // retrieve script from spawned obstacle
            obsScript.speed = obsScript.speed + (float)obstaclesDestroyCount;
                                                //transform int to float
        }
            
    }
}

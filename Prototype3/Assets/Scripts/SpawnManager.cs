using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject powerupPrefab;
    public GameObject[] enemies;
    private Vector3 spawnPosition = new Vector3(30,0,0);
    private Vector3 powerupSpawnPosition = new Vector3(15, 4, 0);
    private float startDelay = 2;
    private float repeatRate =10;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnPowerup", 10, 10);
        InvokeRepeating("SpawnEnemies", 4, 4);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) //is game is not over, (has not run into obstacle), spawn obstacle
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);


        }
    }

    void SpawnPowerup()
    {
        if(playerControllerScript.gameOver == false)
        {
            
            Instantiate(powerupPrefab, powerupSpawnPosition, obstaclePrefab.transform.rotation);

        }

    }


    void SpawnEnemies()
    {
        if (playerControllerScript.gameOver == false)
        {
            int enemyIndex = Random.Range(1, enemies.Length);
            Instantiate(enemies[enemyIndex], spawnPosition, enemies[0].transform.rotation);

        }

    }
}

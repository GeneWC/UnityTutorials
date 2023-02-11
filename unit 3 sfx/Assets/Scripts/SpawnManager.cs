using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    private float spawnTime = 3;
    private float currTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            currTime += Time.deltaTime;
            if (currTime >= spawnTime)
            {
                int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
                Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
                currTime = 0;
                if (spawnTime > 1)
                {
                    spawnTime -= .03f;
                }
                
            }

        }
    }

}

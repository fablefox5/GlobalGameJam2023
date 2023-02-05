using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillInstantiater : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public GameObject[] obstacles;
    public Transform spawnOne;
    public Transform spawnTwo;
    public Transform spawnThree;
    public Transform spawnFour;
    private GameObject prefab1;
    private GameObject prefab2;
    private GameObject prefab3;
    private GameObject prefab4;
    void Awake()
    {
        prefab1 = Instantiate(GetRandomPrefab(), spawnOne);
        SpawnObstacleCheck(prefab1);
        prefab2 = Instantiate(GetRandomPrefab(), spawnTwo);
        SpawnObstacleCheck(prefab2);
        prefab3 = Instantiate(GetRandomPrefab(), spawnThree);
        SpawnObstacleCheck(prefab3);
        prefab4 = Instantiate(GetRandomPrefab(), spawnFour);
        SpawnObstacleCheck(prefab4);
        /*spawnOne.transform.rotation = Quaternion.Euler(0, 90, 0);
        spawnTwo.transform.rotation = Quaternion.Euler(0, 90, 0);*/
    }
    public GameObject GetRandomPrefab()
    {
        return groundPrefabs[Random.Range(0, groundPrefabs.Length)];
    }
    void Update()
    {
        if (prefab1 == null)
        {
            prefab1 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
            SpawnObstacleCheck(prefab1);
        }
        if (prefab2 == null)
        {
            prefab2 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
            SpawnObstacleCheck(prefab2);
        }
        if (prefab3 == null)
        {
            prefab3 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
            SpawnObstacleCheck(prefab3);
        }
        if (prefab4 == null)
        {
            prefab4 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
            SpawnObstacleCheck(prefab4);
        }
    }


    private bool WillObstacleSpawn()
    {
        if(Random.Range(0, 2) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnObstacleCheck(GameObject chunk)
    {
        if(WillObstacleSpawn())
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], chunk.transform);
            ObstacleNode nodeRef = chunk.GetComponent<ObstacleNode>();
            obstacle.transform.position = nodeRef.GetNodePosition(Random.Range(0, nodeRef.nodeArray.Length));
           

        }
    }


}

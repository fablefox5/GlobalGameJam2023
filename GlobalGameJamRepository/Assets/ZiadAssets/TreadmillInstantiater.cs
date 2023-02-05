using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillInstantiater : MonoBehaviour
{
    public GameObject[] groundPrefabs;
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
        prefab2 = Instantiate(GetRandomPrefab(), spawnTwo);
        prefab3 = Instantiate(GetRandomPrefab(), spawnThree);
        prefab4 = Instantiate(GetRandomPrefab(), spawnFour);
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
        }
        if (prefab2 == null)
        {
            prefab2 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
        }
        if (prefab3 == null)
        {
            prefab3 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
        }
        if (prefab4 == null)
        {
            prefab4 = (GameObject)Instantiate(GetRandomPrefab(), spawnFour);
        }
    }
}

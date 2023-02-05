using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillInstantiater : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform spawnOne;
    public Transform spawnTwo;
    private GameObject prefab1;
    private GameObject prefab2;
    void Awake()
    {
        prefab1 = Instantiate(GetRandomPrefab(), spawnOne);
        prefab2 = Instantiate(GetRandomPrefab(), spawnTwo);
        spawnOne.transform.rotation = Quaternion.Euler(0, 90, 0);
        spawnTwo.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    public GameObject GetRandomPrefab()
    {
        return groundPrefabs[Random.Range(0, groundPrefabs.Length)];
    }
    void Update()
    {
        if (prefab1 == null)
        {
            prefab1 = (GameObject)Instantiate(GetRandomPrefab(), spawnTwo);
        }
        if (prefab2 == null)
        {
            prefab2 = (GameObject)Instantiate(GetRandomPrefab(), spawnTwo);
        }
    }
}

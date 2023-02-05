using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanclaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chanclaType;
    //[SerializeField]
    //private GameObject chanclaDrop;
    private int randomNumber;

    void Start()
    {
        InvokeRepeating("RandomSpawnChancla", 8f, 3f);
    }
    private void RandomSpawnChancla()
    {
        Debug.Log("numbergenerated");
        randomNumber = Random.Range((int)1, (int)10);
        if (randomNumber >= 1 && randomNumber <= 3)
        {
            Instantiate(chanclaType);
            //Instantiate(chanclaDrop);
            Debug.Log("InstantiateChancla");
        }

    }


}

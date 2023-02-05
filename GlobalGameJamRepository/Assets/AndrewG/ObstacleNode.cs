using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleNode : MonoBehaviour
{
    [SerializeField] private GameObject[] nodeArray;

    public GameObject GetNodeLocation(int num)
    {
        return nodeArray[num];
    }


}

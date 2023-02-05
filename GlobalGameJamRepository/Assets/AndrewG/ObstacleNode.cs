using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleNode : MonoBehaviour
{
    public GameObject[] nodeArray;

    public Vector3 GetNodePosition(int num)
    {
        return nodeArray[num].transform.position;
    }


}

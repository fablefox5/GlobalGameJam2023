using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float upSide = -2.6f;
    public static float downSide = 2.6f;
    public float internalUp;
    public float internalDown;
 
    // Update is called once per frame
    void Update()
    {
        internalUp = upSide;
        internalDown = downSide;
    }
}

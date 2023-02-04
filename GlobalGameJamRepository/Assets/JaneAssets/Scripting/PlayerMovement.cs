using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3; // Initial player movement forward speed
    public float upAndDownSpeed = 3; // Player's up and down speed
    // need a jump later


    void Update() // Update is called once per frame

    {
        // Forward movement

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Up movement

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))) 
        {
            if (this.gameObject.transform.position.x > LevelBoundary.upSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * upAndDownSpeed);
            }
        }

        // Down movement

        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow))) 
        {
            if (this.gameObject.transform.position.x < LevelBoundary.downSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * upAndDownSpeed * -1);
            }
        }

    }

    
}

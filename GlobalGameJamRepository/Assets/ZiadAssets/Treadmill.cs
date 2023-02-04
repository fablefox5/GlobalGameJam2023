using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    private Rigidbody rb;
    public float treadmillSpeed;
    public float respawnPoint;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -3);
        if (transform.position.z < -respawnPoint) //min to move off screen
        {
            Vector3 resetPosition = new Vector3(0, 0, (2 * respawnPoint));
            transform.position = (Vector3)transform.position + resetPosition; //sets position to the difference between
        }
    }
}

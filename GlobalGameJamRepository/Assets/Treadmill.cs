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
        if (GameManager.instance.isDead == true)
        {
            treadmillSpeed = 0f;
        } else if (GameManager.instance.isHurt == true)
        {
            treadmillSpeed = 0.5f;
        } else if (GameManager.instance.isHurt == false)
        rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed);
        if (transform.position.z < -respawnPoint) //min to move off screen
        {
            Vector3 resetPosition = new Vector3(0, 0, (2 * respawnPoint));
            transform.position = (Vector3)transform.position + resetPosition; //sets position to two spaces ahead
        }
    }
}

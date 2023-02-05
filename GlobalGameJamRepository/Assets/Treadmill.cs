using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    private Rigidbody rb;
    public float treadmillSpeed;
    public float respawnPoint;
    //public GameObject gameOver;
    //public TreadmillInstantiater treadmillList;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (GameManager.instance.isDead == true)
        {
            treadmillSpeed = 0f; //stops ground moving, need new variable for pausing time.timescale = 0;
            //gameOver.SetActive(true);
            GameManager.instance.healthScript.movingPlayer.canMove = false;
        } else if (GameManager.instance.isHurt == true)
        {
            treadmillSpeed = 0.5f;
        } else if (GameManager.instance.isHurt == false)
        {
            treadmillSpeed = 1f;
        }
        rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed);
        //rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed);
        if (transform.position.z < respawnPoint) //dies when it's off screen
        {
            //Debug.Log("Andrewisrekt");
            Destroy(this.gameObject);
            /*Vector3 resetPosition = new Vector3(0, 0, (2 * respawnPoint));
            transform.position = (Vector3)transform.position + resetPosition; //sets position to two spaces ahead*/
        }
    }
}

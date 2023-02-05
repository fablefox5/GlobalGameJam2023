using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    private Rigidbody rb;
    public float originalTreadMillSpeed;
    public float treadmillSpeed;
    public float respawnPoint;
    /*public float acceleration;
    public float currentSpeed;
    public float maxSpeed;*/
    //public GameObject gameOver;
    //public TreadmillInstantiater treadmillList;
    public float speedModifiertest;
    public Vector3 velocityValue;
    void Start()
    {
        
        originalTreadMillSpeed = treadmillSpeed;
        rb = this.GetComponent<Rigidbody>();
       
       
    }
    void FixedUpdate()
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
            treadmillSpeed = originalTreadMillSpeed;
        }
        speedModifiertest = GameManager.instance.speedModifier;
        //rb.velocity = new Vector3(0, 0, -1 * treadmillSpeed);

         rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed * GameManager.instance.speedModifier);

        //rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed * GameManager.instance.speedModifier);
        velocityValue = rb.velocity;
        //rb.velocity = new Vector3(0, 0, -3 * treadmillSpeed);


     
       


        if (transform.position.z < respawnPoint + 0.01f) //dies when it's off screen
        {
            //Debug.Log("Andrewisrekt");
            Debug.Log("Destroyed At Location: " + transform.position);
            Destroy(this.gameObject);
            /*Vector3 resetPosition = new Vector3(0, 0, (2 * respawnPoint));
            transform.position = (Vector3)transform.position + resetPosition; //sets position to two spaces ahead*/
        }
  




    }
}

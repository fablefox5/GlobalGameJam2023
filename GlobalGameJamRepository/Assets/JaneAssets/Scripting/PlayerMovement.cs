using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float upAndDownSpeed = 3; // Player's up and down speed
    public bool canMove = true;
    public bool canMoveForward;
    public bool canMoveBack;
    
    Vector3 up = Vector3.zero, down = new Vector3(0, 1.5f, -8), currentDirection = Vector3.zero;
    Vector3 nextPosition, destination, direction;

    public Rigidbody rigidBody;
    public bool isGrounded; // Boolean that tells us if the player is on the ground
   
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentDirection = up;
        nextPosition = Vector3.left;
        destination = transform.position;
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    
    void Update() // Update is called once per frame
    {
        Move();
    }

    private void OnCollisionEnter(Collision gameObj)
    {
        if (gameObj.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, upAndDownSpeed * Time.deltaTime);

        // Movement

        if (transform.position.x > 1 && transform.position.x <= 1.5 && canMove)
        {
            canMoveForward = true;
            canMoveBack = true;
        }
        else if (transform.position.x > 0  && transform.position.x <= 1)
        {
            canMoveForward = false;
            canMoveBack = true;
        }
        else if (transform.position.x > 1.5 && transform.position.x <= 2)
        {
            canMoveForward = true;
            canMoveBack = false;
        }

        if ((Input.GetKeyDown(KeyCode.W)) && canMoveForward)
        {

            nextPosition = Vector3.left;
            currentDirection = Vector3.left;
            canMove = true;

        }
        if ((Input.GetKeyDown(KeyCode.S)) && canMoveBack)
        {

            nextPosition = Vector3.right;
            currentDirection = Vector3.right;
            canMove = true;

        }


        if (Vector3.Distance(destination,transform.position) <= 0.00001f)
        {
            Debug.Log("this works");

            if (canMove)
            {
                if (Valid())
                {

                    destination = transform.position + nextPosition;
                    direction = nextPosition;
                    canMove = false;
                }
            }

        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // When the player is pressing space and is on the ground
        {            
            Debug.Log("jump works");

            isGrounded = false; // The player is no longer on the ground

            StartCoroutine(JumpCoolDown()); // Player is vulnerable while jumping
        }

        bool Valid()
        {
            Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
            
           
            return true;
        }


        IEnumerator JumpCoolDown() { // When jumping
            Debug.Log("jump coroutine entered");
            isGrounded = false; // The player is in the air
            yield return new WaitForSecondsRealtime(1); // Player is invulnerable for 3 seconds
            isGrounded = true; // The player is on the ground and is vulnerable
        }

    }

}

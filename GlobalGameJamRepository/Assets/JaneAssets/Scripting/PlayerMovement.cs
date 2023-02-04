using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float upAndDownSpeed = 3; // Player's up and down speed
    public bool canMove;
    
    Vector3 up = Vector3.zero, down = new Vector3(0, 1.5f, -8), currentDirection = Vector3.zero;
    Vector3 nextPosition, destination, direction;

    float rayLength = 1f;

    public Rigidbody rigidBody;
    public Vector3 jump;
    public float jumpAmt = 2.0f;

    public bool isGrounded;
   
    void Start()
    {
        currentDirection = up;
        nextPosition = Vector3.left;
        destination = transform.position;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
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
        if ((Input.GetKeyDown(KeyCode.W))) 
        {
            nextPosition = Vector3.left;
            currentDirection = Vector3.left;
            canMove = true;
        }
        if ((Input.GetKeyDown(KeyCode.S)))
        {
            nextPosition = Vector3.right;
            currentDirection = Vector3.right;
            canMove = true;
        }

        if (Vector3.Distance(destination,transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDirection;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jump works");

            rigidBody.AddForce(jump * jumpAmt, ForceMode.Impulse);
            isGrounded = false;
        }

        bool Valid()
        {
            Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
            RaycastHit hit;

            Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

            if(Physics.Raycast(myRay,out hit,rayLength))
            {
                if(hit.collider.tag == "wall")
                {
                    return false;
                }
            }
            return true;
        }
    }

}

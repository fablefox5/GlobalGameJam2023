using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearts;
    public GameObject[] hearts;


    /*[SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
    */

    public PlayerMovement movingPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") // If the player collides with an object that is an obstacle
        {

           if (movingPlayer.isGrounded == true) // When the player is on the ground
           {
                Debug.Log("hurting");
                GameManager.instance.DecreaseHealth(); // Take damage when player is on ground
            }
           
        }
        if (other.tag == "HealthPickup")
        {
            GameManager.instance.IncreaseHealth();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour

{
    // This code goes on the Player, which will detect the health pickup item

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision) 
    {
        Debug.Log("collision happens");
        
        if (collision.tag == "HealthPickup")
        {
            Debug.Log("you picked up something!");
            Destroy(collision.gameObject);

        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    private Sprite emptyHeart;*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            GameManager.instance.DecreaseHealth();
        }
        if (other.tag == "HealthPickup")
        {
            GameManager.instance.IncreaseHealth();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int healthPoints = 3;
    [SerializeField]
    public GameObject healthScript;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void DecreaseHealth()
    {
        if (healthPoints > 0)
            healthPoints--;
    }
    public void IncreaseHealth()
    {
        if (healthPoints < numberOfHearts)
            healthPoints++;
    }
}

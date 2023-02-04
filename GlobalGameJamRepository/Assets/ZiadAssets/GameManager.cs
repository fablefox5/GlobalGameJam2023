using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int healthPoints = 3;
    [SerializeField]
    public Health healthScript;
    public enum LevelSegment {Neighborhood};

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        SceneChange(LevelSegment.Neighborhood);
    }
    public void DecreaseHealth()
    {
        if (healthPoints > 0)
        {
            healthPoints--;
            UpdateHealth();
        }
    }
    public void IncreaseHealth()
    {
        if (healthPoints < healthScript.numOfHearts)
        {
            healthPoints++;
            UpdateHealth();
        }
    }
    public void UpdateHealth()
    {
        if (healthPoints == 1)
        {
            healthScript.hearts[0].SetActive(true);
            healthScript.hearts[1].SetActive(false);
            healthScript.hearts[2].SetActive(false);
        } else if (healthPoints == 2)
        {
            healthScript.hearts[0].SetActive(true);
            healthScript.hearts[1].SetActive(true);
            healthScript.hearts[2].SetActive(false);
        } else if (healthPoints == 3)
        {
            healthScript.hearts[0].SetActive(true);
            healthScript.hearts[1].SetActive(true);
            healthScript.hearts[2].SetActive(true);
        } else
        {
            healthScript.hearts[0].SetActive(false);
            healthScript.hearts[1].SetActive(false);
            healthScript.hearts[2].SetActive(false);
        }

    }
    public void SceneChange(LevelSegment segment)
    {
        //Destroy everything in groundholder if != null
        //Instantiate two new prefabs for ground
    }
}

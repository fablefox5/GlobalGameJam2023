using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int healthPoints = 3;
    [SerializeField]
    public Health healthScript;
    public enum LevelSegment {Neighborhood};
    public Animator playerAnimator;
    public GameObject groundParent;
    public GameObject gameOver;
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    public float speedModifier = 1;
    public float acceleration;
    public float maxSpeed;

    //booleans
    public bool isHurt = false;
    public bool isDead = false;
    //public bool restart = false; //differentiates setting isdead to true for a level reset or an unpause
    
    void Update()
    {
        speedModifier += acceleration;
        if (speedModifier > maxSpeed)
        {
            speedModifier = maxSpeed;
        }
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //SceneChange(LevelSegment.Neighborhood);
    }
    public void DecreaseHealth()
    {
        if (healthPoints > 0)
        {
            healthPoints--;
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
            Debug.Log(healthPoints);
            UpdateHealth();
            if (healthPoints == 0) // When no more health
            {
                isDead = true; // Player is dead
                playerAnimator.SetBool("isDead", true);
                gameOver.SetActive(true);
            } else // When there is still health
            {
                StartCoroutine(HurtTimer()); // Start hurt timer
            }
        } else
        {
            isDead = true;
            playerAnimator.SetBool("isDead", true);
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
    public void SceneChange(LevelSegment segment) //this 
    {
        //Destroy everything in groundholder if != null
        if (groundParent.transform.childCount > 0)
        {
            for (var i = groundParent.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(groundParent.transform.GetChild(i).gameObject);
            }
        }
        if (segment == LevelSegment.Neighborhood)
        {
            //Instantiate()
        }
        //Instantiate two new prefabs for ground based on if statement
    }
    IEnumerator HurtTimer()
    {
        isHurt = true; // Player is hurt
        playerAnimator.SetBool("isHurt", true);
        yield return new WaitForSeconds(1.1f);
        isHurt = false; // Player is not hurt 
        playerAnimator.SetBool("isHurt", false);
    }
    public void ChangeIsDead()
    { //use this to pause/unpause, if dead then 0 movement
        if(isDead == true)
        {
            healthScript.movingPlayer.canMove = false;
        }
        
        isDead = !isDead;
        /*if (restart = true)
        {*/
        SceneManager.LoadScene("WorkingOnLevelChange");
        //SceneChange(LevelSegment.Neighborhood);
        /*restart = false;
    }*/
    }

    public void StartByMove()
    {
        healthScript.movingPlayer.canMove = true;
    }
}

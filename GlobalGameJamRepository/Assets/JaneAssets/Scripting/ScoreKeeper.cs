using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{

    public TextMeshProUGUI scoreText; // connect reference in inspector
    public float scoreAmount;
    public float pointIncreasedPerSecond;


    
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + (int) scoreAmount;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;        
    }
}

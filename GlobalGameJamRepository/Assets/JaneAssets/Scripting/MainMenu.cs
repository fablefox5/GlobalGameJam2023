using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    bool startGame = false;
    bool isPaused = false;
    [SerializeField] public Image imageToSwap;
    [SerializeField] public Sprite playImage;
    [SerializeField] public Sprite pauseImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CheckPause()
    {
        if (isPaused == false)
        {
           
            isPaused = true;
            Time.timeScale = 0;
            imageToSwap.overrideSprite = playImage;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            imageToSwap.overrideSprite = pauseImage;

        }
    }

    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
        startGame = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;

    }
}

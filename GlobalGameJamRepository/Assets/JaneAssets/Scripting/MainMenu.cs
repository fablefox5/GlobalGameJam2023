using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    bool startGame = false;
    bool isPaused = false;
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
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
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
        UnityEditor.EditorApplication.isPlaying = false;

    }
}

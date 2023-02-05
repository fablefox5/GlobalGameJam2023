using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slideshow : MonoBehaviour
{
    public int imageIndex = 0;
    public Image slide;
    public Sprite pic1, pic2, pic3;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            imageIndex++;
        }
        if(imageIndex == 1)
        {
            slide.overrideSprite = pic1;
        }
        else if (imageIndex == 2)
        {
            slide.overrideSprite = pic2;
        }
        else if (imageIndex == 3)
        {
            slide.overrideSprite = pic3;
        }
        else if (imageIndex > 3)
        {
            SceneManager.LoadScene(2);
        }
    }
    IEnumerator begin()
    {
       
        yield return null;
    }
}

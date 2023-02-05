using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carHONK : MonoBehaviour
{
    public AudioSource carNoise;
    // Start is called before the first frame update
    void Start()
    {
        carNoise.PlayDelayed(6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
        

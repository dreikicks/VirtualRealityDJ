using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource audioSource2;

    public bool ispressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayPause()
    {
        if(!ispressed){
            audioSource2.Play();
            ispressed = true;
        }
        else
        {
            audioSource2.Pause();
            ispressed = false;
        }
        
    }
}

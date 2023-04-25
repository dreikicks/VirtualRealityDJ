using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public ButtonChangeColor buttonPlayPause;

    public AudioSource audioSource2;

    //public GameObject imageactived;
    public GameObject imagenoactived;

    public bool ispressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     ispressed = buttonPlayPause.playPausePressed;

    //     if(ispressed)
    //     {
    //         //imageactived.SetActive(true);
            
    //     }
        
    //     /*if(!ispressed)
    //     {
    //         imagenoactived.SetActive(true);
    //         imageactived.SetActive(false);
    //         audioSource.Pause();
    //     }*/
    // }

    public void PlayPause()
    {
        if(!ispressed){
            imagenoactived.SetActive(false);
            audioSource2.Play();
            ispressed = true;
        }
        else
        {
            imagenoactived.SetActive(true);
            audioSource2.Pause();
            ispressed = false;
        }
        
    }
}

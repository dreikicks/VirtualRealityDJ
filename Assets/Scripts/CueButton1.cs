using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CueButton1 : MonoBehaviour
{
    public AudioSource audioSource;
    //public float loopTime;

    private int loopStartSamples;
    //private Coroutine loopCoroutine;
    //private int loopEndSamples;

    public bool haveMark = false;
    //public bool ableToCue = false;

    //public AudioManagement PlayPause;

    void Update()
    {
        
    }

    public void StartCue()
    {
        if(!haveMark)
        {
            loopStartSamples = audioSource.timeSamples;
            haveMark = true;
        } else {
            audioSource.timeSamples = loopStartSamples;
        }
    }

    /*public void StopCue()
    {
        if(haveMark)
        {
            audioSource.Pause();
            audioSource.timeSamples = loopStartSamples;
        }
        if(ableToCue)
        {
            haveMark = true;
            ableToCue = false;
        }
    }*/

    public void DeleteMark()
    {
        haveMark = false;
    }

    
}
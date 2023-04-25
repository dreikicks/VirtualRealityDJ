using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class PitchManager2 : MonoBehaviour
{
    public Transform sliderpitch1;
    public AudioSource AudioSource;
    public AudioMixer masterMix;

    public float xMin = 0.4f;
    public float xMax = 0.2f;

    public float fMin = 0.5f;
    public float fMax = 1.5f;

    public float range;

    //float step = 0.1f;

    //float f;

    public ScratchEffect2 scratchEffect2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = sliderpitch1.transform.localPosition.z;

        float t = (x - xMin) / (xMax - xMin);

        range = Mathf.Lerp (fMin, fMax, t);

        //f = Mathf.Floor (range / step) * step;

        if(!scratchEffect2.scratchActivated){
            AudioSource.pitch = range;
            masterMix.SetFloat ("Pitch2", 1f / range);
        }
    }
}
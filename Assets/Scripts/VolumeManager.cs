using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class VolumeManager : MonoBehaviour
{
    public Transform slider1;
    public AudioMixer masterMix;

    float volumelevel;

    public float xMin = 0.4f;
    public float xMax = 0.2f;

    public float fMin = -20f;
    public float fMax = 20f;

    //float step = 0.1f;

    //float f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        masterMix.SetFloat ("Volume1", volumelevel);

        float x = slider1.transform.localPosition.z;

        float t = (x - xMin) / (xMax - xMin);

        float range = Mathf.Lerp (fMin, fMax, t);

        //f = Mathf.Floor (range / step) * step;

        volumelevel = range;
    }
}

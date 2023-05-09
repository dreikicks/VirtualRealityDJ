using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class DecayDry2 : MonoBehaviour
{
    //public Transform slider1;
    public AudioMixer masterMix;

    float distortionlevel;

    //public float xMin = 0.03f;
    //public float xMax = -0.37f;

    public float x;

    public float xMin = -120f;
    public float xMax = 120f;

    public float fMin = 0f;
    public float fMax = 1f;

    //float step = 0.1f;

    float f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0f, -120f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        masterMix.SetFloat ("Distortion2", distortionlevel);

        //float x = slider1.transform.localPosition.z;

        if(transform.localRotation.eulerAngles.y <= 180f)
        {
            x = transform.localRotation.eulerAngles.y;
        }
        else
        {
            x = transform.localRotation.eulerAngles.y - 360f;
        }

        float t = (x - xMin) / (xMax - xMin);

        float range = Mathf.Lerp (fMin, fMax, t);

        //f = Mathf.Floor (range / step) * step;

        distortionlevel = range;
    }
}
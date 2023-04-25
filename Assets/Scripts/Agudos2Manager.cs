using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Agudos2Manager : MonoBehaviour
{
    //public Transform rotator1;
    public AudioMixer masterMix;

    float agudoslevel;

    //public float xMin = 0.03f;
    //public float xMax = -0.37f;

    public float x;

    public float xMin = -120f;
    public float xMax = 120f;

    public float fMin = 500f;
    public float fMax = 9500f;

    //float step = 0.1f;

    float f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        masterMix.SetFloat ("Agudos2", agudoslevel);

        //float x = slider1.transform.localPosition.z;

        //x = transform.localRotation.eulerAngles.y;

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

        agudoslevel = range;
    }
}


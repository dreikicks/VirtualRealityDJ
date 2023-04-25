using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Medios1Manager : MonoBehaviour
{
    public AudioMixer masterMix;

    float medioslevel;

    public float x;

    public float xMin = 240f;
    public float xMax = 120f;

    public float fMin = 0.5f;
    public float fMax = 1.5f;

    float f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        masterMix.SetFloat ("Medios1", medioslevel);

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

        medioslevel = range;
    }
}

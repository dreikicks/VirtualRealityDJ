using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class CrossManager : MonoBehaviour
{
    public Transform slider;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    public float xMin1 = 0.1375f;
    public float xMax1 = -0.0625f;

    public float xMin2 = -0.0625f;
    public float xMax2 = 0.1375f;

    public float fMin = 0f;
    public float fMax = 1f;

    //float step = 0.1f;

    //float f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = slider.transform.localPosition.x;

        float t1 = (x - xMin1) / (xMax1 - xMin1);
        float t2 = (x - xMin2) / (xMax2 - xMin2);

        float range1 = Mathf.Lerp (fMin, fMax, t1);
        float range2 = Mathf.Lerp (fMin, fMax, t2);

        //f = Mathf.Floor (range / step) * step;

        AudioSource1.volume = range1;
        AudioSource2.volume = range2;
    }
}

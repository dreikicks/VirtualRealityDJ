using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class VolumeManager2 : MonoBehaviour
{
    public Transform slider2;
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
        slider2.transform.localPosition = new Vector3(slider2.transform.localPosition.x, slider2.transform.localPosition.y, 0.32f);
    }

    // Update is called once per frame
    void Update()
    {
        masterMix.SetFloat ("Volume2", volumelevel);

        float x = slider2.transform.localPosition.z;

        float t = (x - xMin) / (xMax - xMin);

        float range = Mathf.Lerp (fMin, fMax, t);

        //f = Mathf.Floor (range / step) * step;

        volumelevel = range;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class ScratchEffect1 : MonoBehaviour
{
    public float scratchIntensity = 1.0f;
    public AudioSource audioSource;

    public float previousRotation;
    public float currentRotation;
    public float rotationDelta;

    public float resultPitch;

    public PitchManager1 pitchManager1;

    public bool scratchActivated = false;

    void Start()
    {
        previousRotation = transform.localEulerAngles.y;
    }

    void Update()
    {
        currentRotation = transform.localEulerAngles.y;
        rotationDelta = currentRotation - previousRotation;
        previousRotation = currentRotation;

        // Aplicar efecto de scratch en funcion de la rotacion del cilindro
        if (audioSource.isPlaying)
        {
            float pitchShift = Mathf.Clamp(rotationDelta, -1f, 1f) * scratchIntensity;
            resultPitch = Mathf.Clamp(audioSource.pitch + pitchShift, 0.5f, 2.0f);
            audioSource.pitch = resultPitch;
        }
        
        if(rotationDelta != 0)
        {
            scratchActivated = true;
        }else
        {
            scratchActivated = false;
            audioSource.pitch = pitchManager1.range;
        }
    }

    public void OnScratchSelect()
    {
        //scratchActivated = true;
    }

    public void OnScratchDesSelect()
    {
        //scratchActivated = false;
    }
}


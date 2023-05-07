using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class ScratchEffect1 : MonoBehaviour
{
    public float scratchIntensity = 1.0f;
    public float scratchDefIntensity = 0.5f;
    public AudioSource audioSource;

    public bool scratchDefOn = false;

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
        if (!scratchDefOn) {
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
        } else 
        {
            int sampleShift = Mathf.RoundToInt(rotationDelta * scratchDefIntensity * audioSource.clip.frequency);
            int newSamplePosition = Mathf.Clamp(audioSource.timeSamples + sampleShift, 0, audioSource.clip.samples);
            audioSource.timeSamples = newSamplePosition;
        }
        
    }

    public void OnScratchDefOn()
    {
        scratchDefOn = true;
    }

    public void OnScratchDefOff()
    {
        scratchDefOn = false;
    }
}


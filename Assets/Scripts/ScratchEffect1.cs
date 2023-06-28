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
    public AudioMixer masterMix;

    public bool scratchDefOn = false;

    public float previousRotation;
    public float currentRotation;
    public float rotationDelta;

    public float resultPitch;

    public PitchManager1 pitchManager1;

    public bool scratchActivated = false;


    public float rotationSpeedThreshold = 1f;
    public float timeStep = 0.05f;

    private float previousRotation2;
    private float currentRotation2;
    private float currentVelocity2;

    void Start()
    {
        previousRotation = transform.localEulerAngles.y;
    }

    void FixedUpdate()
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
                masterMix.SetFloat ("Pitch1", 1f / resultPitch);
            }
        
            if(rotationDelta != 0)
            {
                scratchActivated = true;
            }else
            {
                scratchActivated = false;
                audioSource.pitch = pitchManager1.range;
                masterMix.SetFloat ("Pitch1", 1f / pitchManager1.range);
            }
        } else
        {
            //int sampleShift = Mathf.RoundToInt(rotationDelta * scratchDefIntensity * audioSource.clip.frequency);
            //int newSamplePosition = Mathf.Clamp(audioSource.timeSamples + sampleShift, 0, audioSource.clip.samples);
            //audioSource.timeSamples = newSamplePosition;

            currentRotation2 = transform.eulerAngles.y;
            float rotationDelta2 = Mathf.DeltaAngle(currentRotation2, previousRotation2);
            currentVelocity2 = rotationDelta2 / Time.deltaTime;

            // Calcular la direccion del movimiento del punto de reproduccion
            float direction = Mathf.Sign(currentVelocity2);
            float magnitude = Mathf.Abs(currentVelocity2);

            // Mover el punto de reproduccion del AudioSource
            if (magnitude > rotationSpeedThreshold)
            {
                float newTime = audioSource.time + (-direction) * timeStep;
                audioSource.time = Mathf.Clamp(newTime, 0, audioSource.clip.length);
            }

            // Actualizar la rotacion anterior del cilindro
            previousRotation2 = currentRotation2;
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopClip : MonoBehaviour
{
    public AudioSource audioSource;
    public float loopTime;

    private int loopStartSamples;
    private Coroutine loopCoroutine;
    private int loopEndSamples;

    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        textMeshPro.text = loopTime.ToString();
    }

    private IEnumerator LoopAudio()
    {
        loopEndSamples = loopStartSamples + Mathf.RoundToInt(loopTime * audioSource.clip.frequency);

        while (true)
        {
            if (audioSource.timeSamples >= loopEndSamples)
            {
                audioSource.timeSamples = loopStartSamples;
            }

            yield return null;
        }
    }

    public void StartLoop()
    {
        loopStartSamples = audioSource.timeSamples;
        loopCoroutine = StartCoroutine(LoopAudio());
    }

    public void StopLoop()
    {
        if (loopCoroutine != null)
        {
            StopCoroutine(loopCoroutine);
            loopCoroutine = null;
            //audioSource.timeSamples = loopStartSamples;
        }
    }

    public void MoreTimeLoop()
    {
        if(loopTime == 8f){
            loopTime = 8f;
        }
        if(loopTime == 6f){
            loopTime = 8f;
        }
        if(loopTime == 4f){
            loopTime = 6f;
        }
        if(loopTime == 2f){
            loopTime = 4f;
        }
        if(loopTime == 1f){
            loopTime = 2f;
        }
        if(loopTime == 0.5f){
            loopTime = 1f;
        }
        if(loopTime == 0.25f){
            loopTime = 0.5f;
        }
        if(loopTime == 0.1f){
            loopTime = 0.25f;
        }
    }

    public void LessTimeLoop()
    {
        if(loopTime == 0.1f){
            loopTime = 0.1f;
        }
        if(loopTime == 0.25f){
            loopTime = 0.1f;
        }
        if(loopTime == 0.5f){
            loopTime = 0.25f;
        }
        if(loopTime == 1f){
            loopTime = 0.5f;
        }
        if(loopTime == 2f){
            loopTime = 1f;
        }
        if(loopTime == 4f){
            loopTime = 2f;
        }
        if(loopTime == 6f){
            loopTime = 4f;
        }
        if(loopTime == 8f){
            loopTime = 6f;
        }
    }
}

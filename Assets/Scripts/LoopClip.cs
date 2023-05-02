using System.Collections;
using UnityEngine;

public class LoopClip : MonoBehaviour
{
    public AudioSource audioSource;
    public float loopTime;

    private int loopStartSamples;
    private Coroutine loopCoroutine;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private IEnumerator LoopAudio()
    {
        int loopEndSamples = loopStartSamples + Mathf.RoundToInt(loopTime * audioSource.clip.frequency);

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
}

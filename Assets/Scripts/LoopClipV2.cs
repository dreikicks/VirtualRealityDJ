using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopClipV2 : MonoBehaviour
{
    public AudioSource audioSource;
    public float loopTime;

    private int loopStartSamples;
    private Coroutine loopCoroutine;
    private int loopEndSamples;

    public TextMeshProUGUI textMeshPro;

    public float tiempoInicial = 0f;
    public float tiempoTranscurrido = 0f;
    public bool contadorActivo = false;

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

        if (contadorActivo)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
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

    public void IniciarContador()
    {
        contadorActivo = true;
        loopStartSamples = audioSource.timeSamples;
    }

    public void DetenerContador()
    {
        contadorActivo = false;
        loopTime = tiempoTranscurrido;

        loopCoroutine = StartCoroutine(LoopAudio());
    }

    /*public void StartLoop()
    {
        loopStartSamples = audioSource.timeSamples;
        loopCoroutine = StartCoroutine(LoopAudio());
    }*/

    public void StopLoop()
    {
        if (loopCoroutine != null)
        {
            StopCoroutine(loopCoroutine);
            loopCoroutine = null;
            tiempoInicial = 0f;
            tiempoTranscurrido = 0f;
            loopTime = 0f;
        }
    }

    public void MoreTimeLoop()
    {
        loopTime = loopTime * 2;
        StopCoroutine(loopCoroutine);
        loopCoroutine = null;

        loopStartSamples = audioSource.timeSamples;
        loopCoroutine = StartCoroutine(LoopAudio());
    }

    public void LessTimeLoop()
    {
        loopTime = loopTime / 2;
        StopCoroutine(loopCoroutine);
        loopCoroutine = null;

        loopStartSamples = audioSource.timeSamples;
        loopCoroutine = StartCoroutine(LoopAudio());
    }
}

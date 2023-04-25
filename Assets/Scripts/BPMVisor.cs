using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class BPMVisor : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TextMeshProUGUI bpmText;
    private const string BpmParameter = "BPM";

    void Update()
    {
        float bpmValue;
        if (audioMixer.GetFloat(BpmParameter, out bpmValue))
        {
            bpmText.text = bpmValue.ToString();
        }
    }
}




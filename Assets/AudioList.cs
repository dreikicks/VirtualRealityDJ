using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Audio List", menuName = "Audio List")]
public class AudioList : ScriptableObject
{
    public AudioClip[] audioClips;

    /*public AudioClip GetRandomClip()
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        return audioClips[randomIndex];
    }*/
}

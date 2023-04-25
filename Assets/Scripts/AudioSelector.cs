using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioSelector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioList audioList;
    private AudioClip selectedClip;
    public TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener(delegate {ChangeAudioClip();});
        //dropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (AudioClip clip in audioList.audioClips)
        {
            options.Add(clip.name);
        }

        dropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAudioClip()
    {
        selectedClip = audioList.audioClips[dropdown.GetComponent<TMP_Dropdown>().value];
        audioSource.clip = selectedClip;
        //audioSource.Play();
    }
}

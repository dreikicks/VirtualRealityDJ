using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    private void Update()
    {
        float progress = audioSource.time / audioSource.clip.length;

        slider.value = progress;
    }
}


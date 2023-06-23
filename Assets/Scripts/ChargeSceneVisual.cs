using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeSceneVisual : MonoBehaviour
{
    public GameObject CanvasCharging;
    public GameObject CanvasButtons;

    public Slider slider;

    public ChangeSceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = sceneManager.charging;
    }

    public void StartChargingScene()
    {
        CanvasButtons.SetActive(false);
        CanvasCharging.SetActive(true);
    }
}

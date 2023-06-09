using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OpenPauseController : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayPauseMenu();
        }
    }

    public void DisplayPauseMenu()
    {
        if(!isPaused)
        {
            pauseCanvas.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }else if(isPaused)
        {
            pauseCanvas.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}

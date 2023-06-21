using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OpenPauseControllerEntrance : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseCanvas;
    public GameObject mainMenuCanvas;

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
            mainMenuCanvas.SetActive(false);
            isPaused = true;
            Time.timeScale = 0;
        }else if(isPaused)
        {
            pauseCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DisableReturnCanvas : MonoBehaviour
{
    public Canvas canvasToDisable;
    public OpenPauseController openPauseController;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        canvasToDisable.gameObject.SetActive(false);
        Time.timeScale = 1f;
        openPauseController.isPaused = false;
    }
}

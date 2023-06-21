using UnityEngine;
using UnityEngine.UI;

public class DisableQuitCanvas : MonoBehaviour
{
    public Canvas canvasToDisable;
    public Canvas canvasToActivate;
    public OpenPauseControllerEntrance openPauseControllerEntrance;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        canvasToDisable.gameObject.SetActive(false);
        canvasToActivate.gameObject.SetActive(true);
        Time.timeScale = 1f;
        openPauseControllerEntrance.isPaused = false;
    }
}

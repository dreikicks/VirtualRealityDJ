using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public float timer;

    public float charging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void ChangeToEntrance()
    // {
    //     Time.timeScale = 1;
    //     SceneManager.LoadScene(0);
    // }

    // public void ChangeToPrivate()
    // {
    //     SceneManager.LoadScene(1);
    // }

    // public void ChangeToMixed()
    // {
    //     SceneManager.LoadScene(2);
    // }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StartEntrance()
    {
        StartCoroutine(ChangeToEntrance());
    }

    public void StartPrivate()
    {
        StartCoroutine(ChangeToPrivate());
    }

    public void StartMixed()
    {
        StartCoroutine(ChangeToMixed());
    }

    IEnumerator ChangeToEntrance()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        timer = 0;
        while(!operation.isDone && operation.progress < 0.9f)
        {
            timer += Time.deltaTime;
            Debug.Log(operation.progress);
            Debug.Log(timer);
            yield return null;
        }
        Time.timeScale = 1;
        operation.allowSceneActivation = true;
        timer = 0;
    }

    IEnumerator ChangeToPrivate()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        timer = 0;
        while(!operation.isDone && operation.progress < 0.9f)
        {
            charging = operation.progress;
            timer += Time.deltaTime;
            Debug.Log(operation.progress);
            Debug.Log(timer);
            yield return null;
        }

        operation.allowSceneActivation = true;
        timer = 0;
    }

    IEnumerator ChangeToMixed()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        timer = 0;
        while(!operation.isDone && operation.progress < 0.9f)
        {
            charging = operation.progress;
            timer += Time.deltaTime;
            Debug.Log(operation.progress);
            Debug.Log(timer);
            yield return null;
        }

        operation.allowSceneActivation = true;
        timer = 0;
    }
}

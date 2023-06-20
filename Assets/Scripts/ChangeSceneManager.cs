using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToEntrance()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToPrivate()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToMixed()
    {
        SceneManager.LoadScene(2);
    }
}

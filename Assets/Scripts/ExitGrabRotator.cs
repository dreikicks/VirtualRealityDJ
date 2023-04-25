using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGrabRotator : MonoBehaviour
{
    public Transform handler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitHandler()
    {
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
    }
}

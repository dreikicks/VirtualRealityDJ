using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonLoopClipV2 : MonoBehaviour
{
    public UnityEvent StartCounter = null;
    public UnityEvent StopCounterStartLoop = null;
    public UnityEvent EndLoop = null;

    public Material selectMaterial = null;
    public Material loopMaterial = null;

    public bool playPausePressed;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    public bool allowToStartCounter = true;
    public bool allowToEndCounter = false;
    public bool allowtoEndLoop = false;

    public bool counterIsActive = false;
    public bool loopIsActive = false;

    //public ButtonChangeColor2 ChangeColorScript;
    //public ButtonChangeColor2 ChangeColorScript2;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(SetSelectMaterial);
        interactable.onHoverExited.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy()
    {
        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        if(allowToStartCounter)
        {
            meshRenderer.material = selectMaterial;

            StartCounter.Invoke();
            counterIsActive = true;
        }
        if(allowToEndCounter)
        {
            meshRenderer.material = loopMaterial;

            StopCounterStartLoop.Invoke();
            counterIsActive = false;
            loopIsActive = true;
        }
        if(allowtoEndLoop)
        {
            meshRenderer.material = originalMaterial;

            EndLoop.Invoke();
            loopIsActive = false;
        }
        

    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        if(counterIsActive)
        {
            allowToStartCounter = false;
            allowToEndCounter = true;
        }
        if(!counterIsActive)
        {
            allowtoEndLoop = true;
            allowToEndCounter = false;
        }
        if(!loopIsActive && !counterIsActive)
        {
            allowtoEndLoop = false;
            allowToStartCounter = true;
        }
        
    }
}

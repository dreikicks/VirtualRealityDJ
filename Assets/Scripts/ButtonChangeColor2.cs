using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonChangeColor2 : MonoBehaviour
{
    public UnityEvent OnLoopEnter = null;
    public UnityEvent OnLoopExit = null;
    public Material selectMaterial = null;

    public bool playPausePressed;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    public bool allowToStartLoop = true;
    public bool loopIsActive = false;
    public bool allowToEndLoop = false;

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
        if(allowToStartLoop)
        {
            meshRenderer.material = selectMaterial;

            OnLoopEnter.Invoke();
            loopIsActive = true;
        }
        if(allowToEndLoop)
        {
            meshRenderer.material = originalMaterial;

            OnLoopExit.Invoke();
            loopIsActive = false;
        }
        

    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        if(loopIsActive)
        {
            allowToStartLoop = false;
            allowToEndLoop = true;
        }
        if(!loopIsActive)
        {
            allowToStartLoop = true;
            allowToEndLoop = false;
        }
        
    }
}

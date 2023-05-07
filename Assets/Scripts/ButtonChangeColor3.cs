using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonChangeColor3 : MonoBehaviour
{
    public UnityEvent OnScratchEnter = null;
    public UnityEvent OnScratchExit = null;
    public Material selectMaterial = null;

    public bool playPausePressed;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    public bool allowToStartScratch = true;
    public bool scratchIsActive = false;
    public bool allowToEndScratch = false;


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
        if(allowToStartScratch)
        {
            meshRenderer.material = selectMaterial;

            OnScratchEnter.Invoke();
            scratchIsActive = true;
        }
        if(allowToEndScratch)
        {
            meshRenderer.material = originalMaterial;

            OnScratchExit.Invoke();
            scratchIsActive = false;
        }
        

    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        if(scratchIsActive)
        {
            allowToStartScratch = false;
            allowToEndScratch = true;
        }
        if(!scratchIsActive)
        {
            allowToStartScratch = true;
            allowToEndScratch = false;
        }
        
    }

}
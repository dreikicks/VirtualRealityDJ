using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonDeleteMark : MonoBehaviour
{
    public UnityEvent OnPress = null;
    public Material selectMaterial = null;

    public bool playPausePressed;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    public CueButton1 cueButton;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(SetSelectMaterial);
        interactable.onHoverExited.AddListener(SetOriginalMaterial);
    }

    void Update() 
    {
        if(cueButton.haveMark)
        {
            meshRenderer.material = selectMaterial;
        } else if (cueButton.haveMark == false)
        {
            meshRenderer.material = originalMaterial;
        }
    }

    private void OnDestroy()
    {
        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        //meshRenderer.material = selectMaterial;

        OnPress.Invoke();
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        //meshRenderer.material = originalMaterial;
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SciFiPistolVisuals : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private XRGrabInteractable xrGrabInteractable;

    private void Awake()
    {
        if (xrGrabInteractable == null)
        {
            xrGrabInteractable = transform.parent.GetComponent<XRGrabInteractable>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (xrGrabInteractable != null)
        {
            xrGrabInteractable.activated.AddListener(OnActivated_StartShooting);
            xrGrabInteractable.deactivated.AddListener(OnDeactivated_StopShooting);
        }
    }

    private void OnDisable()
    {
        if (xrGrabInteractable != null)
        {
            xrGrabInteractable.activated.RemoveListener(OnActivated_StartShooting);
            xrGrabInteractable.deactivated.RemoveListener(OnDeactivated_StopShooting);
        }
    }

    private void OnActivated_StartShooting(ActivateEventArgs arg0)
    {
        if (particles != null && !particles.isPlaying)
        {
            particles.Play();
        }
    }
    
    //
    private void OnDeactivated_StopShooting(DeactivateEventArgs args)
    {
        if (particles != null)
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}

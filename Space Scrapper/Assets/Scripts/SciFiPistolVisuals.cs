using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SciFiPistolVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable xrGrabInteractable = transform.parent.GetComponent<XRGrabInteractable>();
        xrGrabInteractable.activated.AddListener(OnActivated_StartShooting);
        xrGrabInteractable.deactivated.AddListener(OnDeactivated_StopShooting);
    }

    //
    private void OnActivated_StartShooting(ActivateEventArgs args)
    {
        particles.Play();
    }
    
    //
    private void OnDeactivated_StopShooting(DeactivateEventArgs args)
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}

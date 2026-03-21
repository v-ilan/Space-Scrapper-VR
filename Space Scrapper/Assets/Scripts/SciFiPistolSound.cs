using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SciFiPistolSound : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrGrabInteractable;
    [SerializeField] private AudioSource audioSource;

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

    private void OnActivated_StartShooting(ActivateEventArgs arg0)
    {
        audioSource.Play();
    }

    private void OnDeactivated_StopShooting(DeactivateEventArgs arg0)
    {
        audioSource.Stop();
    }
}

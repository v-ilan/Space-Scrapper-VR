using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SciFiPistol : MonoBehaviour
{

    [SerializeField] Transform shootSource;
    [SerializeField] LayerMask breakableLayerMask;
    private float shootingDistance = 1.5f;
    private bool isShooting = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable xrGrabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        xrGrabInteractable.activated.AddListener(OnActivated_StartShooting);
        xrGrabInteractable.deactivated.AddListener(OnDeactivated_StopShooting);
    }

    //
    private void Update()
    {
        if(isShooting)
        {
            RaycastCheck();
        }
    }

    //
    private void OnActivated_StartShooting(ActivateEventArgs args)
    {
        isShooting = true;
    }
    
    //
    private void OnDeactivated_StopShooting(DeactivateEventArgs args)
    {
        isShooting = false;
    }

    private void RaycastCheck()
    {
        if(Physics.Raycast(shootSource.position, shootSource.forward, out RaycastHit hit, shootingDistance, breakableLayerMask))
        {   //hit an object on a breakable layer
            if (hit.collider.TryGetComponent(out IBreakable breakable)) 
            {   //object is IBreakable
                breakable.Break();
            }
        }
    }
}

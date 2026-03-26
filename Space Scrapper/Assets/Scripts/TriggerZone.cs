using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public UnityEvent OnZoneTriggered; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out XROrigin xrOrigin))
        {
            OnZoneTriggered?.Invoke();
        }
    }
}

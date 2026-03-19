using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class EnergySocketInteractor : XRSocketInteractor
{
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        // First, check if the base XRI logic (Layers, etc.) allows it
        if (!base.CanHover(interactable)) return false;

        // Then, check for our specific "Professional" component
        return interactable.transform.TryGetComponent<EnergySource>(out _);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.TryGetComponent<EnergySource>(out _);
    }
}

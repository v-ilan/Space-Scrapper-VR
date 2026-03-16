using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}

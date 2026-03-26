using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class TrashCan : MonoBehaviour
{
    //public event EventHandler OnObjectTrashed;
    private NarrativeTrigger narrativeTrigger;

    private void Start()
    {
        narrativeTrigger = GetComponent<NarrativeTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<XRGrabInteractable>() != null)
        {
            other.gameObject.SetActive(false);
            narrativeTrigger.TriggerStep();
        }
    }
}

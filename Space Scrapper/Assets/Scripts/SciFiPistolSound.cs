using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(AudioSource))]
public class SciFiPistolSound : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrGrabInteractable;
    private AudioSource audioSource;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (xrGrabInteractable == null)
        {
            xrGrabInteractable = transform.parent.GetComponent<XRGrabInteractable>();
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.OnVolumeChange += SoundManager_OnVolumeChange;
        UpdateVolume();
    }

    void OnEnable()
    {
        xrGrabInteractable.activated.AddListener(OnActivated_StartShooting);
        xrGrabInteractable.deactivated.AddListener(OnDeactivated_StopShooting);
    }

    void OnDisable()
    {
        xrGrabInteractable.activated.RemoveListener(OnActivated_StartShooting);
        xrGrabInteractable.deactivated.RemoveListener(OnDeactivated_StopShooting);
    }
    
    private void SoundManager_OnVolumeChange(object sender, EventArgs e)
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        sfxVolume = SoundManager.Instance.GetVolume();
        audioSource.volume = sfxVolume;
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

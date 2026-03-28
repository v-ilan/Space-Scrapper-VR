using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSound : MonoBehaviour
{
    [SerializeField] private OpenDoor openDoor;
    private AudioSource audioSource;

    private void Awake()
    {
        if (openDoor == null) 
        {
            openDoor = GetComponentInParent<OpenDoor>();
        }
        audioSource = GetComponent<AudioSource>();
        
        // 3D spatialization
        audioSource.spatialBlend = 1.0f; 
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void OnEnable()
    {
        openDoor.OnDoorToggle += DoorController_OnDoorStateChanged;

        SoundManager.Instance.OnVolumeChange += SoundManager_OnVolumeChange;
        UpdateVolume();
    }

    void OnDisable()
    {
        openDoor.OnDoorToggle -= DoorController_OnDoorStateChanged;
        SoundManager.Instance.OnVolumeChange -= SoundManager_OnVolumeChange;
    }

    private void DoorController_OnDoorStateChanged(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void SoundManager_OnVolumeChange(object sender, System.EventArgs e) => UpdateVolume();
    private void UpdateVolume() => audioSource.volume = SoundManager.Instance.GetVolume();
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NarativeManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private List<NarrativeStepSO> storyFlow;

    private void OnEnable()
    {
        foreach (var step in storyFlow)
        {
            // Resetting for a fresh play session
            step.ResetStep(); 
            step.OnStepActivated += HandleStepActivated;
        }
    }

    private void OnDisable()
    {
        foreach (var step in storyFlow)
        {
            step.OnStepActivated -= HandleStepActivated;
        }
    }
    
    private void HandleStepActivated(object sender, EventArgs e)
    {
        if (sender is NarrativeStepSO step)
        {
            PlaySequence(step);
        }
    }

    private void PlaySequence(NarrativeStepSO step)
    {
        director.Stop();
        director.time = step.startTime;
        director.Play();
    }
}

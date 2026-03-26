using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    [SerializeField] private NarrativeStepSO stepToTrigger;

    public void TriggerStep()
    {
        stepToTrigger.Activate();
    }
}

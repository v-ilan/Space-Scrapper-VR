using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
using System.Linq;

public class NarrativeTrigger : MonoBehaviour
{
    [Header("Narrative Data")]
    [SerializeField] private NarrativeStepSO stepToTrigger;

    // This runs whenever you change something in the Inspector
    private void OnValidate()
    {
#if UNITY_EDITOR
        // Delaying the check slightly prevents annoying warnings while Unity is still compiling/loading
        UnityEditor.EditorApplication.delayCall += () =>
        {
            if (this == null) return; // Safety check in case object was deleted
            
            bool isLinkedToEvent = CheckIfLinked();
            
            if (!isLinkedToEvent)
            {
                Debug.LogWarning($"<color=orange>[Narrative Warning]</color> {gameObject.name} has a NarrativeTrigger but is NOT linked to any UnityEvent!", this);
            }
        };
#endif
    }

#if UNITY_EDITOR
    private bool CheckIfLinked()
    {
        // Get all components on this GameObject
        var components = GetComponents<Component>();

        foreach (var comp in components)
        {
            if (comp == null || comp == this) continue;

            // 1. Convert the component into raw Inspector data
            UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(comp);
            UnityEditor.SerializedProperty prop = so.GetIterator();
            
            // 2. Iterate through EVERY serialized field, no matter how deep it is nested
            // prop.Next(true) tells it to dig into structs and arrays (which XRI uses heavily)
            while (prop.Next(true))
            {
                // 3. UnityEvents store the method they are calling as a string
                if (prop.propertyType == UnityEditor.SerializedPropertyType.String)
                {
                    if (prop.stringValue == nameof(TriggerStep))
                    {
                        return true; // We found the link!
                    }
                }
            }
        }
        return false;
    }
#endif

    public void TriggerStep()
    {
        stepToTrigger.Activate();
    }
}

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class LocomotionSetupManager : MonoBehaviour
{
    [SerializeField] private LocomotionSettingsSO settings;

    [Header("Provider References")]
    [SerializeField] private ContinuousMoveProvider continuousMove;
    [SerializeField] private TeleportationProvider teleportMove;
    [SerializeField] private SnapTurnProvider snapTurn;
    [SerializeField] private ContinuousTurnProvider continuousTurn;

    private void OnEnable()
    {
        if (settings != null)
            settings.OnSettingsChanged += ApplySettings;
        
        ApplySettings(this, EventArgs.Empty);
    }

    private void OnDisable()
    {
        if (settings != null)
            settings.OnSettingsChanged -= ApplySettings;
    }

    private void ApplySettings(object sender, EventArgs e)
    {
        if (settings == null) return;

        // 1. Movement Logic
        bool isContinuous = settings.movementType == LocomotionSettingsSO.MoveType.Continuous;
        continuousMove.enabled = isContinuous;
        teleportMove.enabled = !isContinuous;
        
        if (isContinuous)
            continuousMove.moveSpeed = settings.moveSpeed;

        // 2. Turning Logic
        bool isSnap = settings.turnType == LocomotionSettingsSO.TurnType.Snap;
        snapTurn.enabled = isSnap;
        continuousTurn.enabled = !isSnap;

        if (isSnap)
            snapTurn.turnAmount = settings.snapAngle;
        else
            continuousTurn.turnSpeed = settings.turnSpeed;
            
        // Note: The Locomotion Mediator in XRI 3.x automatically ignores 
        // disabled providers, so toggling .enabled is sufficient!
    }
}

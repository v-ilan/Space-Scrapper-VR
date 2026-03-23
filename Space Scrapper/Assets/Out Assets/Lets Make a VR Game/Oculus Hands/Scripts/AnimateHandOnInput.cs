using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandOnInput : MonoBehaviour
{
    [Header("Input References")]
    [SerializeField] private InputActionReference pinchAction;
    [SerializeField] private InputActionReference gripAction;

    private Animator _handAnimator;
    
    // Cache String IDs - Use Hash instead of String for 2x faster Animator updates
    private static readonly int TriggerHash = Animator.StringToHash("Trigger");
    private static readonly int GripHash = Animator.StringToHash("Grip");

    private void Awake()
    {
        _handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Subscribe to events instead of using Update() - This only fires when the value actually changes
        pinchAction.action.performed += OnPinchUpdate;
        pinchAction.action.canceled += OnPinchUpdate;

        gripAction.action.performed += OnGripUpdate;
        gripAction.action.canceled += OnGripUpdate;
    }

    private void OnDisable()
    {
        //Clean up to prevent memory leaks
        pinchAction.action.performed -= OnPinchUpdate;
        pinchAction.action.canceled -= OnPinchUpdate;

        gripAction.action.performed -= OnGripUpdate;
        gripAction.action.canceled -= OnGripUpdate;
    }

    private void OnPinchUpdate(InputAction.CallbackContext context)
    {
        _handAnimator.SetFloat(TriggerHash, context.ReadValue<float>());
    }

    private void OnGripUpdate(InputAction.CallbackContext context)
    {
        _handAnimator.SetFloat(GripHash, context.ReadValue<float>());
    }
}

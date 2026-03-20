using System;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OutsideSpaceController : MonoBehaviour
{
    [SerializeField] private Transform lever;
    [SerializeField] private Transform wheel;
    [SerializeField] private Transform joystick;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private XRLever xRLever;
    private XRKnob xRWheelKnob;
    private XRJoystick xRJoystick;

    private bool isDrive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!lever.TryGetComponent<XRLever>(out xRLever))
        {
            Debug.LogError("No XRLever on lever " + lever.name);
        }
        if(!wheel.TryGetComponent<XRKnob>(out xRWheelKnob))
        {
            Debug.LogError("No XRKnob on wheel " + wheel.name);
        }
        if(!joystick.TryGetComponent<XRJoystick>(out xRJoystick))
        {
            Debug.LogError("No XRJoystick on joystick " + joystick.name);
        }

        xRLever.onLeverActivate.AddListener(StartDriving);
        xRLever.onLeverDeactivate.AddListener(StopDriving);

    }

    // Update is called once per frame
    void Update()
    {
        if(isDrive)
        {
            DriveSpaceShip();
        }
    }

    private void StartDriving() => isDrive = true;

    private void StopDriving() => isDrive = false;

    private void DriveSpaceShip()
    {
        float sideVelocity = turnSpeed * Mathf.Lerp(-1, 1, xRWheelKnob.value);
        Vector3 velocity = new Vector3(sideVelocity, 0, speed);
        transform.position += velocity * Time.deltaTime;
    }
}

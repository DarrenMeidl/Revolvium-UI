using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ControlRumble : MonoBehaviour, ISelectHandler, ISubmitHandler
{
    [SerializeField] private float lowFrequency = 0.05f;
    [SerializeField] private float highFrequency = 0.12f;
    [SerializeField] private float rumbleTime = 0.12f;
    private void Rumble(float low, float high, float time)
    {
        if (Gamepad.current != null) // Check if any gamepad is connected
        {
            Gamepad.current.SetMotorSpeeds(low, high); // Low frequency: 0.25, High frequency: 0.5
            Invoke(nameof(StopRumble), time);
        }
    }

    private void StopRumble()
    {
        Gamepad.current?.ResetHaptics();
    }
    public void OnSelect(BaseEventData eventData)
    {
        Rumble(lowFrequency, highFrequency, rumbleTime);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Rumble(lowFrequency + 0.1f, highFrequency + 0.1f, rumbleTime + 0.05f);
    }
}

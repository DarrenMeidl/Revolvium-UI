using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsDisplay : MonoBehaviour
{
    [Header("Control Types")]
    [TextArea]
    [SerializeField]
    private string description;
    [SerializeField] private GameObject[] controls_gameplay;
    [SerializeField] private GameObject[] controls_menu;

    private ControlType currentControlType;
    private InputDevice currentDevice;

    void Start()
    {
        var devices = InputSystem.devices;
        if (currentDevice != devices[devices.Count-1] && devices.Count >= 1) // ensure there is at least one device connected
        {
            currentDevice = devices[devices.Count-1]; // if multiple devices are connected, the latest one will be stored
            UpdateDevice(currentDevice);
        }
        Debug.Log($"Current device: {currentDevice.displayName}");
    }
    
    void Update()
    {
        var devices = InputSystem.devices;
        if (currentDevice != devices[devices.Count - 1] && devices.Count >= 1) // latest device connected will be stored
        {
            currentDevice = devices[devices.Count - 1]; // if multiple devices are connected, the first one will be stored
            UpdateDevice(currentDevice);
        }                    
    }

    private void UpdateDevice(InputDevice device)
    {
        if (device is Keyboard || device is Mouse)
        {
            SetType(ControlType.PC);
            Debug.Log("Keyboard or Mouse detected");
        }
        else if (device is Gamepad)
        {
            if (device.layout.Contains("XboxGamepad") || device.displayName.Contains("Xbox"))
                SetType(ControlType.XBOX);
            else if (device.layout.Contains("DualShockGamepad") || device.displayName.Contains("Dual"))
                SetType(ControlType.PS);
            else if (device.displayName.Contains("Joy-Con") || device.displayName.Contains("Pro Controller"))
                SetType(ControlType.SWITCH);
            else // if its anything else, default to Xbox
                SetType(ControlType.XBOX);
            Debug.Log($"Gamepad detected: {device.displayName}");
        }
    }

    public void Display_Controls_Player()
    {
        controls_gameplay[(int)currentControlType].GetComponent<ToggleControls>().Enable_Player();
    }

    public void Display_Controls_Rotation()
    {
        controls_gameplay[(int)currentControlType].GetComponent<ToggleControls>().Enable_Rotation();
    }

    private void SetType(ControlType type)
    {
        currentControlType = type;
        foreach (GameObject control in controls_gameplay) // ensure all gameplay controls are off first
        {
            control.SetActive(false);
            Debug.Log("All gays!!!");
        }
        // turn on gameplay controls based on current type
        controls_gameplay[(int)currentControlType].SetActive(true); 
        foreach (GameObject controlsMenu in controls_menu) // turn on all menu controls associated with current type
        {
            controlsMenu.GetComponent<ToggleControlType>().EnableType(currentControlType);
        }
        Debug.Log("Called SetType()");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsDisplay : MonoBehaviour
{
    [Header("Control Types")]
    [TextArea]
    [SerializeField]
    private string description = "ORDER -> PC = 0, Xbox = 1, PS = 2, Switch = 3";
    [SerializeField] private GameObject[] controls_gameplay;
    [SerializeField] private GameObject[] controls_menu;
    private ControlType currentControlType;
    void Start()
    {
        SetType(ControlType.PC); // set the default type (keyboard)
    }

    void Update()
    {
        // if current input device is the same as the one we're displaying, do nothing
        // else, set ControlType to the current input device
        // and display the controls for that device

        // find current input device

    }

    public void Display_Controls_Player()
    {
        controls_gameplay[(int)currentControlType].GetComponent<ToggleControls>().Enable_Player();
    }

    public void Display_Controls_Rotation()
    {
        controls_gameplay[(int)currentControlType].GetComponent<ToggleControls>().Enable_Rotation();
    }

    public void SetType(ControlType type)
    {
        currentControlType = type;
        foreach (GameObject control in controls_gameplay) // ensure all gameplay controls are off first
        {
            control.SetActive(false);
        }
        // turn on gameplay controls based on current type
        controls_gameplay[(int)currentControlType].SetActive(true); 
        foreach (GameObject controlsMenu in controls_menu) // turn on all menu controls associated with current type
        {
            controlsMenu.GetComponent<ToggleControlType>().EnableType(currentControlType);
        }
    }
}

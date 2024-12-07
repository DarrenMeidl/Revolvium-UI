using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlType : MonoBehaviour
{
    [Header("Control Types")]
    [TextArea]
    [SerializeField]
    private string description = "ORDER -> PC = 0, Xbox = 1, PS = 2, Switch = 3";
    [SerializeField] private GameObject[] controls;
    public void EnableType(ControlType type)
    {
        // Disable all controls
        foreach (var control in controls)
        {
            control.SetActive(false);
        }
        // Enable the selected control
        controls[(int)type].SetActive(true);
    }
}

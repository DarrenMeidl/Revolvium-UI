using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] controlTypes;
    private int currentControl = 0;
    // Start is called before the first frame update
    void Start()
    {
        // we assume it's a keyboard type input for now (will implement check later)
        controlTypes[currentControl].SetActive(true);
        // turn off all other control types
        foreach (GameObject control in controlTypes)
        {
            if (control != controlTypes[currentControl])
                control.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if current input device is the same as the one we're displaying, do nothing
        // else, disable all control types, and enable the one we want to display
    }

    public void Display_Controls_Player()
    {
        controlTypes[currentControl].GetComponent<ToggleControls>().Enable_Player();
    }

    public void Display_Controls_Rotation()
    {
        controlTypes[currentControl].GetComponent<ToggleControls>().Enable_Rotation();
    }
}

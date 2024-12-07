using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControls : MonoBehaviour
{
    [SerializeField] private GameObject playerControls;
    [SerializeField] private GameObject rotationControls;
    void Awake() {
        playerControls.SetActive(true); // turn on player controls
        rotationControls.SetActive(false); // turn off rotation controls
    }

    public void Enable_Player()
    {
        playerControls.SetActive(true); // turn on player controls
        rotationControls.SetActive(false); // turn off rotation controls
    }
    public void Enable_Rotation()
    {
        playerControls.SetActive(false); // turn off player controls
        rotationControls.SetActive(true); // turn on rotation controls
    }
    //public void Swap_Controls() // swap active state of controls
    //{
    //    foreach (GameObject child in controls)
    //    {
    //        child.SetActive(!child.activeSelf);
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetPrimaryButton : MonoBehaviour
{
    private Button primaryButton;
    private void Awake()
    {
        if (GetComponent<Button>() != null)
            primaryButton = GetComponent<Button>();
    }
    private void OnEnable()
    {
        primaryButton.Select(); // ensures a button is selected when the menu is opened
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
// This script is used to change the color of the text when the mouse hovers over it or when it is selected
// Handles the Events for PointerEnter, PointerExit, Select and Deselect here instead of inspector
public class TextHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI text;
    private bool isMouseHovering = false;
    private bool isSelected = false;

    [SerializeField] private Color defaultTextColor = Color.black;
    [SerializeField] private Color highlightedTextColor = Color.white;
    
    void OnEnable()
    {
        if (GetComponentInChildren<TextMeshProUGUI>(true) != null) // ensures the text component is found in inactive children
            text = GetComponentInChildren<TextMeshProUGUI>(true);

        if (gameObject.GetComponent<SetPrimaryButton>() != null) // primary buttons are selected by default on start
            text.color = highlightedTextColor;
        else
            text.color = defaultTextColor;
    }
    public void OnPointerEnter(PointerEventData eventData) // mouse enters the button
    {
        isMouseHovering = true;
        UpdateText();
    }
 
    public void OnPointerExit(PointerEventData eventData) // mouse exits the button
    {
        isMouseHovering = false;
        UpdateText();
    }
 
    public void OnSelect(BaseEventData eventData) // button is selected e.g. controller or keyboard
    {
        isSelected = true;
        UpdateText();
    }

    public void OnDeselect(BaseEventData eventData) // button loses selection focus
    {
        isSelected = false;
        UpdateText();
    }
    private void UpdateText()
    {
        if (isSelected || isMouseHovering)
            text.color = highlightedTextColor;
        else
            text.color = defaultTextColor;
    }
}

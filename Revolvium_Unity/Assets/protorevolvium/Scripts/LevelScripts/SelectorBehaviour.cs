using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBehaviour : MonoBehaviour
{
    public levelRotationDirection selectorMoveDir;

    [SerializeField]
    private GameObject highlight, selector;

    [SerializeField, ReadOnly]
    private Vector3 originalPosition;

    private void Awake() {
        originalPosition = transform.position;
    }

    public void enableHighLight() {
        highlight.SetActive(true);
        disableSelector();
    }
    public void disableHighLight() {
        highlight.SetActive(false);
        disableSelector();
        transform.position = originalPosition;
    }

    public void enableSelector() {
        selector.SetActive(true);
    }
    public void disableSelector() {
        selector.SetActive(false);
    }
}

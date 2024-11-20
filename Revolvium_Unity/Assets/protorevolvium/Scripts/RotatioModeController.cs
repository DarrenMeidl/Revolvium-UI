using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Rotation Mode CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */

public class RotatioModeController : MonoBehaviour
{
    [SerializeField]
    private bool rotateOn = false;

    [SerializeField]
    private GameEvent finishRotate;

    private void Start()
    {
        rotateOn = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && rotateOn)
        {
            Debug.Log("Rotate Over");
            finishRotate.Raise();
            rotateOn = false;
        }
    }

    public void enabledRotation()
    {
        rotateOn = true;
    }
}

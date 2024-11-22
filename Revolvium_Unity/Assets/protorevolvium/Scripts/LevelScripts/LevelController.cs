using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private Transform levelChunkFinder;

    private float delay = 0f; // delay is used between turns so that the chunk locator can activate and unactivate 
    [SerializeField]
    [Tooltip("the time between when inputs can be pressed")]
    private float defaultDelay = 1f; // default dealy used in between presses


    [SerializeField]
    private List<levelRotationDirection> rotationDirections = new List<levelRotationDirection>();

    public levelRotationDirection currentRotationDirection;


    

    // will need to be improved
    [SerializeField, Tooltip("is true if the dimensions of the cube are even.")]
    private bool evenDimensions = false;

    [SerializeField]
    private levelCreationSettings creationSettings;


    public levelCreationSettings GetCreationSettings() { return creationSettings; }

}

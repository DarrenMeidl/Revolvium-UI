using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/*
 *  PLAYER MOVEMENT CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float speed = 1f;

    [SerializeField, ReadOnly]
    private bool canMove = true;

    private Vector3 rawInputMovement;

    private void Start()
    {
        canMove = true;
        rawInputMovement = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    public void OnMovement(InputAction.CallbackContext value)
    {
        if ( canMove ) {
            Vector2 inputMovement = value.ReadValue<Vector2>();
            rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        }
    }

    private void FixedUpdate() {
        if (canMove) {
            characterController.SimpleMove(rawInputMovement);
        }
    }


    public void enableRotation()
    {
        canMove = false;
        rawInputMovement = new Vector3(0, 0, 0); //stops player from continueing to move after rotation
    }
    public void disableRotation()
    {
        canMove = true;
    }

    public void Movement_Disable()
    {
        canMove = false;
        rawInputMovement = new Vector3(0, 0, 0); //stops player from continueing to move after pausing
    }
    public void Movement_Enable()
    {
        canMove = true;
    }
}

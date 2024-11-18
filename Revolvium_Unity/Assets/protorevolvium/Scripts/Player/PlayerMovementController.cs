using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

    private void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( canMove ) {
            characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed); //deltatime is not considered, since simplemove will do that for you
        }
    }

    public void enableRotation()
    {
        canMove = false;
    }
    public void disableRotation()
    {
        canMove = true;
    }
}

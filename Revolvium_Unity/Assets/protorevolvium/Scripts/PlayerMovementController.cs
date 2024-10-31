using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*speed); //deltatime is not considered, since simplemove will do that for you
    }
}

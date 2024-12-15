
using UnityEngine;
using UnityEngine.InputSystem;
/*
 *  PLAYER MOVEMENT CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private CharacterController characterController;
    //[SerializeField]
    //private Animator PlayerAnimationController; //reference to animator
    [SerializeField]
    private float TurnSpeed = 0.5f;

    [SerializeField, ReadOnly]
    private bool canMove = true;

    private Vector2 inputMovement = Vector2.zero;
    private Vector3 rawInputMovement;

    [SerializeField]
    private Transform CameraFocus, Model;

    private void Start()
    {
        canMove = true;
        rawInputMovement = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        if (canMove) {
            rawInputMovement = inputMovement.y * CameraFocus.forward + inputMovement.x * CameraFocus.right;
            characterController.SimpleMove(rawInputMovement);

            // ported and changed from animation test 2 branch
            // ported and fixed by Ruby :3 & Darren :D
            Vector3 movement = rawInputMovement.normalized;
            if (movement.magnitude > 0) {
                Model.right = Vector3.Lerp(Model.right, movement * -1, TurnSpeed); //rotate to face movement direction              
           
                Vector3 euler = Model.rotation.eulerAngles; // Lock the x-axis rotation to -90
                euler.x = -90; // Force x-axis
                Model.rotation = Quaternion.Euler(euler); // current model exported in a way that requires this to be forced, would fix in a future release
                //PlayerAnimationController.SetBool("isWalking", true); //play walking animation
            }
            else
            {
                //PlayerAnimationController.SetBool("isWalking", false); //stop walking animation
            }

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

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Respawn") {
            LevelChangeManager.Instance.ReloadLevel();
        }
    }
}

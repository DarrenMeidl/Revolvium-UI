using Cinemachine;
using GD;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  Camera Controller - STARTED BY AND WRITTEN BY RUBY
 */

public class CameraController : MonoBehaviour {
    [SerializeField, Title("References")]
    private CinemachineVirtualCamera VirtualCamera;

    [SerializeField]
    private Transform player, level;

    [SerializeField, Title("Camera Attributes")]
    private CameraOffset CameraOffset;
    [SerializeField]
    private float sensativity = 0.05f;
    [SerializeField]
    private float maxHeight = 1.4f;

    [SerializeField, Title("Events")]
    private Vector3GameEvent camMoveEvent;

    [SerializeField, ReadOnly, Title("Debugging")]
    private Vector3 camMoveAmout;


    private bool canRotate = false;

    private CinemachineTransposer transposer;

    private float camVerticalPos = 0f;

    private Transform cameraFocus;

    public void RotationEnabled() {
        canRotate = true;
        cameraFocus = level;
    }
    public void RotationDisabled() {
        canRotate = false;
        cameraFocus = player;
    }

    private void Start() {
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        RotationDisabled();
    }

    private void FixedUpdate() {
        if (Mathf.Abs(camMoveAmout.magnitude) > 0) {
            cameraFocus.Rotate(camMoveAmout);
        }
        float newCamOffsetY = (transposer.m_FollowOffset.y + camVerticalPos * ((canRotate) ? 1 : 0)); //slow downs vertical camera outside of rotation mode
        if (Mathf.Abs(newCamOffsetY) > maxHeight * ((canRotate) ? 1 : 0.2f)) newCamOffsetY = (maxHeight * Mathf.Sign(newCamOffsetY)) * ((canRotate) ? 1 : 0.2f);

        //follow offset needs to changed based on whether or not the player is in focus
        if(canRotate)
            transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x, newCamOffsetY, CameraOffset.levelOffset.z);
        else
            transposer.m_FollowOffset = new Vector3(CameraOffset.playerOffset.x, newCamOffsetY, CameraOffset.playerOffset.z);

        camMoveEvent?.Raise(cameraFocus.forward);
    
    }

    public void OnMovement(InputAction.CallbackContext value) {
        camMoveAmout = new Vector3(0, value.ReadValue<Vector2>().x * -sensativity * 10, 0) * -1;
        camVerticalPos = value.ReadValue<Vector2>().y * sensativity * -1;
    }
}

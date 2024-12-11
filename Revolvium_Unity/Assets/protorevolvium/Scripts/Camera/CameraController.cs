using Cinemachine;
using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera VirtualCamera;
    private CinemachineTransposer transposer;

    private float camVerticalPos = 0f;

    [SerializeField]
    private Transform player, level;
    private Transform cameraFocus;

    [SerializeField]
    private CameraOffset CameraOffset;

    [SerializeField]
    private Vector3GameEvent camMoveEvent;

    [SerializeField]
    private float sensativity = 0.05f;
    [SerializeField]
    private float maxHeight = 1.4f;


    private bool canRotate = false;

    private int offSetValue = 0;

    [SerializeField, ReadOnly]
    private Vector3 camMoveAmout;

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

        camMoveEvent?.Raise(transposer.m_FollowOffset);
    
    }

    public void OnMovement(InputAction.CallbackContext value) {
        camMoveAmout = new Vector3(0, value.ReadValue<Vector2>().x * -sensativity * 10, 0) * -1;
        camVerticalPos = value.ReadValue<Vector2>().y * sensativity * -1;
    }
}

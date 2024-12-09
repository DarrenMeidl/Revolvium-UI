using Cinemachine;
using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera VirtualCamera;
    private CinemachineTransposer transposer;

    private float camVerticalPos = 0f;

    [SerializeField]
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
    }
    public void RotationDisabled() {
        canRotate = false;
        camVerticalPos = 0;
    }

    private void Start() {
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        RotationDisabled();
    }

    private void FixedUpdate() {
        if (canRotate) {
            if (Mathf.Abs(camMoveAmout.magnitude) > 0) {
                cameraFocus.Rotate(camMoveAmout);
            }
            float newCamOffsetY = transposer.m_FollowOffset.y + camVerticalPos;
            if (Mathf.Abs(newCamOffsetY) > maxHeight) newCamOffsetY = maxHeight * Mathf.Sign(newCamOffsetY);
            transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x, newCamOffsetY, CameraOffset.levelOffset.z);
            camMoveEvent?.Raise(transposer.m_FollowOffset);
        }
    }

    public void OnMovement(InputAction.CallbackContext value) {
        if(canRotate) {
            camMoveAmout = new Vector3(0, value.ReadValue<Vector2>().x * -sensativity * 10, 0);
            camVerticalPos = value.ReadValue<Vector2>().y * sensativity;
        }
    }
}

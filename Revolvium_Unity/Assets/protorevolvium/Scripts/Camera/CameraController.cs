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

    [SerializeField]
    private List<Vector2> camOffsets = new List<Vector2>();
    [SerializeField]
    private int camVerticalPos = 1;

    [SerializeField]
    private CameraOffset CameraOffset;

    [SerializeField]
    private Vector3GameEvent camMoveEvent;


    private bool canRotate = false;

    private int offSetValue = 0;


    public void RotationEnabled() {
        canRotate = true;
    }
    public void RotationDisabled() {
        canRotate = false;
    }

    private void Start() {
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    public void OnMovement(InputAction.CallbackContext value) {
        if (value.started && canRotate) {
            float inputCameraHorizontal = value.ReadValue<Vector2>().x;
            if (inputCameraHorizontal > 0.8) {
                offSetValue--;
                if (offSetValue < 0) offSetValue = camOffsets.Count - 1;
                transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x * camOffsets[offSetValue].x, CameraOffset.levelOffset.y * camVerticalPos, CameraOffset.levelOffset.z * camOffsets[offSetValue].y);
                camMoveEvent?.Raise(transposer.m_FollowOffset);
            }
            else if (inputCameraHorizontal < -0.8) {
                offSetValue++;
                if (offSetValue >= camOffsets.Count) offSetValue = 0;
                transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x * camOffsets[offSetValue].x, CameraOffset.levelOffset.y* camVerticalPos, CameraOffset.levelOffset.z * camOffsets[offSetValue].y);
                camMoveEvent?.Raise(transposer.m_FollowOffset);
            }
            float inputCameraVertical = value.ReadValue<Vector2>().y;
            if (inputCameraVertical > 0.8) {
                camVerticalPos = 1;
                transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x * camOffsets[offSetValue].x, CameraOffset.levelOffset.y * camVerticalPos, CameraOffset.levelOffset.z * camOffsets[offSetValue].y);
                camMoveEvent?.Raise(transposer.m_FollowOffset);
            }
            else if (inputCameraVertical < -0.8) {
                camVerticalPos = -1;
                transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x * camOffsets[offSetValue].x, CameraOffset.levelOffset.y * camVerticalPos, CameraOffset.levelOffset.z * camOffsets[offSetValue].y);
                camMoveEvent?.Raise(transposer.m_FollowOffset);
            }
        }
    }
}

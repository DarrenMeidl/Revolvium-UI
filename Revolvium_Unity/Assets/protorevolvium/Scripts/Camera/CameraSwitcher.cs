using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  CAMERA SWITCHER - STARTED BY AND WRITTEN BY RUBY
 */
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera VirtualCamera;
    CinemachineTransposer transposer;

    [SerializeField]
    private Transform Transform;

    [SerializeField]
    private Vector3 playerOffset = new Vector3(0, 0, -10);
    [SerializeField]
    private Vector3 rotateOffset = new Vector3(0, 0, -20);

    // Start is called before the first frame update
    void Start()
    {
        //https://discussions.unity.com/t/cinemachine-base-follow-offset/698432 13/11/2024
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = playerOffset;
    }   

    public void enableRotation()
    {
        transposer.m_FollowOffset = rotateOffset;
    }
    public void disableRotation()
    {
        transposer.m_FollowOffset = playerOffset;
    }
}

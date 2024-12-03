using Cinemachine;
using UnityEngine;
using GD.Audio;

/*
 *  CAMERA SWITCHER - STARTED BY AND WRITTEN BY RUBY
 */
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera VirtualCamera;
    private CinemachineTransposer transposer;

    [SerializeField]
    private Transform Transform;
    [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private Transform LevelTransform;

    [SerializeField]
    private CameraOffset CameraOffset;

    [SerializeField]
    private AudioClip cameraWhoosh;

    // Start is called before the first frame update
    void Start()
    {
        //https://discussions.unity.com/t/cinemachine-base-follow-offset/698432 13/11/2024
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = CameraOffset.playerOffset;

        VirtualCamera.LookAt = PlayerTransform;
        VirtualCamera.Follow = PlayerTransform;
    }   

    public void enableRotation()
    {
        transposer.m_FollowOffset = CameraOffset.levelOffset;
        VirtualCamera.LookAt = LevelTransform;
        VirtualCamera.Follow = LevelTransform;

        AudioManager.Instance.PlaySound(cameraWhoosh, GD.Types.AudioMixerGroupName.SFX);
    }
    public void disableRotation()
    {
        transposer.m_FollowOffset = CameraOffset.playerOffset;
        VirtualCamera.LookAt = PlayerTransform;
        VirtualCamera.Follow = PlayerTransform;
        AudioManager.Instance.PlaySound(cameraWhoosh, GD.Types.AudioMixerGroupName.SFX);
    }
}

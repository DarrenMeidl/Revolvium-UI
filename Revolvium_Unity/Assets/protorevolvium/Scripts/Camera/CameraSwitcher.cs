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
    CinemachineTransposer transposer;

    [SerializeField]
    private Transform Transform;
    [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private Transform LevelTransform;

    [SerializeField]
    private Vector3 playerOffset = new Vector3(0, 0, -10);
    [SerializeField]
    private Vector3 rotateOffset = new Vector3(0, 0, -20);

    [SerializeField]
    private AudioClip cameraWhoosh;

    // Start is called before the first frame update
    void Start()
    {
        //https://discussions.unity.com/t/cinemachine-base-follow-offset/698432 13/11/2024
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = playerOffset;

        VirtualCamera.LookAt = PlayerTransform;
    }   

    public void enableRotation()
    {
        transposer.m_FollowOffset = rotateOffset;
        VirtualCamera.LookAt = LevelTransform;
        AudioManager.Instance.PlaySound(cameraWhoosh, GD.Types.AudioMixerGroupName.SFX);
    }
    public void disableRotation()
    {
        transposer.m_FollowOffset = playerOffset;
        VirtualCamera.LookAt = PlayerTransform;
        AudioManager.Instance.PlaySound(cameraWhoosh, GD.Types.AudioMixerGroupName.SFX);
    }
}

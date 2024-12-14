using Cinemachine;
using UnityEngine;
using GD.Audio;
using System.Collections;
using GD;

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

    [SerializeField]
    private GameEvent unlockEvent, pauseEvent, unpauseEvent;

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
        float y = CameraOffset.levelOffset.y * 1;
        transposer.m_FollowOffset = new Vector3(CameraOffset.levelOffset.x, y, CameraOffset.levelOffset.z);
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
     
    private IEnumerator UnlockFocus() {
        transposer.m_FollowOffset = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2f);
        disableRotation();
        unlockEvent?.Raise();
        unpauseEvent?.Raise();
    }
    public void LockFocus(Transform lockTransform) {
        AudioManager.Instance.PlaySound(cameraWhoosh, GD.Types.AudioMixerGroupName.SFX);
        VirtualCamera.LookAt = lockTransform;
        VirtualCamera.Follow = lockTransform;
        StartCoroutine(UnlockFocus());
        pauseEvent?.Raise();
    }
}

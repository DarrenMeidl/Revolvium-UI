using GD;
using GD.Audio;
using System.Collections;
using UnityEngine;

public class LockTileBehaviour : LevelTile {

    [SerializeField]
    private int keyID;

    [SerializeField]
    private AudioClip unlockSound;

    [SerializeField]
    private TransformGameEvent UnlockEvent;

    [SerializeField]
    private Transform CameraFocus;

    [SerializeField]
    private Animator Animator;

    private void Start() {
    
    }

    private IEnumerator Unlock() {
        yield return new WaitForSeconds(0.2f);
        Animator.SetTrigger("OpenTrigger");
        yield return new WaitForSeconds(0.3f);
        AudioManager.Instance.PlaySound(unlockSound, GD.Types.AudioMixerGroupName.SFX);
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

    public void AttemptUnlock(int keyID) {
        if (keyID == this.keyID) {
            UnlockEvent?.Raise(CameraFocus);
            StartCoroutine(Unlock());
        }
    }

    protected override void interact(GameObject player) {
        
    }
}

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

    private void Start() {
    
    }

    private IEnumerator Unlock() {
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlaySound(unlockSound, GD.Types.AudioMixerGroupName.SFX);
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

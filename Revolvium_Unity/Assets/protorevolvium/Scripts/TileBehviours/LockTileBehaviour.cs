using GD;
using GD.Audio;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class LockTileBehaviour : LevelTile {

    [SerializeField, Title("Attributes")]
    private int keyID;

    [SerializeField, Title("Events")]
    private TransformGameEvent UnlockEvent;

    [SerializeField, Title("Sounds")]
    private AudioClip unlockSound;

    [SerializeField, Title("References")]
    private Transform CameraFocus;

    [SerializeField]
    private Animator Animator;


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
        /*
         * the lock has no need to interact, so this is empty
         * Isn't that just fun?
         * Maybe one day the lock will gain the courage to interact
         * We will be there for it if it does
         */
    }
}

using GD.Audio;
using System.Collections.Generic;
using UnityEngine;

public class LockTileBehaviour : LevelTile {

    [SerializeField]
    private int keyID;

    [SerializeField]
    private AudioClip unlock;

    private void Start() {
    
    }


    public void AttemptUnlock(int keyID) {
        if (keyID == this.keyID) {
            this.gameObject.SetActive(false);
            AudioManager.Instance.PlaySound(unlock, GD.Types.AudioMixerGroupName.SFX);
        }
    }

    protected override void interact(GameObject player) {
        
    }
}

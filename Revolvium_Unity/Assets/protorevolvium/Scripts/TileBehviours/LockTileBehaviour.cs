using GD;
using System.Collections.Generic;
using UnityEngine;

public class LockTileBehaviour : LevelTile {

    [SerializeField]
    private int keyID;

    private void Start() {
    }


    public void AttemptUnlock(int keyID) {
        Debug.Log(keyID);
        if (keyID == this.keyID) {
            this.gameObject.SetActive(false);
        }
    }

    protected override void interact(GameObject player) {
        
    }
}

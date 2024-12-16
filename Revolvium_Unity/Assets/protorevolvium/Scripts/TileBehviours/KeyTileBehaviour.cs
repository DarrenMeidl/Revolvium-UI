using GD;
using GD.Audio;
using NUnit.Framework.Constraints;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO - better manage tiles, so that many types can be made


/*
 *  ROTATION TILE BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */

public class KeyTileBehaviour : LevelTile {

    [SerializeField, Title("Attributes")]
    private int keyID;

    [SerializeField, Title("Events")]
    private IntGameEvent gameEvent;

    [SerializeField, Title("Sounds")]
    private AudioClip getKey;

    private void Start() {
    }


    protected override void interact(GameObject player){
        gameEvent?.Raise(keyID);

        gameObject.SetActive(false);

        AudioManager.Instance.PlaySound(getKey, GD.Types.AudioMixerGroupName.SFX);
    }
}

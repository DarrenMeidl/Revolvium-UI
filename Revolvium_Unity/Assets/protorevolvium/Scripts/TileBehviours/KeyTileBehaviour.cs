using GD;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO - better manage tiles, so that many types can be made


/*
 *  ROTATION TILE BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */

public class KeyTileBehaviour : LevelTile
{

    [SerializeField]
    private IntGameEvent gameEvent;

    [SerializeField]
    private int keyID;

    private void Start() {
    }


    protected override void interact(GameObject player){
        gameEvent?.Raise(keyID);

        gameObject.SetActive(false);
    }
}

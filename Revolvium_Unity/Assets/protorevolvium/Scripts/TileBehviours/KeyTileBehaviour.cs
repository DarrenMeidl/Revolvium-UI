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
    private List<GameObject> locks = new List<GameObject>();

    private void Start() {
        foreach (GameObject l in locks) {
            l.SetActive(true);
        }
    }


    protected override void interact(GameObject player){
        foreach (GameObject l in locks) {
            l.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}

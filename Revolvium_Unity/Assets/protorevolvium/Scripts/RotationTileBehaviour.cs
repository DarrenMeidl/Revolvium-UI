using GD;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO - better manage tiles, so that many types can be made


/*
 *  ROTATION TILE BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */

public class RotationTileBehaviour : LevelTile
{
    [SerializeField]
    private GameEvent enableRotation;
    [SerializeField]
    private GameEvent disableRotation;


    [ContextMenu("Disable Rotation")]
    public void evokeDisableRotation()
    {
        disableRotation?.Raise();
    }
    [ContextMenu("Enable Rotation")]
    public void evokeEnableRotation()
    {
        enableRotation?.Raise();
        Debug.Log("ROTATION MODE IS TURNED ON!! :3");
    }

    protected override void interact(GameObject player)
    {
        evokeEnableRotation();                                      //dont' change player Y
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z); //makes sure the player is correctly positioned on the tile
        // fixes bug "Player can get stuck in wall after rotation" in sprint 7 
    }
}

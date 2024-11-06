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

    protected override void interact()
    {
        evokeEnableRotation();
    }
}

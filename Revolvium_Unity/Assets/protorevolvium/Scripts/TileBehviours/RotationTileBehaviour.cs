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

public class RotationTileBehaviour : LevelTile
{
    [SerializeField, Title("Events")]
    private GameEvent enableRotation;
    [SerializeField]
    private GameEvent disableRotation;

    [SerializeField, Title("Sounds")]
    private AudioClip enable;




    [ContextMenu("Disable Rotation")]
    public void evokeDisableRotation()
    {
        disableRotation?.Raise();
    }
    [ContextMenu("Enable Rotation")]
    public void evokeEnableRotation()
    {
        enableRotation?.Raise();
    }

    

    protected override void interact(GameObject player)
    {
        evokeEnableRotation();                                      //dont' change player Y
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z); //makes sure the player is correctly positioned on the tile
        // fixes bug "Player can get stuck in wall after rotation" in sprint 7 

        AudioManager.Instance.PlaySound(enable, GD.Types.AudioMixerGroupName.SFX);
    }
}

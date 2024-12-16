using GD;
using GD.Audio;
using NUnit.Framework.Constraints;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//TODO - better manage tiles, so that many types can be made


/*
 *  END TILE BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */

public class EndTileBehaviour : LevelTile
{

    [SerializeField, Title("Sounds")]
    private AudioClip win;

    [SerializeField, Title("Events")]
    private GameEvent disablePlayer;

    protected override void interact(GameObject player)
    {
        disablePlayer?.Raise();
        MenuManager.CloseAllMenus();
        MenuManager.OpenMenu(Menu.LEVEL_END);

        AudioManager.Instance.PlaySound(win, GD.Types.AudioMixerGroupName.SFX);
    }
}

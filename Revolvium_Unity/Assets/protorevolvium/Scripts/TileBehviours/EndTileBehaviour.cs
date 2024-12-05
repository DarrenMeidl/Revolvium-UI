using GD;
using GD.Audio;
using NUnit.Framework.Constraints;
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
    [SerializeField]
    private int nextLevel;

    [SerializeField]
    private AudioClip win;

    [SerializeField]
    private GameEvent pause;

    protected override void interact(GameObject player)
    {
        pause?.Raise();
        MenuManager.CloseAllMenus();
        MenuManager.OpenMenu(Menu.LEVEL_END);
        //SceneManager.LoadScene($"Level{nextLevel}");

        AudioManager.Instance.PlaySound(win, GD.Types.AudioMixerGroupName.SFX);
    }
}

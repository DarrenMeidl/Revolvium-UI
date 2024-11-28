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


    protected override void interact(GameObject player)
    {
        SceneManager.LoadScene($"Level{nextLevel}");
        Debug.Log("dwnjdnhwiadnhwiadhnihn");

        AudioManager.Instance.PlaySound(win, GD.Types.AudioMixerGroupName.SFX);
    }
}

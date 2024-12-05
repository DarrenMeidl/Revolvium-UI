using System.Collections;
using System.Collections.Generic;
using GD;
using GD.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInput : Singleton<MenuInput>
{
    private bool paused;

    [SerializeField] private GameEvent pause, resume;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip hover;
    protected override void Awake()
    {
        base.Awake();

        #region Perform Tasks Upon Awake
        // if we're in a main menu, we can't access pause menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN);
        }
        else
        { // if not, we must be in a level
            MenuManager.CloseAllMenus();
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
        }
        paused = false;
        #endregion

        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe to the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // if we're in a main menu, we can't access pause menu
        if (scene.buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN);
        }
        else
        { // if not, we must be in a level
            MenuManager.CloseAllMenus();
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
        }
        paused = false;
    }

    public void Pause(InputAction.CallbackContext value) {
        if (value.started) {
            if (paused) { // if we press the pause button when we're already paused
                Pause_Close();
            }
            else {
                Pause_Open();
            }
        }
    }


    private void Pause_Close()
    {
        resume?.Raise();
        paused = false;
        MenuManager.CloseMenu(Menu.PAUSE);
        MenuManager.OpenMenu(Menu.PLAYER_HUD);
    }

    private void Pause_Open()
    {
        pause?.Raise();
        paused = true;
        MenuManager.OpenMenu(Menu.PAUSE);
        MenuManager.CloseMenu(Menu.PLAYER_HUD);
    }

    private void Level_End_Open()
    {
        MenuManager.CloseAllMenus(); // Ensure no other menus are open
        MenuManager.OpenMenu(Menu.LEVEL_END);
    }

    public void Play_Click_Sound()
    {
        AudioManager.Instance.PlaySound(click, GD.Types.AudioMixerGroupName.SFX);
    }

    public void Play_Hover_Sound()
    {
        AudioManager.Instance.PlaySound(hover, GD.Types.AudioMixerGroupName.SFX);
    }

}

using System.Collections;
using System.Collections.Generic;
using GD;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInput : Singleton<MenuInput>
{
    private bool paused;
    private bool canPause;

    [SerializeField] private GameEvent pause, resume;
    protected override void Awake()
    {
        base.Awake();

        #region Perform Tasks Upon Awake
        // if we're in a main menu, we can't access pause menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN);
            canPause = false;
        }
        else
        { // if not, we must be in a level
            MenuManager.CloseAllMenus();
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
            canPause = true;
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
            canPause = false;
        }
        else
        { // if not, we must be in a level
            MenuManager.CloseAllMenus();
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
            canPause = true;
        }
        paused = false;
    }

    private void Update()
    {
        CheckPlayerInput();
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

    private void CheckPlayerInput()
    {
        
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
        canPause = false;
        MenuManager.CloseAllMenus(); // Ensure no other menus are open
        MenuManager.OpenMenu(Menu.LEVEL_END);
    }

    public void Can_Pause_True()
    {
        canPause = true;
    }
    public void Can_Pause_False()
    {
        canPause = false;
    }

}

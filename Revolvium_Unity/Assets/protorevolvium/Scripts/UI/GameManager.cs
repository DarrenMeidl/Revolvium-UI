using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // static reference to the GameManager script
    private bool paused;
    private bool canPause;
    void Awake()
    {
        #region Setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion

        #region Perform Tasks Upon Awake
        // if we're in a main menu, we can't access pause menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN);
            canPause = false;
        }
        else
        { // if not, we must be in a level
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
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
            canPause = true;
        }
        paused = false;
    }

    private void Update()
    {
        CheckPlayerInput();
    }
    private void CheckPlayerInput()
    {
        if (Input.GetButtonDown("Pause") && canPause)
        {
            if (paused)
            { // if we press the pause button when we're already paused
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetButtonDown("End Level"))
        {
            EndLevel();
        }
    }

    private void Resume()
    {
        paused = false;
        MenuManager.CloseMenu(Menu.PAUSE);
        MenuManager.OpenMenu(Menu.PLAYER_HUD);
    }

    private void Pause()
    {
        paused = true;
        MenuManager.OpenMenu(Menu.PAUSE);
        MenuManager.CloseMenu(Menu.PLAYER_HUD);
    }

    private void EndLevel()
    {
        canPause = false;
        MenuManager.CloseAllMenus(); // Ensure no other menus are open
        MenuManager.OpenMenu(Menu.LEVEL_END);
    }
}

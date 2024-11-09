using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // static reference to the GameManager script
    public static bool GameIsPaused;
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
        // if we're in a main menu, we can't access other menus
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN, gameObject);
            canPause = false;
        }
        else
        { // if not, we must be in a level
            canPause = true;
        }
        // Game is not paused
        GameIsPaused = false;
        #endregion

        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe to the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // if we're in a main menu, we can't access other menus
        if (scene.buildIndex == 0)
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN, gameObject);
            canPause = false;
        }
        else
        { // if not, we must be in a level
            canPause = true;
        }
        // Game is not paused
        GameIsPaused = false;
    }

    private void Update()
    {
        CheckPlayerInput();
        Debug.Log("Game Paused -> "+GameIsPaused);
    }
    private void CheckPlayerInput()
    {
        if (Input.GetButtonDown("Pause") && canPause)
        {
            if (GameIsPaused)
            { // if we press the pause button when we're already paused
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        GameIsPaused = false;
    }

    private void Pause()
    {
        GameIsPaused = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool canPause;
    private bool GameIsPaused;
    //private void Awake()
    //{
    //    canPause = true;
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape) && canPause)
    //    {
    //        canPause = false;
    //        MenuManager.OpenMenu(Menu.PAUSE);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Escape))
    //        canPause = true;
    //}
    private void Update()
    {
        CheckPlayerInput();
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
        MenuManager.CloseMenu(Menu.PAUSE);
        MenuManager.OpenMenu(Menu.PLAYER_HUD);
    }

    private void Pause()
    {
        GameIsPaused = true;
        MenuManager.OpenMenu(Menu.PAUSE);
        MenuManager.CloseMenu(Menu.PLAYER_HUD);
    }
}

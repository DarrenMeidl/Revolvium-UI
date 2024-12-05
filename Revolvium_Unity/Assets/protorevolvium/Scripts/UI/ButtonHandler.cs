using System.Collections;
using System.Collections.Generic;
using GD;
using UnityEngine;
using UnityEngine.SceneManagement;
// Called MenuManager functions from: https://www.youtube.com/watch?v=MmsbM89SVbM&t=268s&ab_channel=Comp-3Interactive

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    #region Common Functions
    public void OnClick_Level_Next()
    {
        // Hardcoded to loop back to level 1 if we're on the last level
        if (SceneManager.GetActiveScene().buildIndex == 3)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MenuManager.OpenMenu(Menu.PLAYER_HUD, gameObject);
        gameEvent?.Raise(); // resume game
    }
    public void OnClick_Level_Restart()
    {
        Debug.Log("GAME RESTARTING...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false); // turn off this menu
    }

    public void OnClick_Quit()
    {
        Debug.Log("GAME QUITING...");
        Application.Quit(); // This will quit the game
    }
    #endregion

    #region Pause Menu Functions
    public void OnClick_Resume()
    {
        gameEvent?.Raise();
        MenuManager.OpenMenu(Menu.PLAYER_HUD, gameObject);
    }
    #endregion

    #region Options Menu Funcitons
    public void OnClick_Options()
    {
        MenuManager.OpenMenu(Menu.OPTIONS, gameObject);
    }
    #endregion

    #region Main Menu Functions
    public void OnClick_MainMenu()
    {
        SceneManager.LoadScene(0); // load title screen scene
        MenuManager.OpenMenu(Menu.TITLE_SCREEN, gameObject);
    }
    #endregion

    #region Test Menu Functions
    public void OnClick_Menu1()
    {
        MenuManager.OpenMenu(Menu.MENU1, gameObject);
    }

    public void OnClick_Menu2()
    {
        MenuManager.OpenMenu(Menu.MENU2, gameObject);
    }
    public void OnClick_Level_End()
    {
        MenuManager.OpenMenu(Menu.LEVEL_END, gameObject);
    }
    public void OnClick_Pause()
    {
        MenuManager.OpenMenu(Menu.PAUSE, gameObject);
    }
    #endregion
}

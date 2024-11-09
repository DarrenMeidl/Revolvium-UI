using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Called MenuManager functions from: https://www.youtube.com/watch?v=MmsbM89SVbM&t=268s&ab_channel=Comp-3Interactive
public class ButtonHandler : MonoBehaviour
{
    public void OnClick_LoadNextLevel()
    {
        Debug.Log("NEXT LEVEL LOADING...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MenuManager.OpenMenu(Menu.PLAYER_HUD, gameObject);
    }
    public void OnClick_RestartLevel()
    {
        Debug.Log("GAME RESTARTING...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuManager.OpenMenu(Menu.PLAYER_HUD, gameObject);
    }

    public void OnClick_Quit()
    {
        Debug.Log("GAME QUITING...");
        Application.Quit(); // This will quit the game
    }


    #region Pause Menu Functions
    public void Resume()
    {
        Debug.Log("Game Resumed");
        GameManager.GameIsPaused = false;
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
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.InMainMenu = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("GAME QUIT");
        Application.Quit(); // This will quit the game
    }


    #region Pause Functions
    public void Resume()
    {
        Debug.Log("Game Resumed");
        GameManager.GameIsPaused = false;
    }
    #endregion

    #region Options Funcitons
    public void LoadOptions()
    {
        GameManager.InOptionsMenu = true;
    }
    #endregion

    #region Main Menu Functions
    public void LoadMainMenu()
    {
        GameManager.InMainMenu = true;
    }
    #endregion
}

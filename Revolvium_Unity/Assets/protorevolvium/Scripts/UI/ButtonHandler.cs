using System.Collections;
using System.Collections.Generic;
using GD;
using UnityEngine;
using UnityEngine.SceneManagement;
// Called MenuManager functions from: https://www.youtube.com/watch?v=MmsbM89SVbM&t=268s&ab_channel=Comp-3Interactive

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameEvent resumeEvent;

    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Animator transition;
    #region Common Functions
    private IEnumerator LoadLevel(int index) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
    public void OnClick_Level_Next()
    {
        // Hardcoded to loop back to level 1 if we're on the last level
        if (SceneManager.GetActiveScene().buildIndex == 3)
            StartCoroutine(LoadLevel(1));
        else
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        resumeEvent?.Raise(); // resume game ------------------
    }
    public void OnClick_Level_Restart()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void OnClick_Quit()
    {
        Application.Quit(); // This will quit the game
    }
    #endregion

    #region Pause Menu Functions
    public void OnClick_Resume()
    {
        resumeEvent?.Raise();
        MenuManager.CloseAllMenus();
        MenuManager.OpenMenu(Menu.PLAYER_HUD);
    }
    #endregion

    #region Options Menu Funcitons
    public void OnClick_Options()
    {
        MenuManager.CloseAllMenus();
        MenuManager.OpenMenu(Menu.OPTIONS);
    }
    #endregion

    #region Main Menu Functions
    public void OnClick_MainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }
    #endregion  
}

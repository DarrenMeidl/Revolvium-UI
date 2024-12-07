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
    private IEnumerator LoadNextLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        LevelChangeManager.Instance.ChangeLevel();
    }
    public void OnClick_Level_Next()
    {
        StartCoroutine(LoadNextLevel());
        resumeEvent?.Raise(); // resume game ------------------
    }
    private IEnumerator LoadCurrentLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        LevelChangeManager.Instance.ReloadLevel();
    }
    public void OnClick_Level_Restart() {
        StartCoroutine(LoadCurrentLevel());
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
    public void OnClick_Back()
    {
        MenuManager.CloseAllMenus();
        MenuManager.OpenMenu(Menu.TITLE_SCREEN);
    }
    #endregion

    #region Main Menu Functions
    public void OnClick_MainMenu()
    {
        StartCoroutine(LoadNextLevel());
    }
    #endregion  
}

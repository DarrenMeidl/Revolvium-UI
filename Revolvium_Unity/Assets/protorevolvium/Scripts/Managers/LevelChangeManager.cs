using GD;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Level change manager - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChangeManager : Singleton<LevelChangeManager>
{
    [SerializeField, Title("Next Level")]
    private int nextLevel;
    private int currentLevel;

   
    [SerializeField, Title("Transition Fields")] 
    private float transitionTime = 1f;
    [SerializeField] 
    private Animator transition;

    private void Start() {
        string currentLevelStr =  SceneManager.GetActiveScene().name.Substring(5);
        try {
            currentLevel = int.Parse(currentLevelStr);
        }
        catch(FormatException) {
            currentLevel = 1;
        }
    }
    private IEnumerator LoadLevel(int levelNum) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene($"Level{levelNum}");
        Debug.Log("Loaded Level" + levelNum);
    }
    public void ChangeLevel() {
        StartCoroutine(LoadLevel(nextLevel));
    }
    public void ReloadLevel() {
        Debug.Log("RELOADING");
        Debug.Log("ReloadLevel called. Stack trace:\n" + System.Environment.StackTrace);
        StartCoroutine(LoadLevel(currentLevel));
    }

    private IEnumerator BackToTitle() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene($"Screen_Title");
    }
    public void ChangeToTitle() {
        StartCoroutine(BackToTitle());
    }
}

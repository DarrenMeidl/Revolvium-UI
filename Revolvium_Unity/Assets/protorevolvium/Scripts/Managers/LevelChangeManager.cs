using GD;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeManager : Singleton<LevelChangeManager>
{
    [SerializeField]
    private int nextLevel;

    private int currentLevel;



    private void Start() {
        string currentLevelStr =  SceneManager.GetActiveScene().name.Substring(5);
        try {
            currentLevel = int.Parse(currentLevelStr);
        }
        catch(FormatException) {
            currentLevel = 1;
        }
    }

    public void ChangeLevel() {
        SceneManager.LoadScene($"Level{nextLevel}");
    }
    public void ReloadLevel() {
        SceneManager.LoadScene($"Level{currentLevel}");
    }
}

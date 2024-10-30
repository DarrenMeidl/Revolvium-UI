using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [Header("Canvas Objects")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject endLevelCanvas;
    [SerializeField] private GameObject playerHUDCanvas;
    void Awake()
    { // we start in the main menu
        pauseCanvas.SetActive(false);
        endLevelCanvas.SetActive(false);
        playerHUDCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }


    void Update()
    {
        // if we're in the main menu
        if (GameManager.InMainMenu)
        {
            mainMenuCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            optionsCanvas.SetActive(false);
            endLevelCanvas.SetActive(false); 
            playerHUDCanvas.SetActive(false);
        }
        // if we're not in the main menu or options menu
        else if (!GameManager.InMainMenu && !GameManager.InOptionsMenu)
        { 
            mainMenuCanvas.SetActive(false);
            playerHUDCanvas.SetActive(true); 
        }
        // if we're in the options menu
        if (GameManager.InOptionsMenu)
        {
            optionsCanvas.SetActive(true);
        }
        else if (!GameManager.InOptionsMenu)
        {
            optionsCanvas.SetActive(false);
        }
        // if game is paused
        if (GameManager.GameIsPaused)
        {
            pauseCanvas.SetActive(true); 
            playerHUDCanvas.SetActive(false);
        }
        // if game is not paused
        else if (!GameManager.GameIsPaused)
        {
            pauseCanvas.SetActive(false); 
            playerHUDCanvas.SetActive(true); 
            endLevelCanvas.SetActive(false);
            optionsCanvas.SetActive(false);
        }
        // if level is finished
        if (GameManager.LevelIsFinished)
        {
            optionsCanvas.SetActive(false);
            endLevelCanvas.SetActive(true); 
            pauseCanvas.SetActive(false); 
            playerHUDCanvas.SetActive(false); 
        }
    }
}

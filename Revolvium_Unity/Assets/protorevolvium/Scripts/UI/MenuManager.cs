using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// SOURCE: https://www.youtube.com/watch?v=MmsbM89SVbM&t=268s&ab_channel=Comp-3Interactive
public static class MenuManager
{
    // Menu objects (panels)
    public static GameObject title_screen, pause, options, level_end, player_hud, logo;
    public static void OpenMenu(Menu menu)
    {
        // find the next menu, turn it on
        switch (menu)
        {
            case Menu.TITLE_SCREEN:
                title_screen.SetActive(true);
                logo.SetActive(true);
                break;
            case Menu.PAUSE:
                pause.SetActive(true);
                break;
            case Menu.OPTIONS:
                options.SetActive(true);
                break;
            case Menu.LEVEL_END:
                level_end.SetActive(true);
                break;
            case Menu.PLAYER_HUD:
                player_hud.SetActive(true);
                break;
        }
    } 
    public static void CloseMenu(Menu menu)
    {
        // find the next menu, turn it off
        switch (menu)
        {
            case Menu.TITLE_SCREEN:
                title_screen.SetActive(false);
                break;
            case Menu.PAUSE:
                pause.SetActive(false);
                break;
            case Menu.OPTIONS:
                options.SetActive(false);
                break;
            case Menu.LEVEL_END:
                level_end.SetActive(false);
                break;
            case Menu.PLAYER_HUD:
                player_hud.SetActive(false);
                break;
        }
    }
    public static void CloseAllMenus()
    {
        // Turn off all menus
        title_screen.SetActive(false);
        pause.SetActive(false);
        options.SetActive(false);
        level_end.SetActive(false);
        player_hud.SetActive(false);
        if (logo != null)
            logo.SetActive(false); // hard-code turn off logo, for when options menu is opened
    }
    public static void Initialize()
    {
        GameObject canvas = GameObject.Find("UI_Canvas");

        title_screen = canvas.transform.Find("title_screen").gameObject;
        pause = canvas.transform.Find("pause").gameObject;
        options = canvas.transform.Find("options").gameObject;
        level_end = canvas.transform.Find("level_end").gameObject;
        player_hud = canvas.transform.Find("player_hud").gameObject;

        logo = GameObject.Find("Logo");
    }
}

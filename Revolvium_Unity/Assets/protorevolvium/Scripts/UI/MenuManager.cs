using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// SOURCE: https://www.youtube.com/watch?v=MmsbM89SVbM&t=268s&ab_channel=Comp-3Interactive
public static class MenuManager
{
    public static bool IsInitialized { get; private set; } // read anywhere, only set in this script
    // Menu objects (panels)
    public static GameObject menu1, menu2, title_screen, pause, options, level_end, player_hud;
    public static void Initialize()
    {
        GameObject canvas = GameObject.Find("Canvas");

        menu1 = canvas.transform.Find("menu1").gameObject;
        menu2 = canvas.transform.Find("menu2").gameObject;
        title_screen = canvas.transform.Find("title_screen").gameObject;
        pause = canvas.transform.Find("pause").gameObject;
        options = canvas.transform.Find("optons").gameObject;
        level_end = canvas.transform.Find("level_end").gameObject;
        player_hud = canvas.transform.Find("player_hud").gameObject;

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        // Initialize our menus
        if (!IsInitialized)
            Initialize();
        // find the next menu, turn it on
        switch (menu)
        {
            case Menu.MENU1:
                menu1.SetActive(true);
                break;
            case Menu.MENU2:
                menu2.SetActive(true);
                break;
            case Menu.TITLE_SCREEN:
                title_screen.SetActive(true);
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
        // turn off the current menu
        callingMenu.SetActive(false);  
    }
}

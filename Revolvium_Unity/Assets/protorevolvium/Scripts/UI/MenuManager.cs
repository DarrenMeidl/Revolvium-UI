using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialized { get; private set; } // read anywhere, only set in this script
    public static GameObject menu1, menu2;
    public static void Initialize()
    {
        GameObject canvas = GameObject.Find("Canvas");
        menu1 = canvas.transform.Find("menu1").gameObject;
        menu2 = canvas.transform.Find("menu2").gameObject;

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        // Initialize our menus
        if (!IsInitialized)
            Initialize();
        // passed in our next menu (enum), find the next menu, turn it on
        switch (menu)
        {
            case Menu.MENU1:
                menu1.SetActive(true);
                break;
            case Menu.MENU2:
                menu2.SetActive(true);
                break;
        }
        // turn off the current menu
        callingMenu.SetActive(false);  
    }
}

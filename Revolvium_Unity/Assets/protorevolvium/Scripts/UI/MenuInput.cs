using System;
using System.Collections;
using System.Collections.Generic;
using GD;
using GD.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInput : Singleton<MenuInput>
{
    private bool paused;
    private bool canPause;

    [SerializeField] private GameEvent pause, resume;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip hover;
    [SerializeField] private GameObject[] firstSelectButtons;

    private PlayerInput _UIInputs; 
    private InputAction _navigationAction;
    private Vector2 _navigationInput;

    protected override void Awake()
    {
        base.Awake();

        MenuManager.Initialize(); // prevents needing to look for menus every time we want to open/close them
        MenuManager.CloseAllMenus(); // ensure no other menus are open

        _UIInputs = GetComponent<PlayerInput>();
        _navigationAction = _UIInputs.currentActionMap["UI_Navigate_Tracker"]; // no way to track if you're navigating a menu if you're not selecting anything
                                                                               // we need this in PlayerControls map so we can track if the player is trying to navigate the menu even if currentSelectedGameObject is null
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) // if we're in a main menu, we can't access pause menu
        {
            MenuManager.OpenMenu(Menu.TITLE_SCREEN);
            canPause = false;
        }
        else
        { // if not, we must be in a level
            MenuManager.OpenMenu(Menu.PLAYER_HUD);
            canPause = true;
        }
        paused = false;        
    }
    private void Update()
    {
        _navigationInput = _navigationAction.ReadValue<Vector2>(); // read the input value
        //Debug.Log(_navigationAction.ReadValue<Vector2>());
        //Debug.Log(EventSystem.current.currentSelectedGameObject);
        // if we try to navigate but our button isn't active or doesn't exist
        if ((_navigationInput != Vector2.zero) && (EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject.activeInHierarchy == false))
        {
            EnableFirstSelected(); // select the first button
        }
    }

    private void EnableFirstSelected()
    {
        foreach (GameObject g in firstSelectButtons) // run through our first selected buttons
        {
            if (g.activeInHierarchy) // if the current first selected is active
            {
                EventSystem.current.SetSelectedGameObject(g); // set new selected button
                Debug.Log("Selected: " + g.name);
                return; // end loop early, we enable first active button so no need to loop through rest of array
            }
        }
    }
    public void Pause(InputAction.CallbackContext value) {
        if (value.started && canPause) {
            if (paused) { // if we press the pause button when we're already paused
                Pause_Close();
            }
            else {
                Pause_Open();
            }
        }
    }

    private void Pause_Close()
    {
        resume?.Raise();
        paused = false;
        MenuManager.CloseMenu(Menu.PAUSE);
        MenuManager.OpenMenu(Menu.PLAYER_HUD);
    }

    private void Pause_Open()
    {
        pause?.Raise();
        paused = true;
        MenuManager.OpenMenu(Menu.PAUSE);
        MenuManager.CloseMenu(Menu.PLAYER_HUD);
    }
    public void CanPause(int state)
    {
        if (state == 0)
            canPause = true;
        else
            canPause = false;
    }
    public void Actions_Click()
    {
        AudioManager.Instance.PlaySound(click, GD.Types.AudioMixerGroupName.UI);
        RumbleManager.Instance.Rumble(0.22f, 0.22f, 0.12f);
    }

    public void Acitons_Highlight()
    {
        AudioManager.Instance.PlaySound(hover, GD.Types.AudioMixerGroupName.UI);
        RumbleManager.Instance.Rumble(0.15f, 0.15f, 0.08f);
    }
}
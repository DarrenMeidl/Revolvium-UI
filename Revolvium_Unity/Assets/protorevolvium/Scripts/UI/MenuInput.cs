using System.Collections;
using System.Collections.Generic;
using GD;
using GD.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInput : Singleton<MenuInput>
{
    private bool paused;
    private bool canPause;

    [SerializeField] private GameEvent pause, resume;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip hover;
    protected override void Awake()
    {
        base.Awake();

        #region Perform Tasks Upon Awake
        MenuManager.Initialize(); // prevents needing to look for menus every time we want to open/close them
        MenuManager.CloseAllMenus(); // ensure no other menus are open
        #endregion
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
        AudioManager.Instance.PlaySound(click, GD.Types.AudioMixerGroupName.SFX);
        RumbleManager.Instance.Rumble(0.22f, 0.22f, 0.12f);
    }

    public void Acitons_Highlight()
    {
        AudioManager.Instance.PlaySound(hover, GD.Types.AudioMixerGroupName.SFX);
        RumbleManager.Instance.Rumble(0.15f, 0.15f, 0.08f);
    }
}
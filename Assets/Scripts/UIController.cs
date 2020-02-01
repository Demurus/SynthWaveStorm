using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainMenuWindow _mainMenuWindow;
    [SerializeField] private SettingsWindow _settingsWindow;
    [SerializeField] private ShopWindow _shopWindow;

    //private void SettingsWindowMusicToggleValueChangeEvent()
    //{
    //    _settingsWindow.MusicSwitchOn();
    //}


    private void SettingsWindowOnOkButtonClickEvent()
    {
        _settingsWindow.Hide();
    }
    private void MainMenuWindowOnQuitButtonClickEvent()
    {
        _mainMenuWindow.Hide();
    }

    private void MainMenuWindowOnPlayButtonClickEvent()
    {
        _mainMenuWindow.Hide();
    }

    private void MainMenuWindowOnSettingsButtonClickEvent()
    {
        _settingsWindow.Show();
    }
    private void Awake()
    {
        _mainMenuWindow.OnPlayButtonClickEvent += MainMenuWindowOnPlayButtonClickEvent;
        _mainMenuWindow.OnQuitButtonClickEvent += MainMenuWindowOnQuitButtonClickEvent;
        _settingsWindow.OnOKButtonClickEvent += SettingsWindowOnOkButtonClickEvent;
        _mainMenuWindow.OnSettingsButtonClickEvent += MainMenuWindowOnSettingsButtonClickEvent;
        //_settingsWindow.OnMusicToggleValueChangeEvent += SettingsWindowMusicToggleValueChangeEvent;
    }
    void Start()
    {
        
    }


    

    void Update()
    {
        
    }
}

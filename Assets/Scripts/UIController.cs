using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainMenuWindow _mainMenuWindow;
    [SerializeField] private SettingsWindow _settingsWindow;
    [SerializeField] private ShopWindow _shopWindow;



    private void ShopWindowOnOkButtonClickEvent()
    {
        _shopWindow.Hide();
    }
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
        SceneManager.LoadScene("Level_01");
    }
    private void MainMenuWindowOnShopButtonClickEvent()
    {
        
        _shopWindow.Show();
        
       
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
        _mainMenuWindow.OnShopButtonClickEvent += MainMenuWindowOnShopButtonClickEvent;
        _shopWindow.OnOkButtonClickEvent += ShopWindowOnOkButtonClickEvent;
        
    }
    void Start()
    {
        
    }


    

    void Update()
    {
        
    }
}

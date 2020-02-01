using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Button _quitGameButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;

    public event Action OnQuitButtonClickEvent;
    public event Action OnPlayButtonClickEvent;
    public event Action OnSettingsButtonClickEvent;
    private void Awake()
    {
        _quitGameButton.onClick.AddListener(OnQuitButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);

    }

    private void OnSettingsButtonClick()
    {
        OnSettingsButtonClickEvent?.Invoke();
    }
    private void OnPlayButtonClick()
    {
        OnPlayButtonClickEvent?.Invoke();
    }
    private void OnQuitButtonClick()
    {
        OnQuitButtonClickEvent?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

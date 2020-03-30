using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LostLevelWindow : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _goToMainMenuButton;
    [SerializeField] private Button _continueButton;

    public event Action OnRestartLevelClickEvent;
    public event Action OnGoToMenuClickEvent;
    public event Action OnContinueLevelClickEvent;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _goToMainMenuButton.onClick.AddListener(OnGoToMenuButtonClick);
        _continueButton.onClick.AddListener(OnContinueLevelButtonClick);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    private void OnRestartButtonClick()
    {
        OnRestartLevelClickEvent?.Invoke();
    }

    private void OnGoToMenuButtonClick()
    {
        OnGoToMenuClickEvent?.Invoke();
    }

    private void OnContinueLevelButtonClick()
    {
        OnContinueLevelClickEvent?.Invoke();
    }
}

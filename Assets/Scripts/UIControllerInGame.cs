using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerInGame : MonoBehaviour
{
    [SerializeField] private LostLevelWindow _lostLevelWindow;
    [SerializeField] private WonLevelWindow _wonLevelWindow;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private UIWindow _uIWindow;





    private void Awake()
    {
        _gameManager.GameOverLostEvent += LostLevelWindowOnGameOverLostEvent;
        _gameManager.GameOverWonEvent += WonLevelWindowOnGameOverWonEvent;
        _lostLevelWindow.OnRestartLevelClickEvent += LostLevelWindowOnRestartButtonClickEvent;
        _lostLevelWindow.OnGoToMenuClickEvent += LostLevelWindowOnGoToMenuButtonClickEvent;
        _lostLevelWindow.OnContinueLevelClickEvent += LostLevelWindowOnContinueButtonClickEvent;
        _pauseWindow.OnRestartLevelClickEvent += PauseWindowOnRestartButtonClickEvent;
        _pauseWindow.OnGoToMenuClickEvent += PauseWindowOnGoToMenuButtonClickEvent;
        _pauseWindow.OnContinueLevelClickEvent += PauseWindowOnContinueButtonClickEvent;
        _uIWindow.OnPauseButtonClickEvent += PauseWindowOnShow;
       
    }


    private void WonLevelWindowOnGameOverWonEvent()
    {
        _wonLevelWindow.Show();
    }

    private void LostLevelWindowOnGameOverLostEvent()
    {
        _lostLevelWindow.Show();
    }
   
    private void LostLevelWindowOnRestartButtonClickEvent()
    {
        _lostLevelWindow.Restart();
    }

    private void LostLevelWindowOnGoToMenuButtonClickEvent()
    {
        _lostLevelWindow.BackToMenu();
    }

    private void LostLevelWindowOnContinueButtonClickEvent()
    {
        Debug.Log("Continue");
    }

    private void PauseWindowOnShow()
    {
        _pauseWindow.Show();
    }

    private void PauseWindowOnRestartButtonClickEvent()
    {
        _pauseWindow.Restart();
    }

    private void PauseWindowOnGoToMenuButtonClickEvent()
    {
        _pauseWindow.BackToMenu();
    }

    private void PauseWindowOnContinueButtonClickEvent()
    {
        _pauseWindow.Hide();
    }


}

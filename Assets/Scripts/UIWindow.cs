using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
   

    public event Action OnPauseButtonClickEvent;

    public void OnPauseButton()
    {
        
        OnPauseButtonClickEvent?.Invoke();
    }
    private void Awake()
    {
        _pauseButton.onClick.AddListener(OnPauseButton);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Button _okButton;
    [SerializeField] private Toggle _musicToggle;

    public event Action OnOKButtonClickEvent;
    public event Action OnMusicToggleValueChangeEvent;
    

    private void Awake()
    {
        _okButton.onClick.AddListener(OnOkButtonClick);
     }
    public void MusicIsOn(bool isPlaying)
    {
        if (isPlaying)
        {
            MusicSwitchOn();
        }
        else MusicSwitchOff();
    }
    
    public void SoundIsOn (bool isPlaying)
    {
        if (isPlaying)
        {
            SoundSwitchOn();
        }
        else SoundSwitchOff();
    }
    private void OnOkButtonClick()
    {
        OnOKButtonClickEvent?.Invoke();
    }

    public void MusicSwitchOn()
    {
       Debug.Log("Music is on");
    }

    public void MusicSwitchOff()
    {
      Debug.Log("Music is off");
    }

    public void SoundSwitchOn()
    {
        Debug.Log("Sound is on");
    }

    public void SoundSwitchOff()
    {
        Debug.Log("Sound is off");
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

    
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
   
    [SerializeField] private Button _50coinsButton;
    [SerializeField] private Button _200coinsButton;
    [SerializeField] private Button _500coinsButton;
    [SerializeField] private Button _okButton;
    private ShopWindow _shopWindow;
    private GameManager _gameManager;
    

    public event Action On50coinsButtonClickEvent;
    public event Action On200coinsButtonClickEvent;
    public event Action On500coinsButtonClickEvent;
    public event Action OnOkButtonClickEvent;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _50coinsButton.onClick.AddListener(On50coinsButtonClick);
        _200coinsButton.onClick.AddListener(On200coinsButtonClick);
        _500coinsButton.onClick.AddListener(On500coinsButtonClick);
        _okButton.onClick.AddListener(OnOkButtonClick);
        

    }
    private void On50coinsButtonClick()
    {
        On50coinsButtonClickEvent?.Invoke();
    }
    private void On200coinsButtonClick()
    {
        On200coinsButtonClickEvent?.Invoke();
    }
    private void On500coinsButtonClick()
    {
        On500coinsButtonClickEvent?.Invoke();
    }
    private void OnOkButtonClick()
    {
        OnOkButtonClickEvent?.Invoke();
    }

    public void Show()
    {
        
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
   
}

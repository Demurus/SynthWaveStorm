using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coinbar : MonoBehaviour
{
    private GameManager _gameManager;
    private DepenciesManager _depenciesManager;

    public Text _coinText;
    void Start()
    {
        
    }
    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _gameManager = _depenciesManager.gameManager;
    }
    public void Refresh(int incomingCoins)
    {
        _coinText.text = incomingCoins.ToString();
    }
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static int _playerCoins;
    public int PlayerCoins
    {
        get => _playerCoins;
        set
        {
            _playerCoins = value;
            Debug.Log("coins:" + _playerCoins);
           
        }
    }

    public void CoinsIncrement()
    {
        PlayerCoins++;
    }

}

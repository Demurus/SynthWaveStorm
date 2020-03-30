using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _powerUpList;
   

    public event Action OnBallSpeedUpEvent;
    public event Action OnPaddeGrowEvent;
    public event Action OnPaddeShrinkEvent;

   
    public void SpawnPowerup(Vector3 position)
    {
        int probability = UnityEngine.Random.Range(1, 101);
        if (probability > 50)
        {
            int powerUpTypeRandom = UnityEngine.Random.Range(0, 5); // 5 никогда не передастся
            Instantiate(_powerUpList[powerUpTypeRandom], position, Quaternion.identity);
        }

    }
    public void PowerUpHandler(string powerUpType)
    {
        
        Debug.Log(powerUpType);
        if (powerUpType == TagClass.PowerUPBallSpeedUp) OnBallSpeedUp();
        if (powerUpType == TagClass.PowerUPPaddleGrow) OnPaddleGrow();
        if (powerUpType == TagClass.PowerUPPaddleShrink) OnPaddleShrink();
    }

    public void OnPaddleGrow()
    {
        OnPaddeGrowEvent?.Invoke();
    }
    public void OnPaddleShrink()
    {
        OnPaddeShrinkEvent?.Invoke();
    }
    public void OnBallSpeedUp()
    {
        OnBallSpeedUpEvent?.Invoke();
    }
   
}

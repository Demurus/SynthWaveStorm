using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3];
    private GameManager _gameManager;
    private DepenciesManager _depenciesManager;
    void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _gameManager = _depenciesManager.gameManager;
    }
   public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _gameManager.Lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        
    }
}

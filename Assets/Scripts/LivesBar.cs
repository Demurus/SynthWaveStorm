using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3];
    private GameManager _gameManager;
    void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
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

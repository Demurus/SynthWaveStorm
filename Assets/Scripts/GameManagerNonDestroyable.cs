using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerNonDestroyable : MonoBehaviour
{
    private void Awake()
    {
       
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameController");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{


    private void Awake()
    {
        Destroy(gameObject, 2.0F);
    }
}
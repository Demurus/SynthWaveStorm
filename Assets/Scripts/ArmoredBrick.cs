using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredBrick : MonoBehaviour
{
    public Sprite[] crashedSprites;
    public GameObject armoredBrickCollapse;
  
    
    public Sprite GetCrashedSprite(int index)
    {
        return crashedSprites[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick:MonoBehaviour
{
    public Sprite blueStrongBrickCrashed;
    public Sprite purpleStrongBrickCrashed;
   
    public Sprite GetCrashedSprite(string brickTag)
    {
        if (brickTag == TagClass.BrickblueStrongBrick) return blueStrongBrickCrashed;
        if (brickTag == TagClass.BrickpurpleStrongBrick) return purpleStrongBrickCrashed;
        else return null;
    }
}

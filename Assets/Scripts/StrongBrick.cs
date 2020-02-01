using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : Brick
{
    protected int sLives = 2;

    //protected override int Checklife(int x)
    //{
    //    return base.Checklife(sLives);
    //}

    //protected override void OnCollisionEnter2D(Collision2D collision)
    //{

    //    Ball ball = collision.gameObject.GetComponent<Ball>();
    //    if (ball)
    //    {
    //        sLives--;
    //        Checklife(sLives);
    //        base.OnCollisionEnter2D(collision);
    //    }
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    protected int lives = 1;
    protected StrongBrick strongbrick;
    [SerializeField] private GameObject _blueBrickCollapse;
    [SerializeField] private GameObject _purpleBrickCollapse;
    Ball ball;
    //protected int Checklife(int x)
    //{
    //   return lives = x;
    //}

    public GameObject CollapseColour(string brickTag)
    {
        if (brickTag == "blueBrick") return Collapse(_blueBrickCollapse);
        if (brickTag == "purpleBrick") return Collapse(_purpleBrickCollapse);
        else return null;
    }

    private GameObject Collapse(GameObject collapseAnimation)
    {
         return Instantiate(collapseAnimation, transform.position, transform.rotation);
       // Destroy(x, 2.0F);
    }
    


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
        StrongBrick strongBrick = collision.gameObject.GetComponent<StrongBrick>();


        //if (ball&&) Debug.Log("brick");
        if (ball && strongBrick) Debug.Log("st");

        //if (ball)
        //{

        //    Checklife(lives);
        //    Debug.Log(lives);


        //    if (lives <= 1)
        //    {
        //        Destroy(gameObject);
        //    }
        //    lives--;
        //}

    }

}
    


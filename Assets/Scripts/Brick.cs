using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    protected int lives = 1;
    private int _strongBrickHealth = 2;
    private int _armoredBrickHealth = 4;
    private StrongBrick _strongbrick;
    private ArmoredBrick _armoredBrick;
    private AudioManager _audioManager;
    [SerializeField] private GameObject _blueBrickCollapse;
    [SerializeField] private GameObject _purpleBrickCollapse;
    //[SerializeField] private Sprite blueStrongBrickCrashed;
    //[SerializeField] private Sprite purpleStrongBrickCrashed;
    private int _scoreOnDestroy;
    private int _scoreFromSimpleBrick=100;
    private int _scoreFromStrongBrick = 200;
    private int _scoreFromArmoredBrick = 400;
    private void Awake()
    {
        _strongbrick = GetComponent<StrongBrick>();
        _armoredBrick = GetComponent<ArmoredBrick>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    public bool HealthHandler(string brickTag)
    {
        if (brickTag == TagClass.BrickblueSimpleBrick || brickTag == TagClass.BrickpurpleSimpleBrick)
        {
            _scoreOnDestroy = _scoreFromSimpleBrick;
            
            return true;
        }

        if (brickTag == TagClass.BrickblueStrongBrick || brickTag == TagClass.BrickpurpleStrongBrick)
        {
            _strongBrickHealth--;
            _audioManager.Play(TagClass.SoundArmoredHit2);
            GetComponent<SpriteRenderer>().sprite = _strongbrick.GetCrashedSprite(brickTag);
            Debug.Log(_strongBrickHealth);
            if (_strongBrickHealth <= 0)
            {
                _scoreOnDestroy = _scoreFromStrongBrick;
                return true;
            }

            else return false;
        }
        if (brickTag == TagClass.BrickarmoredBrick)
        {
            Debug.Log(_armoredBrickHealth);
            _armoredBrickHealth--;
            //int spriteCounter = 0;
            while (_armoredBrickHealth != 0)
            {
                Debug.Log(_armoredBrickHealth);
                _audioManager.Play(TagClass.SoundArmoredHit1);
                GetComponent<SpriteRenderer>().sprite = _armoredBrick.GetCrashedSprite(_armoredBrickHealth - 1);
                //spriteCounter++;

                return false;
            }
            _scoreOnDestroy = _scoreFromArmoredBrick;
            return true;
        }
        else
        {
      
            return false;
        }

    }
    public Vector3 position()
    {
        return transform.position;
    }

    public int ScoreOnDestroy() => _scoreOnDestroy;

   
    public GameObject CollapseColour(string brickTag)
    {
        if (brickTag == TagClass.BrickblueSimpleBrick|| brickTag == TagClass.BrickblueStrongBrick) return Collapse(_blueBrickCollapse); // поставить comparetag
        if (brickTag == TagClass.BrickpurpleSimpleBrick|| brickTag == TagClass.BrickpurpleStrongBrick) return Collapse(_purpleBrickCollapse);
        if (brickTag == TagClass.BrickarmoredBrick) return Collapse(_armoredBrick.armoredBrickCollapse);

        else return null;
    }

    private GameObject Collapse(GameObject collapseAnimation)
    {
         return Instantiate(collapseAnimation, transform.position, transform.rotation);
       
    }
        
}
    


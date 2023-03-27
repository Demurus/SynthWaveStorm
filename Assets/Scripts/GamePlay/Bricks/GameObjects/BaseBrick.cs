using UnityEngine;

namespace GamePlay.Bricks.GameObjects
{
    public abstract class BaseBrick : MonoBehaviour
    {
        public abstract void Init();
        public abstract void BallCollision();
        
        /*public bool HealthHandler(string brickTag)
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
            if (brickTag == TagClass.BrickblueSimpleBrick || brickTag == TagClass.BrickblueStrongBrick) return Collapse(_blueBrickCollapse); // поставить comparetag
            if (brickTag == TagClass.BrickpurpleSimpleBrick || brickTag == TagClass.BrickpurpleStrongBrick) return Collapse(_purpleBrickCollapse);
            if (brickTag == TagClass.BrickarmoredBrick) return Collapse(_armoredBrick.armoredBrickCollapse);

            else return null;
        }

        private GameObject Collapse(GameObject collapseAnimation)
        {
            return Instantiate(collapseAnimation, transform.position, transform.rotation);

        }*/
    }
}

    


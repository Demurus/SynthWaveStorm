using System.Collections.Generic;
using GamePlay.Bricks.GameObjects;
using UnityEngine;

namespace GamePlay.Levels
{
    public class LevelMap : MonoBehaviour
    {
        [SerializeField] private List<BaseBrick> _bricks;

        public void InitMap()
        {
            _bricks.ForEach(b=>b.Init());
        }
    }
}
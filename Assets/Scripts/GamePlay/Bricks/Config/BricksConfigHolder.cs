using System.Collections.Generic;
using System.Linq;
using GamePlay.Bricks.Data;
using UnityEngine;

namespace GamePlay.Bricks.Config
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "BricksConfigsHolder", menuName = "ScriptableObjects/BricksConfigsHolder")]
    public class BricksConfigHolder : ScriptableObject, IBricksConfig
    {
        public List<BrickConfig> Bricks;

        public BrickConfig GetConfig(BrickType type)
        {
            return Bricks.FirstOrDefault(b => b.Type == type);
        }
    }
}
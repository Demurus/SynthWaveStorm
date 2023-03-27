using GamePlay.Bricks.Data;

namespace GamePlay.Bricks.Config
{
    [System.Serializable]
    public class BrickConfig
    {
        public BrickType Type;
        /// <summary>
        /// How many times brick can be hit before its destroyed
        /// </summary>
        public byte Lives;
        public bool GivesGoodBonus;
        public bool GivesBadBonus;
        public bool CallsRandomEvent;

    }
}
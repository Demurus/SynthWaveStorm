namespace GamePlay.Bricks.Data
{
    public enum BrickType
    {
        /// <summary>
        /// Default brick
        /// </summary>
        Simple    = 1,
        
        /// <summary>
        /// Slightly stronger then Simple
        /// </summary>
        Enforced  = 2,
        
        /// <summary>
        /// Strong block
        /// </summary>
        Armored   = 3,
        
        /// <summary>
        /// Provides bonus of any type (good or bad)
        /// </summary>
        AnyBonus  = 4,
        
        /// <summary>
        /// Provides bonus only of good type
        /// </summary>
        GoodBonus = 5,
        
        /// <summary>
        /// Anything can happen here
        /// </summary>
        Pandora   = 6
    }
}
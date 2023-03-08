namespace ChaptersSystem.Enums
{
    [System.Serializable]
    public enum ChapterState
    {
        Locked,
        
        /// <summary>
        /// Current running chapter
        /// </summary>
        Active,        
        
        /// <summary>
        /// Last level from chapter is passed, but rewards still not collected
        /// </summary>
        ReachedEnd,    
        
        /// <summary>
        /// Fully completed chapter (rewards collected)
        /// </summary>
        Completed
    }
}
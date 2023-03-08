namespace ChaptersSystem.Enums
{
    [System.Serializable]
    public enum ChapterType
    {
        /// <summary>
        /// Standard chapter with common rewards
        /// </summary>
        DefaultChapter = 0,
        //Any custom chapter below
        /// <summary>
        /// First custom chapter, filled with tutorials
        /// </summary>
        InitialCustomChapter = 1,
    }
}
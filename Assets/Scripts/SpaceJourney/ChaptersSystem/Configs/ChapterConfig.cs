namespace ChaptersSystem.Configs
{
    [System.Serializable]
    public class ChapterConfig
    {
        public ChapterType Type;
        public int ChapterNumber;
        public string ChapterName;
        public int StartLevel;
        public int EndLevel;
        public string VisualConfigName;
        public EndChapterReward EndChapterReward;
        public bool IsAvailableInGame = true;
        public string ChapterPreviewID;
    }
}
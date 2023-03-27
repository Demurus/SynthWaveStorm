namespace LevelsManagement
{
    public struct PlayLevelData
    {
        public int ChapterNumber;
        public int LevelNumber;
        public bool WinLevel;
        public byte Stars;
        public string Rating;

        public PlayLevelData(int chapterNumber, int levelNumber, bool winLevel, byte stars, string rating)
        {
            ChapterNumber = chapterNumber;
            LevelNumber = levelNumber;
            WinLevel = winLevel;
            Stars = stars;
            Rating = rating;
        }
    }
}
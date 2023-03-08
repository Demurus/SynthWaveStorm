using System.Collections.Generic;
using Data.ConfigsSystem;

namespace ChaptersSystem.Configs
{
    public interface IChaptersConfigData : IConfig
    {
        List<ChapterConfig> Chapters { get; }

        ChapterConfig GetChapterByLevel(int levelNumber);
        ChapterConfig GetChapterByNumber(int chapterNumber);
        ChapterConfig GetChapterByType(ChapterType chapterType);
    }
}
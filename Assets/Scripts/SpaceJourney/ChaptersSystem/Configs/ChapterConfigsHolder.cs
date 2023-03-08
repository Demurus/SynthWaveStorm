using System.Collections.Generic;
using System.Linq;
using LogTextColorExtension;
using UnityEngine;

namespace ChaptersSystem.Configs
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ChapterConfigsHolder", menuName = "ScriptableObjects/ChapterConfigsHolder")]
    public class ChapterConfigsHolder : ScriptableObject, IChaptersConfigData
    {
        [SerializeField] private List<ChapterConfig> _chapters;

        public List<ChapterConfig> Chapters => _chapters;

        public ChapterConfig GetChapterByLevel(int levelNumber)
        {
            return _chapters.FirstOrDefault(config => levelNumber >= config.StartLevel && levelNumber <= config.EndLevel);
        }
        
        public ChapterConfig GetChapterByNumber(int chapterNumber)
        {
            if (chapterNumber > _chapters.Last().ChapterNumber)
            {
                Debug.Log($"Chapter config error! No chapter by number {chapterNumber} exists".Colored(ColorType.Red));

                return _chapters.Last();
            }

            return _chapters.FirstOrDefault(config => config.ChapterNumber == chapterNumber);
        }

        public ChapterConfig GetChapterByType(ChapterType chapterType)
        {
            return _chapters.FirstOrDefault(config => chapterType == config.Type);
        }
    }
}
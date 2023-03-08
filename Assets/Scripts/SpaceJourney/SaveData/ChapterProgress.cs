using System.Collections.Generic;
using System.Linq;
using ChaptersSystem.Enums;
using DataSystem;
using GameBase;
using LevelsManagement;

namespace SpaceJourney.SaveData
{
    [System.Serializable]
    public class ChapterProgress
    {
        public int ChapterNumber;
        public ChapterState ChapterState;
        public List<LevelProgress> LevelsProgress;
        
        public ChapterProgress()
        {
        }

        public ChapterProgress(int chapterNumber)
        {
            ChapterNumber = chapterNumber;
            ChapterState = ChapterState.Active;
            LevelsProgress = new List<LevelProgress>();
        }

        public LevelProgress GetLevelProgress(int levelNumber)
        {
            return LevelsProgress.FirstOrDefault(progress => progress.LevelNumber == levelNumber);
        }

        public void AddLevelProgress(PlayLevelData data)
        {
            LevelProgress newProgress = new LevelProgress(data.LevelNumber, data.Stars, data.Rating);
            LevelsProgress.Add(newProgress);
            GameContext.GetInstance<IDataManager>().SaveGameData();
        }
    }
}
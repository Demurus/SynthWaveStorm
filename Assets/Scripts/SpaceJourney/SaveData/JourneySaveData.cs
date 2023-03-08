using System.Collections.Generic;
using System.Linq;
using DataSystem;
using GameBase;
using LevelsManagement;
using LogTextColorExtension;
using UnityEngine;

namespace SpaceJourney.SaveData
{
    [System.Serializable]
    public class JourneySaveData
    {
        public List<ChapterProgress> ChaptersProgress;
        
        public JourneySaveData()
        {
            ChaptersProgress?.Clear();
            ChaptersProgress = new List<ChapterProgress>();
        }

        private bool TryGetChapterProgress(int chapterNumber, out ChapterProgress result)
        {
            result = ChaptersProgress.FirstOrDefault(cp => cp.ChapterNumber == chapterNumber);
            return result != null;
        }
        
        private bool TryGetLevelProgress(int chapterNumber, int levelNumber, out LevelProgress result)
        {
            if (TryGetChapterProgress(chapterNumber, out ChapterProgress progress) == false)
            {
                result = progress.GetLevelProgress(levelNumber);
                return result != null;
            }
            else
            {
                result = null;
                return false;
            }
        }

        private void CreateLevelProgress(PlayLevelData levelData)
        {
            if (TryGetChapterProgress(levelData.ChapterNumber, out ChapterProgress chapterProgress))
            {
                chapterProgress.AddLevelProgress(levelData);
            }
            else
            {
                ChapterProgress newChapter = new ChapterProgress(levelData.ChapterNumber);
                ChaptersProgress.Add(newChapter);
                newChapter.AddLevelProgress(levelData);
                GameContext.GetInstance<IDataManager>().SaveGameData();
            }
        }

        public void AddLevelStats(PlayLevelData levelData)
        {
            if (levelData.WinLevel)
            {
                if (TryGetLevelProgress(levelData.ChapterNumber, levelData.LevelNumber, out LevelProgress levelProgress))
                    levelProgress.UpdateData(levelData);
                
                else
                    CreateLevelProgress(levelData);
            }
            else
            {
                //Do something to handle lost levels?
            }
        }
        
        /*public void CompleteChapter(int chapterNumber)
        {
            ChapterProgress foundChapter;
            if (TryGetChapter(chapterNumber, out foundChapter))
            {
                //DebugLog($"Chapter{foundChapter.ChapterNumber} COMPLETED!");
                foundChapter.ChapterState = ChapterState.Completed;
                GameContext.GetInstance<IJourneyManager>().UpdateChaptersState(foundChapter);
                GameContext.GetInstance<IDataManager>().SaveGameData();
                ChapterConfig newChapterConfig = GameContext.GetInstance<IConfigsManager>().Configs.ChaptersConfig.GetChapterByNumber(chapterNumber + 1);
                if (newChapterConfig != null)
                {
                    AddNewChapter(newChapterConfig, false);
                }
            }
            else
            {
                DebugLog($"Can not complete chapter {chapterNumber}. Its not found in progress");
            }
        }*/
        
        public ChapterProgress GetCurrentChapter()
        {
            if (ChaptersProgress.Count > 0) 
                return ChaptersProgress.Last();
            else 
                return null;
        }

        private void DebugLog(string message)
        {
            Debug.Log($"Journey save data: ".Colored(ColorType.Lightblue) + $"{message}".Colored(ColorType.Lime));
        }
    }
}
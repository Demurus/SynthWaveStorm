using DataSystem;
using GameBase;
using LevelsManagement;

namespace SpaceJourney.SaveData
{
    [System.Serializable]
    public class LevelProgress
    {
        public int LevelNumber;
        
        /// <summary>
        /// Last won stars amount
        /// </summary>
        public byte Stars;
        
        /// <summary>
        /// Last won rating
        /// </summary>
        public string Rating;

        public LevelProgress()
        {
            
        }
        
        public LevelProgress(int levelNumber, byte stars, string rating)
        {
            LevelNumber = levelNumber;
            Stars = stars;
            Rating = rating;
        }
        
        public void UpdateData(PlayLevelData data)
        {
            Stars = data.Stars;
            Rating = data.Rating;
            GameContext.GetInstance<IDataManager>().SaveGameData();
        }
    }
}
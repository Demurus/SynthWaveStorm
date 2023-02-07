using Interfaces;
using PirateMatch.DataSystem;

namespace DataSystem
{
    public interface IDataManager : IManager
    {
        /// <summary>
        /// Get this class and change anyhow you want
        /// Dont forget to call SaveGameData after all changes
        /// </summary>
        /// <returns></returns>
        GameData Data { get; }

        void SaveGameData();

        void LoadGameData();
    }
}
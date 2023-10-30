using Interfaces;
using DataSystem;
using UnityEngine.Events;

namespace DataSystem
{
    public interface IDataManager : IManager
    {
        GameData Data { get; }

        void SaveGameData();

        void LoadGameData(UnityAction success);
    }
}
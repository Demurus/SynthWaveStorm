using EventsManagement;
using GameBase;
using GameBase.DataSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DataSystem
{
    public class DataManager : MonoBehaviour, IDataManager, ISceneLoaded
    {
        private GameData _gameData;

        public GameData Data { get; }

        // private ConfigsContainer _configs;
        private const string GAME_DATA_KEY = "GameState";

        public void Init()
        {
            GameContext.GetInstance<IEventsManager>().Subscribe<ISceneLoaded>(this);
        }
        
        public void OnSceneLoaded(Scenes sceneName, LoadSceneMode mode)
        {
            
        }

        public void LoadGameData(UnityAction success)
        {
            if (SaveManager.IsFileExist(GAME_DATA_KEY))
            {
                _gameData = SaveManager.LoadSingle<GameData>(GAME_DATA_KEY);
            }

            if (_gameData == null)
            {
                Debug.Log($"<color=green> Create new Game data </color>");
                _gameData = new GameData();
                SaveGameData();
            }
            else
            {
                Debug.Log($"<color=green> Game data is exist </color>");
            }
            success?.Invoke();
        }

        public void SaveGameData()
        {
            _gameData.LastSaveVersion = Application.version;
            SaveManager.Save(_gameData, GAME_DATA_KEY);
        }

        public void Dispose()
        {
            GameContext.GetInstance<IEventsManager>().UnSubscribe<ISceneLoaded>(this);
        }
    }
}
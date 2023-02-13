using System.Collections.Generic;
using DataSystem;
using EventsManagement;
using Interfaces;
using LogTextColorExtension;
using UI.Management;
using UnityEngine;

namespace GameBase
{
    public class InitialController : MonoBehaviour
    {
        [SerializeField] private EventsManager _eventsManager;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private DataManager _dataManager;
        
        private readonly List<IManager> _managersList = new List<IManager>();
         private void Awake()
        {
            Init();

            DontDestroyOnLoad(transform.parent.gameObject);
        }

        private void RegisterManager<T>(IManager m) where T : class
        {
            GameContext.Register<T>(m as T);
            Debug.Log($"Registered {m}".Colored(ColorType.Lightblue));
            _managersList.Add(m);
        }

        protected virtual void Init()
        {
            SceneLoader.Init();
            RegisterManager<IEventsManager>(_eventsManager);
            RegisterManager<IDataManager>(_dataManager);
            RegisterManager<IUIManager>(_uiManager);
            
            
            _dataManager.LoadGameData(Continue);
            /*
            RegisterManager<IConfigsManager>(_configsManager);
            RegisterManager<ISettingsManager>(_settingsManager);
            RegisterManager<ILootTimerManager>(_lootTimerManager);
            RegisterManager<ILootManager>(_lootManager);
            RegisterManager<IAnimShower>(_itemShower);
            RegisterManager<IRewardManager>(_rewardManager);
            RegisterManager<IHeartsEconomy>(_heartsEconomy);
            RegisterManager<IJourneyManager>(_journeyManager);
            RegisterManager<ITutorialManager>(_tutorialsManager);
            RegisterManager<IMiniGameManager>(_miniGameManager);
            RegisterManager<ITreasureHuntManager>(_treasureHuntManager);
            RegisterManager<IBackgroundAnimationController>(_bgAnimationController);
            RegisterManager<IRewardAnimationManager>(_rewardAnimationManager);
            
           
            _configsManager.InitConfigs(ContinueGameLoading);*/
        }

        private void Continue()
        {
            _managersList.ForEach(manager => manager.Init());
             SceneLoader.Load(Scenes.GameMenu);
        }

        private void OnApplicationQuit()
        {
            SceneLoader.Dispose();
        }
    }
}
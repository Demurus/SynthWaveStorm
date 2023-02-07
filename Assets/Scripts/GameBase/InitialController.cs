using System.Collections.Generic;
using EventsManagement;
using Interfaces;
using UnityEngine;

namespace GameBase
{
    public class InitialController : MonoBehaviour
    {
        [SerializeField] private EventsManager _eventsManager;
        
        private readonly List<IManager> _managersList = new List<IManager>();
         private void Awake()
        {
            Init();

            DontDestroyOnLoad(transform.parent.gameObject);
        }

        private void RegisterManager<T>(IManager m) where T : class
        {
            GameContext.Register<T>(m as T);
            _managersList.Add(m);
        }

        protected virtual void Init()
        {
            RegisterManager<IEventsManager>(_eventsManager);
            /*RegisterManager<IDataManager>(_dataManager);
            RegisterManager<IUIManager>(_uiManager);
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
            
            _dataManager.LoadGameData();
            _configsManager.InitConfigs(ContinueGameLoading);*/
        }
    }
}
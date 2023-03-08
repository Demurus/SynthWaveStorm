﻿using System;
using System.Collections.Generic;
using System.Linq;
 using ChaptersSystem.Configs;
using ChaptersSystem.Enums;
 using UnityEngine;
 using UnityEngine.Events;
 using System.Collections;
 using DataSystem;
 using EventsManagement;
 using GameBase;
 using GameMenu;
 using LevelsManagement;
 using LogTextColorExtension;
 using RewardManagement;
 using SpaceJourney.SaveData;
 using UI.Management;
 using UI.View;

 namespace SpaceJourney.Management
{
    public class JourneyManager : MonoBehaviour, IJourneyManager
    {
        private IDataManager _dataManager;
        private IEventsManager _eventBus;
        private IChaptersConfigData _chaptersConfigData;
        //private IRewardManager _rewardManager;
        private IUIManager _uiManager;
        private JourneySaveData _journeySaveData;
        private bool DEBUG = false;

       // public IChaptersConfigData ChaptersConfig => _chaptersConfigData ?? (_chaptersConfigData = GameContext.GetInstance<IConfigsManager>().Configs.ChaptersConfig);
       // public JourneySaveData JourneySaves => _journeySaveData ?? (_journeySaveData = GameContext.GetInstance<IDataManager>().GetGameData().JourneySaveData);

        // group of applyable visual config variables
        private string _lastCachedVisualConfigNameApplyable;
        private string _loadingVisualConfigNameApplyable;

        // group of ONLY CHAPTER visual config variables
        private string _lastCachedVisualConfigNameChapter;
        private string _loadingVisualConfigNameChapter;

        private bool _firstLoadingHiding = true;

        //private int _lastCachedVisualsId = 0;

        public void Init()
        {
            _eventBus = GameContext.GetInstance<IEventsManager>();
          //  _eventBus.Subscribe<ILevelEnd>(this);
            _dataManager = GameContext.GetInstance<IDataManager>();
          // _rewardManager = GameContext.GetInstance<IRewardManager>();
            _uiManager = GameContext.GetInstance<IUIManager>();
           // _journeySaveData = GameContext.GetInstance<IDataManager>().GetGameData().JourneySaveData;
           // _chaptersConfigData = GameContext.GetInstance<IConfigsManager>().Configs.ChaptersConfig;

            _firstLoadingHiding = true;

            DEBUG = Debug.isDebugBuild;
        }

        public void OnLevelEnd(PlayLevelData data)
        {
        }

        public void ApplyChapterReward()
        {
           
        }

        public ChapterProgress GetCurrentChapter()
        {
            ChapterProgress badProgress = null;
            if (_journeySaveData != null)
            {
                if (_journeySaveData.GetCurrentChapter() == null)
                {
                    Debug.Log("Seding default current chapter in saves");
                    badProgress = new ChapterProgress();
                    badProgress.ChapterNumber = 1;
                    return badProgress;
                }

                return _journeySaveData.GetCurrentChapter();
            }

            Debug.Log("Sending default template progress");
            badProgress = new ChapterProgress();
            badProgress.ChapterNumber = 1;
            return badProgress;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
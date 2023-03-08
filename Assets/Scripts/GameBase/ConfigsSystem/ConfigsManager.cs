﻿using System;
 using ChaptersSystem.Configs;
 using UnityEngine;
 using LogTextColorExtension;

 namespace Data.ConfigsSystem
{
    public class ConfigsManager : MonoBehaviour, IConfigsManager
    {
        [SerializeField] private ChapterConfigsHolder _chaptersConfig;

        private ConfigsContainer _configsContainer;

        public ConfigsContainer Configs
        {
            get
            {
                if (_configsContainer == null)
                {
                    Debug.Log("Configs container is NOT initialized yet!".Colored(ColorType.Red));
                }

                return _configsContainer;
            }
        }
        
       

        public IConfig GetConfigByDefault<T>(string path) where T : UnityEngine.Object
        {
            return Configs.GetConfigByDefault<T>(path);
        }
        

        public void InitConfigs(Action onConfigsInitialized)
        {
            _configsContainer = new ConfigsContainer();
            _configsContainer.ChaptersConfig = _chaptersConfig;
            onConfigsInitialized?.Invoke();
        }
        
        public void Init()
        {
        }
        
        public void Dispose()
        {
        }
    }
}
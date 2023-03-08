using ChaptersSystem.Configs;
using UnityEngine;

namespace Data.ConfigsSystem
{
    [System.Serializable]
    public class ConfigsContainer
    {
        private IChaptersConfigData _chapterConfigData;

        public IChaptersConfigData ChaptersConfig
        {
            get => _chapterConfigData ?? (_chapterConfigData = GetConfigByDefault<ChapterConfigsHolder>(ConfigsPath.CHAPTERS_CONFIG_HOLDER) as IChaptersConfigData);
            set => _chapterConfigData = value;
        }
        
        public IConfig GetConfigByDefault<T>(string path) where T : Object
        {
            return Resources.Load<T>(path) as IConfig;
        }
    }
}
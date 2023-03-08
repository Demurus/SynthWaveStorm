using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Data.ConfigsSystem
{
    public interface IConfigsManager : IManager
    {
        ConfigsContainer Configs { get; }
        IConfig GetConfigByDefault<T>(string path) where T : Object;
    }
}
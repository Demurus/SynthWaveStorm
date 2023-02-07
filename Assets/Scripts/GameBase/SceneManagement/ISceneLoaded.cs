using EventsManagement;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public interface ISceneLoaded : IEventsManagerSubscriber
    {
        void OnSceneLoaded(Scenes sceneName, LoadSceneMode mode);
    }
}
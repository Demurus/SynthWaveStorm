using EventsManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public static class SceneLoader
    {
        public static void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public static void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        public static void Load(Scenes sceneName)
        {
            // SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneName.ToString());
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //SceneManager.sceneLoaded -= OnSceneLoaded;
            Scenes parsedName = (Scenes) System.Enum.Parse(typeof(Scenes), scene.name);
            GameContext.GetInstance<IEventsManager>().Fire<ISceneLoaded>(s => s.OnSceneLoaded(parsedName, mode));
        }

        public static Scenes GetCurrentSceneName()
        {
            string name = SceneManager.GetActiveScene().name;
            Scenes parsedName = (Scenes) System.Enum.Parse(typeof(Scenes), name);
            return parsedName;
        }
    }

    public enum Scenes
    {
        InitScene,
        GameMenu,
        LevelScene
    }
}
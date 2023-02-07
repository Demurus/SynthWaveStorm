using EventsManagement;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public static class SceneLoader
    {
        public static void Load(Scenes sceneName)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneName.ToString());
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
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
        MenuScene,
        LevelScene
    }
}
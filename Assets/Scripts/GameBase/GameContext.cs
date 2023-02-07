using System.Collections.Generic;

namespace GameBase
{
    class GameContext
    {
        private static Dictionary<string, object> s_instanceByKey = new Dictionary<string, object>();

        public static void Register(string key, object instance)
        {
            s_instanceByKey[key] = instance;
        }

        public static void Register<U>(U instance) where U : class
        {
            string key = typeof(U).ToString();
            Register(key, instance);
        }

        public static T GetInstance<T>(string key) where T : class
        {
            if (s_instanceByKey.ContainsKey(key))
                return s_instanceByKey[key] as T;

            return null;
        }

        public static T GetInstance<T>() where T : class
        {
            string key = typeof(T).ToString();
            return GetInstance<T>(key);
        }

        public static void Unregister<U>(U instance) where U : class
        {
            string key = typeof(U).ToString();
            if (s_instanceByKey.ContainsKey(key))
            {
                s_instanceByKey.Remove(key);
            }
        }
    }
}
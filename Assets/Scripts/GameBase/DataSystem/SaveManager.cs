using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;

namespace GameBase.DataSystem
{
     public class SaveManager
    {
        private static int s_fileCounter = 0;
        private static readonly string s_folderName = "/SavedData/";
        private static readonly string s_dotJson = ".json";
        private static string s_path = Application.persistentDataPath + s_folderName + s_fileCounter + s_dotJson;

        public static void Save(object data, string fileName)
        {
            CombinePath(fileName);

            var settings = new JsonSerializerSettings
            {
                // This tells your serializer that multiple references are okay.
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data, Formatting.None, settings);

            File.WriteAllText(s_path, jsonData);
        }

        public static IList<T> LoadCollection<T>(string fileName)
        {
           
            if (IsFileExist(fileName))
            {
                string data = File.ReadAllText(s_path);

                return JsonConvert.DeserializeObject<IList<T>>(data);
            } 
            else return default(IList<T>);
        }
        
        public static T LoadSingle<T>(string fileName)
        {
            if (IsFileExist(fileName))
            {
                string data = File.ReadAllText(s_path);

                return JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings()
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                });
            }
            else return default(T);
        }

        public static bool IsFileExist(string fileName)
        {
            CombinePath(fileName);
            return File.Exists(s_path);
        }

        private static void CombinePath(string fileName)
        {
            CheckDirectory();
            s_path = Application.persistentDataPath + s_folderName + fileName + s_dotJson;
        }

        private static void CheckDirectory()
        {
            var directory =Application.persistentDataPath + s_folderName;
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void RemoveData(string fileName)
        {
            if (IsFileExist(fileName))
            {
                Debug.Log(s_path + fileName + " was finded and removed");
                File.Delete(s_path);
            }
        }
    }
}
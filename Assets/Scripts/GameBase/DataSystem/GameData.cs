using SpaceJourney.SaveData;

namespace DataSystem
{
    public class GameData
    {
        public string LastSaveVersion;
        public JourneySaveData JourneySaveData;
        public GameData()
        {
           JourneySaveData = new JourneySaveData();
        }
    }
}
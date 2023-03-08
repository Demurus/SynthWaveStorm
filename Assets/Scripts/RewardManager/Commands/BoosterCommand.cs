/*using PirateMatch.DataSystem;
using PirateMatch.Shop;
using UI.Home.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace RewardManagement.Commands
{
    public class BoosterCommand : ICommand
    {
        private IDataManager _dataManager;

        public void Execute(CommandData commandData, UnityAction onSuccess, UnityAction onFailed)
        {
            if (!(commandData is BoosterCommandData bcd))
            {
                onFailed?.Invoke();
                Debug.LogError(@$"Invalid data type. Valid data type: {typeof(BoosterCommandData).FullName}. Received data type: {commandData.GetType().FullName}");
                return;
            }

            _dataManager = GameContext.GetInstance<IDataManager>();
            _dataManager.GetGameData().AddBoostersNumber(bcd.BoosterData.BoosterType, bcd.BoosterData.Count, bcd.BoosterData.FreeCount);

            onSuccess?.Invoke();

            if (bcd.Source == RewardSource.Store && SceneLoader.GetCurrentSceneName() == Scenes.TestLevel)
                return;

            GameContext.GetInstance<IAnimShower>().AddAnimation(new RewardAnimationData(RewardAnimationType.Boosters, bcd.BoosterData));
        }
    }
}*/
/*using Data;
using Data.Configs.Gameplay;
using PirateMatch.DataSystem;
using PirateMatch.Shop;
using UI.Home.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace PirateMatch.RewardManagement.Commands
{
    public class CoinsCommand : ICommand
    {
        private IDataManager _dataManager;

        public void Execute(CommandData commandData, UnityAction onSuccess, UnityAction onFailed)
        {
            if (!(commandData is CoinsCommandData ccd))
            {
                onFailed?.Invoke();
                Debug.LogError(@$"Invalid data type. Valid data type: {typeof(CoinsCommandData).FullName}. Received data type: {commandData.GetType().FullName}");
                return;
            }

            _dataManager = GameContext.GetInstance<IDataManager>();
            _dataManager.GetGameData().AddCoins(ccd.Value);

            onSuccess?.Invoke();
            if (ccd.Source == RewardSource.Store && SceneLoader.GetCurrentSceneName() == Scenes.TestLevel)
                return;
            if (ccd.Source == RewardSource.Store && GamePlayConfigurator.GamePlayMode == GamePlayMode.TreasureHunt)
                return;

            GameContext.GetInstance<IAnimShower>().AddAnimation(new RewardAnimationData(RewardAnimationType.Coins, ccd.Value));
        }
    }
}*/
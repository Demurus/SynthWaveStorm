/*using System;
using System.Collections.Generic;
using Loot.Enums;
using Loot.Reward;
using PirateMatch.DataSystem;
using PirateMatch.LogTextColorExtension;
using PirateMatch.RewardManagement.Commands;
using PreLevelBoosters;
using UI.IngameUI;
using UI.IngameUI.PopUps;
using UI.UIManagement;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

namespace RewardManagement
{
    public class RewardManager : MonoBehaviour, IRewardManager
    {
        public void Init()
        {
        }

        public void Execute(ICommand command, CommandData data, UnityAction onFinished = null, UnityAction onFailed = null)
        {
            command.Execute(data, onFinished, onFailed);
        }

        public void ApplyReward(RewardData rewardData, UnityAction onApplyFinished = null)
        {
            ApplyReward(rewardData, onApplyFinished);
        }

        public void ApplyReward(RewardData rewardData, UnityAction onApplyFinished = null)
        {
            switch (rewardData.RewardType)
            {
                case RewardType.Coins:
                    Execute(new CoinsCommand(), new CoinsCommandData(rewardData.Amount, source));
                    break;
                case RewardType.UnlimitedHeartsTime:
                    Execute(new HeartsCommand(), new HeartsCommandData(RewardType.UnlimitedHeartsTime, rewardData.Amount, source));
                    break;
                case RewardType.Hearts:
                    Execute(new HeartsCommand(), new HeartsCommandData(RewardType.Hearts, rewardData.Amount, source));
                    break;
                case RewardType.Booster:
                    Execute(new BoosterCommand(), new BoosterCommandData(rewardData.BoosterData, source));
                    break;
                case RewardType.Cannon:
                    Execute(new PreBoosterCommand(), new PreBoosterCommandData(rewardData.Amount, PreBoosterType.Cannon, source));
                    break;
                case RewardType.Joker:
                    Execute(new PreBoosterCommand(), new PreBoosterCommandData(rewardData.Amount, PreBoosterType.Joker, source));
                    break;
                case RewardType.Extra:
                    Execute(new PreBoosterCommand(), new PreBoosterCommandData(rewardData.Amount, PreBoosterType.Extra, source));
                    break;
                case RewardType.LootStars:
                    Execute(new LootStarsCommand(), new LootStarsCommandData(rewardData.Amount, source));
                    break;
                case RewardType.TikiTiles:
                    Execute(new TikiTilesCommand(), new TikiTilesCommandData(rewardData.Amount, source));
                    break;
                case RewardType.TreasureHuntMapPiece:
                    Execute(new TreasureHuntMapCommand(), new TreasureHuntMapCommandData(rewardData.Amount, source));
                    break;
                default:
                    Debug.Log($"No implementation for {rewardData.RewardType} was found!".Colored(ColorType.Red));
                    break;
            }

            GameContext.GetInstance<IDataManager>().SaveGameData();
            onApplyFinished?.Invoke();
        }

        public void ApplyChest(ChestType chestType, ChestOpenerPopUpType popUpType, int chestRank, UnityAction onApplyFinished, UnityAction onAnimationFinished)
        {
            List<RewardData> chestRewards = LootRewardCalculator.CalculateChestReward(chestType, chestRank);
            ChestOpenerPopUpData popUpData = new ChestOpenerPopUpData(chestType, popUpType, chestRank, String.Empty, chestRewards);
            ApplyRewards(popUpData, onApplyFinished, onAnimationFinished);
        }

        public void ApplyRewards(List<RewardData> rewards, RewardSource source, UnityAction onApplyFinished = null)
        {
            foreach (RewardData reward in rewards)
            {
                ApplyReward(reward, source);
            }

            onApplyFinished?.Invoke();
        }

        public void ApplyRewards(List<RewardData> rewards, RewardSource source, bool animateRewards, UnityAction onFinished)
        {
            if (animateRewards)
            {
                GameContext.GetInstance<IEventBus>().Subscribe<IEndAllRewardAnim>(this);
                foreach (RewardData reward in rewards)
                {
                    ApplyReward(reward, source);
                }

                OnRewardAnimationEnd = onFinished;
                GameContext.GetInstance<IAnimShower>().ShowQueue();
            }
            else
            {
                ApplyRewards(rewards, source, onFinished);
            }
        }

        public void ApplyRewards(ChestOpenerPopUpData popUpData, UnityAction onApplyFinished, UnityAction onAnimationsFinished)
        {
            GameContext.GetInstance<IEventBus>().Subscribe<IEndAllRewardAnim>(this);

            ApplyRewards(popUpData.Rewards, RewardSource.Bonus, onApplyFinished);

            popUpData.FinishedCallback += AnimateGoods;
            if (onAnimationsFinished != null) OnRewardAnimationEnd = onAnimationsFinished;

            GameContext.GetInstance<IUIManager>().ShowView(UIViewType.ChestOpener, popUpData);

            void AnimateGoods()
            {
                popUpData.FinishedCallback -= AnimateGoods;
                GameContext.GetInstance<IAnimShower>().ShowQueue();
            }
        }

        public void OnAllRewardAnimationEnd()
        {
            GameContext.GetInstance<IEventBus>().UnSubscribe<IEndAllRewardAnim>(this);
            OnRewardAnimationEnd?.Invoke();
            OnRewardAnimationEnd = null;
        }

        public void Dispose()
        {
        }
    }
}*/
/*﻿using System.Collections.Generic;
using Base.Initials.Interfaces;
 using Interfaces;
 using Loot.Enums;
using PirateMatch.RewardManagement.Commands;
using UI.IngameUI.PopUps;
using UnityEngine.Events;

namespace RewardManagement
{
    public interface IRewardManager : IManager
    {
        void Execute(ICommand simpleCommand, CommandData data, UnityAction onFinished = null, UnityAction onFailed = null);
        void ApplyReward(RewardData rewardData, RewardSource source, UnityAction onFinished = null);
        
        /// <summary>
        /// Applies reward with ability to animate it
        /// </summary>
        /// <param name="rewardData">Reward</param>
        /// <param name="source">Granted item source</param>
        /// <param name="animateRewards">Should reward be animated after apply</param>
        /// <param name="onApplyFinished">Callback to rewards applying, NOT animation(1st stage, before animation)</param>
        /// <param name="onAnimationFinished">Callback for when all rewards were animated(2nd stage, all animations finished, if animateRewards is true)
        /// NOT called if animateRewards is false</param>
        void ApplyReward(RewardData rewardData, RewardSource source, bool animateRewards, UnityAction onApplyFinished = null, UnityAction onAnimationFinished = null);

        /// <summary>
        /// Applies list of rewards and shows their animation when in Home Scene
        /// </summary>
        /// <param name="rewards"></param>
        /// <param name="source">Granted items source</param>
        /// <param name="onApplyFinished">Callback to rewards applying, NOT animation</param>
        void ApplyRewards(List<RewardData> rewards, RewardSource source, UnityAction onApplyFinished = null);

        /// <summary>
        /// Applies list of rewards.
        /// If animateRewards is true - manager applies rewards and tries launch animations immediately
        /// If false - manager applies rewards and shows their animation when in Home Scene
        /// </summary>
        /// <param name="rewards"></param>
        /// <param name="onFinished">Callback to end all reward animations</param>
        ///  /// <param name="source">Granted items source</param>
        /// <param name="animateRewards">Should manager try animate rewards immediately?</param>
        void ApplyRewards(List<RewardData> rewards, RewardSource source, bool animateRewards, UnityAction onFinished);
    }
}*/
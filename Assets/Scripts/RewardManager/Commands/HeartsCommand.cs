/*using UnityEngine;
using UnityEngine.Events;

namespace RewardManagement.Commands
{
    public class HeartsCommand : ICommand
    {
        public void Execute(CommandData commandData, UnityAction onSuccess, UnityAction onFailed)
        {
            if (!(commandData is HeartsCommandData hcd))
            {
                onFailed?.Invoke();
                Debug.LogError(@$"Invalid data type. Valid data type: {typeof(HeartsCommandData).FullName}. Received data type: {commandData.GetType().FullName}");
                return;
            }

            //NOT animate. True if reward is purchased and player is currently on level scene. Maybe should be implemented in more productive way
            bool notAnimate = hcd.Source == RewardSource.Store && SceneLoader.GetCurrentSceneName() == Scenes.TestLevel;
          
            switch (hcd.HeartsType)
            {
                case RewardType.UnlimitedHeartsTime:
                    if (hcd.Value > 0)
                    {
                        if(notAnimate)
                            GameContext.GetInstance<IEventBus>().Emmit<IStartUnlimitedHearts>(u => u.AddUnlimitedHeartsTime(hcd.Value, true));
                        else
                        {
                            GameContext.GetInstance<IEventBus>().Emmit<IStartUnlimitedHearts>(u => u.AddUnlimitedHeartsTime(hcd.Value, false));
                            GameContext.GetInstance<IAnimShower>().AddAnimation(new RewardAnimationData(RewardAnimationType.UnlimitedHearts, hcd.Value));
                        }
                           
                    }
                    break;
                case RewardType.Hearts:
                    if (hcd.Value > 0)
                    {
                        GameContext.GetInstance<IDataManager>().GetGameData().AddHearts(hcd.Value);
                        
                        if (notAnimate)return;
                        GameContext.GetInstance<IAnimShower>().AddAnimation(new RewardAnimationData(RewardAnimationType.Heart, hcd.Value));
                    }
                    break;
            }
            onSuccess?.Invoke();
        }
        
    }
}*/
using UnityEngine.Events;

namespace RewardManagement.Commands
{
    public interface ICommand
    {
        void Execute(CommandData commandData, UnityAction onSuccess, UnityAction onFailed);
    }
}
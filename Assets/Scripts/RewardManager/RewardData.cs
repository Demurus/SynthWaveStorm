namespace RewardManagement
{
    public struct RewardData
    {
        public RewardType RewardType;
        public int Amount;

        public RewardData(RewardType type, int amount)
        {
            RewardType = type;
            Amount = amount;
        }
    }
}
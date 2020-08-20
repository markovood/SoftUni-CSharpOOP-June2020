namespace CounterStrike.Models.Guns.Contracts
{
    public interface IGun
    {
        public string Name { get; }

        int BulletsCount { get; }

        int Fire();
    }
}

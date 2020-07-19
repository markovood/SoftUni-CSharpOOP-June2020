using Recharge_After.Contracts;

namespace Recharge_After
{
    public class Robot : IWorker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            this.Work(hours);
            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }
    }
}
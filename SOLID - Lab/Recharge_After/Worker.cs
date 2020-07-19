using Recharge_After.Contracts;

namespace Recharge_After
{
    public abstract class Worker : IWorker, ISleeper
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }

        public abstract void Sleep();
    }
}
using Recharge_After.Contracts;

namespace Recharge_After
{
    public class Employee : Worker
    {
        public Employee(string id) : base(id)
        {
        }

        public override void Sleep()
        {
            // sleep...
        }
    }
}
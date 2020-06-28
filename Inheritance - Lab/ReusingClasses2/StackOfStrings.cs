using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(Stack<string> range)
        {
            foreach (var item in range)
            {
                base.Push(item);
            }
        }
    }
}

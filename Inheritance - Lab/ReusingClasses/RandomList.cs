using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random indexGenerator = new Random();
        public string RandomString()
        {
            return base[this.indexGenerator.Next(0, base.Count)];
        }
    }
}

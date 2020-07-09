using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int INITIAL_INDEX = 0;

        private List<string> data;

        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }

        public int Add(string item)
        {
            this.data.Insert(INITIAL_INDEX, item);

            return INITIAL_INDEX;
        }

        public string Remove()
        {
            string item = this.data.Last();
            this.data.Remove(item);

            return item;
        }
    }
}
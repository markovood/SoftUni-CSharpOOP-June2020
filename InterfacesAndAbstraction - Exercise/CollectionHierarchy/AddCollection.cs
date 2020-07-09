using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> data;
        private int index;

        public AddCollection()
        {
            this.data = new List<string>();
            this.index = -1;
        }

        public int Add(string item)
        {
            this.data.Add(item);
            this.index++;
            return this.index;
        }
    }
}
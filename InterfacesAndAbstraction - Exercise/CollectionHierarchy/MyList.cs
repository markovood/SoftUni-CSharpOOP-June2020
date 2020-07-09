using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private const int INITIAL_INDEX = 0;

        private List<string> data;

        public MyList()
        {
            this.data = new List<string>();
        }

        public int Used => this.data.Count;

        public int Add(string item)
        {
            this.data.Insert(INITIAL_INDEX, item);

            return INITIAL_INDEX;
        }

        public string Remove()
        {
            string item = this.data.First();
            this.data.RemoveAt(0);

            return item;
        }
    }
}
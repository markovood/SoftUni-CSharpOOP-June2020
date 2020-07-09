using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            List<int> addCollResults = new List<int>();
            List<int> addRemCollResults = new List<int>();
            List<int> myListCollResults = new List<int>();

            foreach (var element in elements)
            {
                addCollResults.Add(addCollection.Add(element));
                addRemCollResults.Add(addRemoveCollection.Add(element));
                myListCollResults.Add(myList.Add(element));
            }

            Console.WriteLine(string.Join(' ', addCollResults));
            Console.WriteLine(string.Join(' ', addRemCollResults));
            Console.WriteLine(string.Join(' ', myListCollResults));

            int removeCount = int.Parse(Console.ReadLine());

            List<string> addRemoveResults = new List<string>();
            List<string> myListResults = new List<string>();
            
            for (int i = 0; i < removeCount; i++)
            {
                addRemoveResults.Add(addRemoveCollection.Remove());
                myListResults.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addRemoveResults));
            Console.WriteLine(string.Join(' ', myListResults));
        }
    }
}
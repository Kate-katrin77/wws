using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MergeNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };

            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };

            Console.WriteLine(String.Join(", ", UniqueNames(names1, names2)));
        }

        //public static string[] UniqueNames(string[] names1, string[] names2)
        //{

        //    throw new NotImplementedException();
        //}

        //Changed the sugnature of the method to pass in params
        public static string[] UniqueNames(params string[][] values)
        {
            //flatten out nested arrays
            var myList = values.SelectMany(x => x).ToList();

            //using hashset to remove duplicates and return only distinct values
            var hash = new HashSet<string>();

            foreach (var item in myList)
            {
                hash.Add(item);
            }
            return hash.ToArray();
        }

    }
}

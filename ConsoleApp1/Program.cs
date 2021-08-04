using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 3, 5,5,5,5, 3, 2, 7, 7, 7, 5, 6 };
            list.Sort((a, b) => b.CompareTo(a));
            IEnumerable<int> duplicates = list.GroupBy(x => x)
                                            .Where(g => g.Count() >= 1)
                                            .Select(x => x.Key);

            var groups = list.GroupBy(v => v).ToDictionary(x => x.Key, y => y.Count()).OrderByDescending(d => d.Value).Take(3);


            Console.WriteLine(groups);
        }
    }
}

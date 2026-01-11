using System;
using System.Collections.Generic;

namespace SortedSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<int> a = new SortedSet<int> { 40, 2, 4, 6, 8, 10 };
            SortedSet<int> b = new SortedSet<int> { 15,1, 3, 5, 7, 9, 10 };


            PrintSortedSet(a);
            Console.WriteLine("");

            //union
            SortedSet<int> c = new SortedSet<int>(a);
            
            c.UnionWith(b); //Junta os elementos de B com o C
            PrintSortedSet(c);
            Console.WriteLine("");

            //intersection (iguais)
            SortedSet<int> d = new SortedSet<int>(a);
            d.IntersectWith(b);
            PrintSortedSet(d);
            Console.WriteLine("");

            //difference
            SortedSet<int> e = new SortedSet<int>(a);
            e.ExceptWith(b);
            PrintSortedSet(e);


            Console.ReadLine();

        }

        static void PrintSortedSet<T>(IEnumerable<T> sortedset)
        {
            foreach (T t in sortedset)
            {
                Console.Write(t + " ");
            }
        }
    }
}

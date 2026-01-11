using System;
using System.Collections.Generic;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> list = new HashSet<string>();

            list.Add("TV");
            list.Add("Nootbook");
            list.Add("Tablet");

            Console.WriteLine(list.Contains("TV"));

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}

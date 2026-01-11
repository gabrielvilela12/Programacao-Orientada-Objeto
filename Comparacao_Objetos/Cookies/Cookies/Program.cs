using System;
using System.Collections.Generic;

namespace Cookies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> d_test = new Dictionary<string, string>();
   
            d_test.Add("Name", "João");
            d_test.Add("Mail", "Joãopedro@gmail.com");
            d_test.Add("Phone", "16929338359");
            
            foreach(var key in d_test)
            {
                Console.WriteLine(key);
            }

            Console.ReadLine();
        }
    }
}

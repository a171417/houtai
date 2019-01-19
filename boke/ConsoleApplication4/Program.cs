using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numlist = { 10, 20, 30, 40, 44, 11, 21, 31, 41 };
            //var query1 = from x in numlist
            //             where x % 2 == 0
            //             select x;
            //var query2 = numlist.where(x => x % 2 == 0).orderby(x => x).firstordefault();
            //foreach (var item in query1)
            //{
            //    console.writeline(item.tostring() + "");
            //}
            string[] names = { "abc", "aaa", "bde", "123" };
            var query = from w in names
                        where w.Contains("a")
                        select w;
            foreach(var item in query )
            {
                Console.WriteLine(item.ToString() + "");
            }
            Console.ReadKey();
        }
    }
}

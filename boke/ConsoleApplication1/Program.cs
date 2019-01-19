using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AddClass();
            Console.WriteLine("按任意键退出！");
            Console.ReadKey();
        }
        static void AddClass()
        {
            Console.WriteLine("请输入！");
            string na = Console.ReadLine();
            Class classs = new Class();
            classs.classID = na;
            ClassLayer ccl = new ClassLayer();
            ccl.Add(classs);

        }
    }
}

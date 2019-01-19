using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shopping> StudentList = new List<Shopping>();

            Shopping sp = new Shopping();

            sp.name = "费祥";
            sp.price = 0;
            sp.production = "上思";

            StudentList.Add(sp);

            foreach (var item in StudentList)
            {
                Console.Write("产品名字：{0} 价格：{1} 生产地：{2}", item.name, item.price, item.production);
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Models;
using System.Data.Entity;


namespace ConsoleApplication1.BusinessLayer
{
   public class ClassLayer
    {
        public void Add(Class classs)
        {
            using (var db=new ClassContext())
            {
                db.Classts.Add(classs);
                db.SaveChanges();
            }
        }
        public List<Class> Query()
        {
            using (var db = new ClassContext())
            {
                //Linq查询所有的博客。以博客名为排序依序返回数据集
                var query = from b in db.Classts
                            orderby b.classID
                            select b;
                //将数据集装换为列表
                return query.ToList();
            }
        }


    }
}

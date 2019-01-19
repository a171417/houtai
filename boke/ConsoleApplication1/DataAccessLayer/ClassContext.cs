using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using System.Data.Entity;

namespace ConsoleApplication1.DataAccessLayer
{
   public class ClassContext:DbContext
    {
        public DbSet<Class> Classts { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

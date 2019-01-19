using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
   public class Student
    {
        public int StudentID { get; set; }
        public string name { get; set; }
        public virtual Class Classes { get; set; }
    }
}

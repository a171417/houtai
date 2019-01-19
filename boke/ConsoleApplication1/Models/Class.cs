using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
   public class Class
    {
        public string classID { get; set; }
        public int studentID { get; set; }
        public virtual List<Student> Students { get;set; }
    }
}

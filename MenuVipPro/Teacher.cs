using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{
    public class Teacher : Student
    {
        public int ID { get; set; }
        public string Subject { get; set; }
    }
}

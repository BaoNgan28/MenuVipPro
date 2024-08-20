using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manage manage = new Manage();
            Selection selection = new Selection();
            Handle handle = new Handle(selection);
            MenuStart menu = new MenuStart(handle);
            menu.menuStart();
            

        }
    }
}

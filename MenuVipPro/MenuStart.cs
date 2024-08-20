using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{   
    public class MenuStart
    {
        private string[] menuItems = { "MANAGE STUDENT", "CLASS", "POINT", "ADJUST" };
        private Handle handle;

        public MenuStart(Handle handle)
        {
            this.handle = handle;
        }

        public void menuStart()
        {
            while (true)
            {
                Console.Clear();
                showMenu(menuItems);
                int position = Handle.HandleKey(menuItems);

                if (position == -1) 
                {
                    handle.Select(); 
                }
            }
        }

        public void showMenu(string[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (i == Handle.positions)
                {
                    Handle.print_Position($"<> {item[i]} <>", 50, 10 + i * 2, ConsoleColor.DarkGreen);
                }
                else
                {
                    Handle.print_Position(item[i], 52, 10 + i * 2, ConsoleColor.DarkYellow);
                }
            }
        }

    }
}

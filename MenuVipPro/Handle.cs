using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{
    public class Handle
    {
        public static int positions { get; set; }
        private Selection selection;
 
        public Handle(Selection selection)
        {
            this.selection = selection;
        }

        public static int HandleKey(string[] array)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
            {
                if (positions == 0)
                {
                    positions = array.Length;
                }
                positions--;
            }
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                positions++;
                if (positions == array.Length)
                    positions = 0;
            }
            if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
            {
                return -1;
            }
            return positions;
        }

        public void Select()
        {
            switch (positions)
            {
                case 1:
                    Console.Clear();
                    selection.showClass();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    selection.showPoint();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    selection.showAdjust();
                    Console.ReadKey();
                    break;
            }
        }

        public static void print_Position(string s, int x, int y, ConsoleColor color)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}

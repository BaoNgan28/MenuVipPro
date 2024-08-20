using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{
    public class Selection
    {
        private string[] classItems = { "23DTHA4", "23DTHA5" };
        private string[] pointItems = { "23DTHA4", "23DTHA5" };
        private string[] adjustItems = { "ADD STUDENT", "DELETE", "FIND" };
        private Manage manage = new Manage();
        //LỚP
        public void showClass()
        {
            Handle.reset();
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < classItems.Length; i++)
                {
                    if (i == Handle.positions)
                    {
                        Handle.print_Position($"<> {classItems[i]} <>", 50, 10 + i * 2, ConsoleColor.DarkCyan);
                    }
                    else
                    {
                        Handle.print_Position(classItems[i], 52, 10 + i * 2, ConsoleColor.DarkMagenta);
                    }
                }
                int position = Handle.HandleKey(classItems);

                //nhấn Enter
                if (position == -1)
                {
                    string choose = classItems[Handle.positions];
                    manage.showCLASS(choose);
                    Handle.print_Position("Press anykey to comeback...", 0, 25, ConsoleColor.DarkMagenta);
                    break; //Tại sao break ở đây thì quay về trang chính
                }
            }
        }
        //điểm
        public void showPoint()
        {
            Handle.reset();
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < pointItems.Length; i++)
                {
                    if (i == Handle.positions)
                    {
                        Handle.print_Position($"<> {pointItems[i]} <>", 50, 10 + i * 2, ConsoleColor.DarkCyan);
                    }
                    else
                    {
                        Handle.print_Position(pointItems[i], 52, 10 + i * 2, ConsoleColor.DarkMagenta);
                    }
                }
                int position = Handle.HandleKey(pointItems);
                if (position == -1)
                {
                    string choose = pointItems[Handle.positions];
                    manage.showPOINT(choose);
                    Handle.print_Position("Press anykey to comeback...", 0, 25, ConsoleColor.DarkMagenta);
                    break;
                }
            }
        }
        //diều chỉnh
        public void showAdjust()
        {
            Handle.reset();
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < adjustItems.Length; i++)
                {
                    if (i == Handle.positions)
                    {
                        Handle.print_Position($"<> {adjustItems[i]} <>", 50, 10 + i * 2, ConsoleColor.DarkCyan);
                    }
                    else
                    {
                        Handle.print_Position(adjustItems[i], 52, 10 + i * 2, ConsoleColor.DarkMagenta);
                    }
                }
                int position = Handle.HandleKey(adjustItems);
                if (position == -1)
                {
                    switch(Handle.positions)
                    {
                        case 0:
                            manage.add_Student();
                            break;
                        case 1:
                            Console.Clear();
                            Handle.print_Position("BẠN MUỐN XOÁ SINH VIÊN LỚP: ", 52, 10, ConsoleColor.DarkBlue);
                            string Class = Convert.ToString(Console.ReadLine());
                            manage.showCLASS(Class);
                            Handle.print_Position("ID CẦN XOÁ: ", 52, 25, ConsoleColor.DarkBlue);
                            int ID = Convert.ToInt32(Console.ReadLine());
                            manage.Delete(ID);
                            Console.Clear();
                            manage.showCLASS(Class);
                            break;
                        case 2:
                            Console.Clear();

                            break;
                    }
                    Handle.print_Position("Press anykey to comeback...", 0, 25, ConsoleColor.DarkMagenta);
                    break;
                }
            }
        }
    }
}

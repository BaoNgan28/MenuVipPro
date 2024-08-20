using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MenuVipPro
{
    public class Manage
    {
        private List<Student> Liststudents;
        public Manage()
        {
            Liststudents = new List<Student>();
            Data();
        }
        //data mẫu
        public void Data()
        {
            //giáo viên 23dtha4
            Liststudents.Add(new Teacher { Name = "Quang Mắt Lòi", Age = 40, gender = "Nam", Class = "23DTHA4" });
            //sinh viên 23dtha4
            Liststudents.Add(new Student { Stt = 1, Name = "Nguyễn Trường Phát", Age = 19, gender = "Nữ", Class = "23DTHA4" , GPA = 3.5});
            Liststudents.Add(new Student { Stt = 2, Name = "Nguyễn Thanh Bảo Ngân", Age = 19, gender = "Nữ", Class = "23DTHA4", GPA = 3.6 });
            Liststudents.Add(new Student { Stt = 3, Name = "Huỳnh Ngọc Anh Tuấn", Age = 19, gender = "Nam", Class = "23DTHA4", GPA = 4.0 });
            //giáo viên 23dtha5
            Liststudents.Add(new Teacher { Name = "Nguyễn Công Quang", Age = 40, gender = "Nam", Class = "23DTHA5" });
            //sinh viên 23 dtha5
            Liststudents.Add(new Student { Stt = 1, Name = "Nguyễn Trường Phát", Age = 19, gender = "Nữ", Class = "23DTHA5", GPA = 4.0 });
            Liststudents.Add(new Student { Stt = 2, Name = "Nguyễn Thanh Bảo Ngân", Age = 19, gender = "Nữ", Class = "23DTHA5", GPA = 3.6 });
            Liststudents.Add(new Student { Stt = 3, Name = "Huỳnh Ngọc Anh Tuấn", Age = 19, gender = "Nam", Class = "23DTHA5", GPA = 3.5 });
            Liststudents.Add(new Student { Stt = 4, Name = "Lê Huỳnh Ngọc", Age = 19, gender = "Nam", Class = "23DTHA5", GPA = 3.8 });
        }
        //nhap sv
        public void add_Student()
        {
            Console.Clear();
            Student sv = new Student();
            Handle.print_Position("HỌ TÊN : ", 52, 10, ConsoleColor.DarkYellow);
            sv.Name = Convert.ToString(Console.ReadLine());
            Handle.print_Position("GIỚI TÍNH: ", 52, 12, ConsoleColor.DarkYellow);
            sv.gender = Convert.ToString(Console.ReadLine());
            Handle.print_Position("TUỔI: ", 52, 14, ConsoleColor.DarkYellow);
            sv.Age = Convert.ToInt32(Console.ReadLine());
            Handle.print_Position("GPA: ", 52, 16, ConsoleColor.DarkYellow);
            sv.GPA = Convert.ToInt32(Console.ReadLine());
            Liststudents.Add(sv);
        }
        //xoa sv theo stt
        public void Delete(int Stt)
        {
            Handle.print_Position("NHẬP STT CẦN XOÁ: ", 52, 10, ConsoleColor.DarkBlue);
            Liststudents.Remove(Liststudents[Stt - 1]);
        }
        //tim kiem
        public List<Student> findName(string array)
        {
            List<Student> search = new List<Student>();
            if (Liststudents != null && Liststudents.Count > 0)
            {
                foreach (Student student in Liststudents)
                {
                    if (student.Name.ToLower().Contains(array.ToLower()))
                    {
                        search.Add(student);
                    }
                }
            }
            return search;
        }

        //xếp loại gpa:
        public string arrange(Student student)
        {
            if (student.GPA >= 3.6)
            {
                student.Grade = "XUẤT SẮC";
            }
            else if (student.GPA >= 3.2 && student.GPA < 3.6)
            {
                student.Grade = "GIỎI";
            }
            else if (student.GPA >= 2.5 && student.GPA < 3.2)
            {
                student.Grade = "KHÁ";
            }
            else
            {
                student.Grade = "TRUNG BÌNH";
            }
            return student.Grade;
        }
        //SHOW DS LỚP HIỆN CÓ
        public void showCLASS(string className)
        {
            Console.Clear();
            Handle.print_Position($"DANH SÁCH LỚP {className}", 40, 13, ConsoleColor.Cyan);
            int displayIndex = 0;
            foreach (var student in Liststudents)
            {
                if (student.Class == className)
                {
                    if (student is Teacher)
                    {
                        Handle.print_Position("GIÁO VIÊN GIẢNG DẠY:", 43, 10, ConsoleColor.Cyan);
                        Handle.print_Position($"{student.Name}", 43, 11, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 68, 11, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Age}", 73, 11, ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        Handle.print_Position($"{student.Stt}", 40, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Name}", 43, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 68, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Age}", 73, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Class}", 76, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        displayIndex++;
                    }
                }
            }
        }
        //SHOW DS ĐIỂM HIỆN CÓ
        public void showPOINT(string className)
        {
            Console.Clear();
            Handle.print_Position($"DANH SÁCH ĐIỂM CỦA LỚP {className}", 40, 11, ConsoleColor.Cyan);
            int displayIndex = 0;
            foreach (var student in Liststudents)
            {
                if (student.Class == className)
                {
                    if (student is Teacher)
                    { }
                    else 
                    {
                        //header
                        Handle.print_Position("STT      HỌ VÀ TÊN           GT     TUỔI    GPA      XẾP LOẠI", 39, 13, ConsoleColor.Cyan);
                        //ds lớp
                        Handle.print_Position($"{student.Stt}", 40, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Name}", 43, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 68, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Age}", 76, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.GPA}", 83, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position(arrange(student), 92, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        displayIndex++;
                    }
                }
            }
        }
    }
}

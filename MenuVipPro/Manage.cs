using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            Liststudents.Add(new Student { Id = 2380601, Name = "Nguyễn Trường Phát", Age = 19, gender = "Nữ", Class = "23DTHA4", GPA = 3.5 });
            Liststudents.Add(new Student { Id = 2380608, Name = "Nguyễn Thanh Bảo Ngân", Age = 19, gender = "Nữ", Class = "23DTHA4", GPA = 3.6 });
            Liststudents.Add(new Student { Id = 2380612, Name = "Huỳnh Ngọc Anh Tuấn", Age = 19, gender = "Nam", Class = "23DTHA4", GPA = 4.0 });
            //giáo viên 23dtha5
            Liststudents.Add(new Teacher { Name = "Nguyễn Công Quang", Age = 40, gender = "Nam", Class = "23DTHA5" });
            //sinh viên 23 dtha5
            Liststudents.Add(new Student { Id = 2380600, Name = "Nguyễn Xuân Phát", Age = 19, gender = "Nam", Class = "23DTHA5", GPA = 4.0 });
            Liststudents.Add(new Student { Id = 2380609, Name = "Nguyễn Thanh Ngân", Age = 19, gender = "Nữ", Class = "23DTHA5", GPA = 3.6 });
            Liststudents.Add(new Student { Id = 2380605, Name = "Huỳnh Ngọc Tuấn Anh", Age = 19, gender = "Nam", Class = "23DTHA5", GPA = 3.5 });
            Liststudents.Add(new Student { Id = 2380620, Name = "Lê Huỳnh Ngọc", Age = 19, gender = "Nam", Class = "23DTHA5", GPA = 3.8 });
        }
        //nhap sv
        public void add_Student()
        {
            Console.Clear();
            Console.InputEncoding = Encoding.UTF8;
            Student sv = new Student();
            Handle.print_Position("ID : ", 52, 8, ConsoleColor.DarkYellow);
            sv.Id = Convert.ToInt32(Console.ReadLine());
            Handle.print_Position("HỌ TÊN : ", 52, 10, ConsoleColor.DarkYellow);
            sv.Name = Console.ReadLine();
            Handle.print_Position("GIỚI TÍNH: ", 52, 12, ConsoleColor.DarkYellow);
            sv.gender = Console.ReadLine();
            Handle.print_Position("TUỔI: ", 52, 14, ConsoleColor.DarkYellow);
            sv.Age = Convert.ToInt32(Console.ReadLine());
            Handle.print_Position("GPA: ", 52, 16, ConsoleColor.DarkYellow);
            sv.GPA = Convert.ToDouble(Console.ReadLine());
            Handle.print_Position("Lớp: ", 52, 18, ConsoleColor.DarkYellow);
            sv.Class = Console.ReadLine();
            Liststudents.Add(sv);
            showCLASS(sv.Class);
        }

        //tìm kiếm theo id
        public Student FindID(int ID)
        {
            Student result = null; //khởi tạo giá trị
            if (Liststudents != null && Liststudents.Count > 0)
            {
                foreach (Student student in Liststudents)
                {
                    if (student.Id == ID)
                        result = student;
                }
            }
            return result;
        }
        //tim kiem theo ten
        public void findName(string array, string Class)
        {
            Console.Clear();
            List<Student> search = new List<Student>();
            if (Liststudents != null && Liststudents.Count > 0)
            {
                foreach (Student student in Liststudents)
                {
                    if (student.Name.ToLower().Contains(array.ToLower()) && student.Class == Class)
                    {
                        search.Add(student);
                    }
                }
            }
            int displayIndex = 0;
            Console.Clear();
            if (search.Count > 0)
            {
                foreach (Student student in search)
                {
                    Handle.print_Position("  ID             HỌ VÀ TÊN            GT  TUỔI      LỚP", 35, 13, ConsoleColor.Cyan);
                    Handle.print_Position($"{student.Id}", 35, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                    Handle.print_Position($"{student.Name}", 48, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                    Handle.print_Position($"{student.gender}", 73, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                    Handle.print_Position($"{student.Age}", 78, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                    Handle.print_Position($"{student.Class}", 85, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                    displayIndex++;
                }
            }
            else
            {
                Handle.print_Position("KHÔNG TÌM THẤY SINH VIÊN NÀO PHÙ HỢP!", 45, 13, ConsoleColor.Red);
            }
        }
        //xoa sv theo id
        public void Delete(int id)
        {
            //tìm ID 
            Student student = FindID(id);
            if (student != null)
            {
                Liststudents.Remove(student);
            }
            else
            {
                Console.Clear();
                Handle.print_Position("ID KHÔNG HỢP LỆ!!", 50, 15, ConsoleColor.Magenta);
            }
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
                        Handle.print_Position("GIÁO VIÊN GIẢNG DẠY:", 40, 10, ConsoleColor.Cyan);
                        Handle.print_Position($"{student.Name}", 40, 11, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 65, 11, ConsoleColor.DarkGreen);
                        Handle.print_Position($"TUỔI: {student.Age}", 70, 11, ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        Handle.print_Position("  ID             HỌ VÀ TÊN            GT  TUỔI      LỚP", 35, 13, ConsoleColor.Cyan);
                        Handle.print_Position($"{student.Id}", 35, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Name}", 48, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 73, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Age}", 78, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Class}", 85, 14 + displayIndex * 2, ConsoleColor.DarkGreen);
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
                        Handle.print_Position("STT      HỌ VÀ TÊN                GT     TUỔI    GPA      XẾP LOẠI", 39, 13, ConsoleColor.Cyan);
                        //ds lớp
                        Handle.print_Position($"{student.Id}", 35, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Name}", 48, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.gender}", 73, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.Age}", 81, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position($"{student.GPA}", 88, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        Handle.print_Position(arrange(student), 97, 15 + displayIndex * 2, ConsoleColor.DarkGreen);
                        displayIndex++;
                    }
                }
            }
        }
    }
}

using Business.Concrete;
using DataAccess.EntityFramework;
using Entities;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
            StudentManager studentManager = new StudentManager(new EfStudentDal());
            LessonManager lessonManager = new LessonManager(new EfLessonDal(), new DepartmentManager(new EfDepartmentDal()));
            StudentScoreManager studentScoreManager = new StudentScoreManager(new EfStudentScoreDal());
            LecturerManager lecturerManager = new LecturerManager(new EfLecturerDal(),new DepartmentManager(new EfDepartmentDal()));
            var result = departmentManager.GetAll().Data;
            
            foreach (var item in result)
            {
                
                Console.WriteLine(item.DepartmentName);

            }


            Lecturer lecturer = new Lecturer { 
                DepartmentId = 3003,
                LecturerFirstName ="Mehmet",
                LecturerLastName ="aksoy",
                RegisterNo="2234"

             };
            //LecturerManager.Add(lecturer);
             var result1 = lecturerManager.Add(lecturer);
            //Department department = new Department
            //{
            //    DepartmentName = "Bilgisayar Programcılığı",
            //    DepartmentCode = "B4"
            //};
            //var result3 = departmentManager.Add(department);

           
        }
    }
}

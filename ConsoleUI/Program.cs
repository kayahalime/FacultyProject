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
            LessonManager lessonManager = new LessonManager(new EfLessonDal());
            StudentScoreManager studentScoreManager = new StudentScoreManager(new EfStudentScoreDal());
            LecturerManager lecturerManager = new LecturerManager(new EfLecturerDal());
            var result = departmentManager.GetAll().Data;
            
            foreach (var item in result)
            {
                
                Console.WriteLine(item.DepartmentName);

            }
          
            //Lecturer lecturer = new Lecturer { 
            //   DepartmentId = 1,
            //   LecturerFirstName ="Mehmet",
            //   LecturerLastName ="aksoy",
            //   RegisterNo="1234"
               
            //};
            //LecturerManager.Add(lecturer);
        }
    }
}

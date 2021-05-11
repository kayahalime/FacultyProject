using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, FacultyContext>, ILessonDal
    {
        public List<LessonDetailDto> GetLessonDetails()
        {
            using (FacultyContext context = new FacultyContext())
            {
                var result = from l in context.Lessons
                             join d in context.Departments
                             on l.DepartmentId equals d.DepartmentId
                             join lec in context.Lecturers
                             on l.LecturerId equals lec.LecturerId
                             select new LessonDetailDto
                             {
                                 LessonCode = l.LessonCode,
                                 DepartmentName = d.DepartmentName,
                                 LecturerFirstName = lec.LecturerFirstName,
                                 LecturerLastName = lec.LecturerLastName,
                                 Classroom = l.Classroom,
                                 CourseCredit = l.CourseCredit
                             };
                return result.ToList();
            }
        }
    }
}

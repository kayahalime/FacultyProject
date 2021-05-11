using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LessonDetailDto: IDto
    {
        public string LessonCode { get; set; }
        public string DepartmentName { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public string Classroom { get; set; }
        public int CourseCredit { get; set; }
    } 
}


using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Lesson : IEntity
    {
        public int LessonId { get; set; }
        public int DepartmentId { get; set; }
        public int LecturerId { get; set; }
        public string LessonCode { get; set; }
        public string Classroom { get; set; }
        public int CourseCredit { get; set; }

    }
}

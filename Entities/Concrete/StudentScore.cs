
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class StudentScore : IEntity
    {
        public int StudentScoreId { get; set; }
        public int StudentId { get; set; }
        public int DepartmentInformationId { get; set; }
        public int LessonId { get; set; }
        public int FirstExam { get; set; }
        public int SecondExam { get; set; }
        public float StudentAverage { get; set; }
    }
}

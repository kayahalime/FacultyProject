
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Lecturer : IEntity
    {
        public int LecturerId { get; set; }
        public int DepartmentId { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public string RegisterNo { get; set; }
    }
}

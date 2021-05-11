using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentDetailDto: IDto
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public float StudentAverage { get; set; }
    } 
}

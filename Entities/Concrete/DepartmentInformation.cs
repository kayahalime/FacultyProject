
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DepartmentInformation : IEntity
    {
        public int DepartmentInformationId { get; set; }
        public int DepartmentId { get; set; }
        public int LecturerId { get; set; }
        public int StudentScoreId { get; set; }
        public int StudentId { get; set; }
        public string StudentNo { get; set; }
        public string Status { get; set; }

    }
}

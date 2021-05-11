using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Department:IEntity
    {
        public int DepartmentId { get; set; }
        public string   DepartmentName{ get; set; }
        public string DepartmentCode { get; set; }
        public string Value { get; set; }


    }
}

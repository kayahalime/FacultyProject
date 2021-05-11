using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, FacultyContext>, IDepartmentDal
    {
       
    }
}

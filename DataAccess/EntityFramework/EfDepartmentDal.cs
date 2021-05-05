using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, FacultyContext>, IDepartmentDal
    {
    }
}

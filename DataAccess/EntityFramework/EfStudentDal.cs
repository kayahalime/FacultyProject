using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, FacultyContext>, IStudentDal
    {
       
    }
}

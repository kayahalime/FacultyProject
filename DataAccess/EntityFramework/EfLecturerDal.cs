using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfLecturerDal :  EfEntityRepositoryBase<Lecturer, FacultyContext>, ILecturerDal
    {
    }
}

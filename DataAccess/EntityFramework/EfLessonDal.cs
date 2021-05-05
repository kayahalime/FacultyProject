using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, FacultyContext>, ILessonDal
    {
    }
}

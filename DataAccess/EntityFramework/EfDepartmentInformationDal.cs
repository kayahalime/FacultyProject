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
    public class EfDepartmentInformationDal : EfEntityRepositoryBase<DepartmentInformation, FacultyContext>, IDepartmentInformationDal
    {
        public List<StudentDetailDto> GetStudentDetails()
        {
            using (FacultyContext context = new FacultyContext())
            {
                var result = from di in context.DepartmentInformations
                             join d in context.Departments
                             on di.DepartmentId equals d.DepartmentId
                             join s in context.Students
                             on di.StudentId equals s.StudentId
                             join ss in context.StudentScores
                             on di.StudentScoreId equals ss.StudentScoreId
                             select new StudentDetailDto
                             {
                                 StudentFirstName = s.StudentFirstName,
                                 StudentLastName = s.StudentLastName,
                                 DepartmentName = d.DepartmentName,
                                 Status = di.Status,
                                 StudentAverage = ss.StudentAverage
                                
                             };
                return result.ToList();
            }
        }
    }
}

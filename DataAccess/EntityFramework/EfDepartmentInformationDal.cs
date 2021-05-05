﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfDepartmentInformationDal : EfEntityRepositoryBase<DepartmentInformation, FacultyContext>, IDepartmentInformationDal
    {
    }
}

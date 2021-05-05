using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmentInformationService
    {
        IDataResult<List<DepartmentInformation>> GetAll();
        IDataResult<DepartmentInformation> GetById(int departmentInformationId);
        IResult Add(DepartmentInformation departmentInformation);
        IResult Update(DepartmentInformation departmentInformation);
        IResult Delete(DepartmentInformation departmentInformation);
    }
}

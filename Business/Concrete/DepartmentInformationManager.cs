using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmentInformationManager : IDepartmentInformationService
    {
        IDepartmentInformationDal _departmentInformationDal;
        public DepartmentInformationManager(IDepartmentInformationDal departmentInformationDal)
        {
            _departmentInformationDal = departmentInformationDal;

        }
        public IResult Add(DepartmentInformation departmentInformation)
        {
            Console.WriteLine("ekleme fonksiyonuna girildi");
            _departmentInformationDal.Add(departmentInformation);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DepartmentInformation departmentInformation)
        {
            _departmentInformationDal.Delete(departmentInformation);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<DepartmentInformation>> GetAll()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<DepartmentInformation>>(_departmentInformationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<DepartmentInformation> GetById(int departmentId)
        {
            return new SuccessDataResult<DepartmentInformation>(_departmentInformationDal.Get(d => d.DepartmentId == departmentId));
        }

        public IResult Update(DepartmentInformation departmentInformation)
        {
            _departmentInformationDal.Update(departmentInformation);
            return new SuccessResult(Messages.Updated);
        }
    }
}

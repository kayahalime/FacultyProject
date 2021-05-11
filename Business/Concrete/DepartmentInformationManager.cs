using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmentInformationManager : IDepartmentInformationService
    {
        IDepartmentInformationDal _departmentInformationDal;
        IDepartmentService _departmentService;
        public DepartmentInformationManager(IDepartmentInformationDal departmentInformationDal,IDepartmentService departmentService)
        {
            _departmentInformationDal = departmentInformationDal;
            _departmentService = departmentService;

        }
        [ValidationAspect(typeof(DepartmentInformationValidator))]
        public IResult Add(DepartmentInformation departmentInformation)
        {
            IResult result = BusinessRules.Run(CheckStudentNo(departmentInformation.StudentNo, departmentInformation.DepartmentId));

            if (result != null)
            {
                return result;
            }
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
        public IDataResult<List<StudentDetailDto>> GetStudentDetails()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<StudentDetailDto>>(_departmentInformationDal.GetStudentDetails(), Messages.Listed);
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
        private IResult CheckStudentNo(string studentNo, int departmentId)
        {

            var result = _departmentService.GetAll();
            foreach (var item in result.Data)
            {


                if (departmentId == item.DepartmentId)
                {


                    if (studentNo.StartsWith(item.Value) == false)
                    {


                        return new ErrorResult(Messages.LecturerRegisterNo);

                    }

                }

            }
            return new SuccessResult();

        }
    }
}

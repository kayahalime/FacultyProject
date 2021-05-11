using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
       
        
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
         
           

        }
        [ValidationAspect(typeof(DepartmentValidator))]
        public IResult Add(Department department)
        {

            IResult result = BusinessRules.Run(CheckDepartmentCode(department));
            Console.WriteLine("ekleme fonksiyonuna girildi");
            _departmentDal.Add(department);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Department>> GetAll()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Department> GetById(int departmentId)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(d => d.DepartmentId == departmentId));
        }

        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.Updated);
        }
        // ilgili parametreyle gelen bölüm id ile bölümler tablosundaki id'leri karşılaştırarak ilgili 
        //bölüme denk gelen bölüm kodunu metoda gönderdim ve value'ye eşitledim
        private IResult CheckDepartmentCode(Department department)
        {
            Console.WriteLine("checkdepartmentcode");
            department.Value = CheckDepartmentValue(department.DepartmentCode);


            return new SuccessResult();
        }



        //Burada her biri B ile başlama zorunluğu olan bölüm kodunun  B harfini sildim
        // geri kalan kısım value'ye eşit olacak yani B1,B2...B10 olan bölüm kodlarının 
        //B harfleri gittiğinde geri kalan sayılar valueye eşitlenecek
        private string CheckDepartmentValue(string departmentCode)
        {
            Console.WriteLine("checkdepartmentvalue");
            departmentCode = departmentCode.Replace("B", string.Empty);
            return departmentCode;
        }




    }
}

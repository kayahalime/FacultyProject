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
using System.Text;

namespace Business.Concrete
{
    public class LecturerManager : ILecturerService
    {
        ILecturerDal _lecturerDal;
        IDepartmentService _departmentService;

        public LecturerManager(ILecturerDal lecturerDal, IDepartmentService departmentService)
        {
            _lecturerDal = lecturerDal;
            _departmentService = departmentService;

        }
        [ValidationAspect(typeof(LecturerValidator))]
        public IResult Add(Lecturer lecturer)
        { 
          

            IResult result = BusinessRules.Run(CheckRegisterNo(lecturer.RegisterNo,lecturer.DepartmentId));

            if (result != null)
            {
                return result;
            }

            _lecturerDal.Add(lecturer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Lecturer lecturer)
        {
            _lecturerDal.Delete(lecturer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Lecturer>> GetAll()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<Lecturer>>(_lecturerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Lecturer> GetById(int lecturerId)
        {
            return new SuccessDataResult<Lecturer>(_lecturerDal.Get(l => l.LecturerId == lecturerId));
        }

        public IResult Update(Lecturer lecturer)
        {
            _lecturerDal.Update(lecturer);
            return new SuccessResult(Messages.Updated);
        }

        //burada da ilk olarak bölüm kodu tablosunun içine girdim parametreyle gelen id'yi çektim
        //ardından sicil no value ile başlayıp başlamadığı durumunu kontrol ettim.
        private IResult CheckRegisterNo(string registerNo,int departmentId)
        {
           
            var result = _departmentService.GetAll();
            foreach (var item in result.Data)
            {
                

                if (departmentId ==item.DepartmentId)
                {
                 

                    if (registerNo.StartsWith(item.Value)==false)
                  {

                       
                       return new ErrorResult(Messages.LecturerRegisterNo);  
                     
                  }
                  
                }
               
            }
           return new SuccessResult();

        }


    }
}

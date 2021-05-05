using Business.Abstract;
using Business.Constans;
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

        public LecturerManager(ILecturerDal lecturerDal)
        {
            _lecturerDal = lecturerDal;
      

        }
        public IResult Add(Lecturer lecturer)
        { 
            Console.WriteLine("ekleme fonksiyonuna girildi");

           

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
        

    }
}

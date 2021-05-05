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
    public class StudentScoreManager : IStudentScoreService
    {
        IStudentScoreDal _studentScoreDal;
        public StudentScoreManager(IStudentScoreDal studentScoreDal)
        {
            _studentScoreDal = studentScoreDal;

        }
        public IResult Add(StudentScore studentScore)
        {
            Console.WriteLine("ekleme fonksiyonuna girildi");
           
            studentScore.StudentAverage = (float)((studentScore.FirstExam * 0.4) + (studentScore.SecondExam * 0.6));
            
            _studentScoreDal.Add(studentScore);
            Console.WriteLine("eklendi");
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(StudentScore studentScore)
        {
            _studentScoreDal.Delete(studentScore);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<StudentScore>> GetAll()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<StudentScore>>(_studentScoreDal.GetAll(), Messages.Listed);
        }

        public IDataResult<StudentScore> GetById(int studentScoreId)
        {
            return new SuccessDataResult<StudentScore>(_studentScoreDal.Get(s => s.StudentScoreId == studentScoreId));
        }

        public IResult Update(StudentScore studentScore)
        {
            _studentScoreDal.Update(studentScore);
            return new SuccessResult(Messages.Updated);
        }
    }
}

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
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        IDepartmentService _departmentService;
        public LessonManager(ILessonDal lessonDal, IDepartmentService departmentService)
        {
            _lessonDal = lessonDal;
            _departmentService = departmentService;
        }
        [ValidationAspect(typeof(LessonValidator))]
        public IResult Add(Lesson lesson)
        {
            IResult result = BusinessRules.Run(CheckLessonCode(lesson.LessonCode, lesson.DepartmentId,lesson.LessonId));

            if (result != null)
            {
                return result;
            }
            _lessonDal.Add(lesson);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Lesson lesson)
        {
            _lessonDal.Delete(lesson);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(), Messages.Listed);
        }
        public IDataResult<List<LessonDetailDto>> GetLessonDetails()
        {
            Console.WriteLine("fonksiyona girildi");
            return new SuccessDataResult<List<LessonDetailDto>>(_lessonDal.GetLessonDetails(), Messages.Listed);
        }

        public IDataResult<Lesson> GetById(int lessonId)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.LessonId == lessonId));
        }

        public IResult Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckLessonCode(string lessonCode, int departmentId,int lessonId)
        {

            var result = _departmentService.GetAll();
            string lessonIdString = lessonId.ToString();
            foreach (var item in result.Data)
            {


                if (departmentId == item.DepartmentId)
                {


                    if (lessonCode.StartsWith(item.Value)==false  && lessonCode.EndsWith(lessonIdString)==false)
                    {


                        return new ErrorResult(Messages.LecturerRegisterNo);

                    }

                }

            }
            return new SuccessResult();

        }
    }
}

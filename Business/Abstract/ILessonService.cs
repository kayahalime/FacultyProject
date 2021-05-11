using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IDataResult<List<LessonDetailDto>> GetLessonDetails();
        IDataResult<List<Lesson>> GetAll();
        IDataResult<Lesson> GetById(int lessonId);
        IResult Add(Lesson lesson);
        IResult Update(Lesson lesson);
        IResult Delete(Lesson lesson);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentScoreService
    {
        IDataResult<List<StudentScore>> GetAll();
        IDataResult<StudentScore> GetById(int studentScoreId);
        IResult Add(StudentScore studentScore);
        IResult Update(StudentScore studentScore);
        IResult Delete(StudentScore studentScore);
    }
}

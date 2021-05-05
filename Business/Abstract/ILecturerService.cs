using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILecturerService
    {
        IDataResult<List<Lecturer>> GetAll();
        IDataResult<Lecturer> GetById(int lecturerId);
        IResult Add(Lecturer lecturer);
        IResult Update(Lecturer lecturer);
        IResult Delete(Lecturer lecturer);
    }
}

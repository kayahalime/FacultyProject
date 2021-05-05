
using DataAccess.Abstract;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class LecturerValidator: AbstractValidator<Lecturer>
    {
        
        public LecturerValidator()
        {
             RuleFor(l => l.RegisterNo).Length(4).WithMessage("Sicil no uzunluğu 4 karakter olamalıdır");
             //RuleFor(l => l.RegisterNo).Must(StartWithx).WithMessage("Sicil no bölüm koduna göre girilmelidir.");

        }
      // private bool StartWithx(string arg)
      //  {
      //     string x = department.DepartmentCode.Substring(1);
      //    return arg.StartsWith(x);
      //}

    }
}

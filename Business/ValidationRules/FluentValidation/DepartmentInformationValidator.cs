using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DepartmentInformationValidator:AbstractValidator<DepartmentInformation>
    {
        public DepartmentInformationValidator()
        {
            RuleFor(d => d.StudentNo).Length(9).WithMessage("Öğrenci no uzunluğu 9 karakter olamalıdır");
        }
    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.TelephoneNumber).Length(11).WithMessage("Telefon Numarası uzunluğu 11 karakter olamalıdır");
            RuleFor(s => s.IdentityNumber).Length(11).WithMessage("TC Kimlik no uzunluğu 11 karakter olamalıdır");
            
        }
    }
}

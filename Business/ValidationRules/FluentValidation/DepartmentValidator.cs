using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.DepartmentName).NotEmpty();
            RuleFor(d => d.DepartmentCode).Must(StartWithB).WithMessage("Bölüm Kodları B harfi ile başlamalı");
        }
        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }

    }
}

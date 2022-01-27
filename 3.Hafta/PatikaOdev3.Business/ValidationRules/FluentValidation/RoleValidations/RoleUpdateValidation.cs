using FluentValidation;
using PatikaOdev3.Model.DTOs.RoleAddDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.RoleValidations
{
    public class RoleUpdateValidation : AbstractValidator<RoleUpdateDTO>
    {
        public RoleUpdateValidation()
        {

            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithMessage("Category Id'si girilmelidir!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("c adı boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("RoleAddValidation adı en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("v adı en fazla 30 karakter olabilir!");
        }
    }
}

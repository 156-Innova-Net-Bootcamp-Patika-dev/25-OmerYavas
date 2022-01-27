using FluentValidation;
using PatikaOdev3.Model.DTOs.RoleAddDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.RoleValidations
{
    public class RoleAddValidation : AbstractValidator<RoleAddDTO>
    {
        public RoleAddValidation()
        {
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

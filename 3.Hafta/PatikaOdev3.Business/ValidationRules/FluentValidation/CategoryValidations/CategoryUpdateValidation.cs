using FluentValidation;
using PatikaOdev3.Model.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.CategoryValidations
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Id)
                  .GreaterThan(0)
                  .WithMessage("Category Id'si girilmelidir!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Kategori adı boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Kategori adı en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Kategori adı en fazla 80 karakter olabilir!");

        }
    }
}

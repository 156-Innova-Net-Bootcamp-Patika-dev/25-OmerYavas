using FluentValidation;
using PatikaOdev3.Model.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.CategoryValidations
{
    public class CategoryAddValidation:AbstractValidator<CategoryAddDTO>
    {
        public CategoryAddValidation()
        {
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

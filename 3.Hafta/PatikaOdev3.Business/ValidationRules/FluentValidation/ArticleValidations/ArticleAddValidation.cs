using FluentValidation;
using PatikaOdev3.Model.DTOs.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.ArticleValidations
{
    public class ArticleAddValidation : AbstractValidator<ArticleAddDTO>
    {
        public ArticleAddValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlık boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Başlık adı en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Başlık adı en fazla 180 karakter olabilir!");

            RuleFor(x => x.ShortDescription)
               .NotEmpty()
               .WithMessage("Kısa açıklama boş geçilemez!")
               .MinimumLength(2)
               .WithMessage("Kısa açıklama en az 10 karakter olmalıdır!")
               .MaximumLength(80)
               .WithMessage("Kısa açıklama en fazla 150 karakter olabilir!");

            RuleFor(x => x.Content)
               .NotEmpty()
               .WithMessage("Makale içeriği boş geçilemez!")
               .MinimumLength(50)
               .WithMessage("Makale içeriği en az 50 karakter olmalıdır!")
               .MaximumLength(30000)
               .WithMessage("Makale içeriği en fazla 30000 karakter olabilir!");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Kategori seçilmelidir!");


        }
    }
}

using FluentValidation;
using PatikaOdev3.Model.DTOs.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.CommentVvalidations
{
    public class CommentAddValidator : AbstractValidator<CommentAddDTO>
    {
        public CommentAddValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad Soyad boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Ad Soyad adı en az 4 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Ad Soyad adı en fazla 80 karakter olabilir!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez!")
                .MaximumLength(150)
                .WithMessage("Email en fazla 150 karakter olabilir!")
                .Must(p => p != null && Regex.IsMatch(p, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                .WithMessage("Eposta uygun biçimde girilmemiş!");

            RuleFor(x => x.Content)
               .NotEmpty()
               .WithMessage("Yorum alanı boş olamaz!")
               .MaximumLength(300)
               .WithMessage("Yorum en çok 300 karakter olabilir!");

        }
    }
}
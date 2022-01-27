using FluentValidation;
using PatikaOdev3.Model.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatikaOdev3.Business.ValidationRules.FluentValidation.UserValidations
{
    public class UserAddValidation : AbstractValidator<UserAddDTO>
    {
        public UserAddValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("İsim geçilemez!")
                .MinimumLength(2)
                .WithMessage("İsim en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("İsim en fazla 30 karakter olabilir!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyisim geçilemez!")
                .MinimumLength(2)
                .WithMessage("Soyisim en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Soyisim en fazla 30 karakter olabilir!");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Adres boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Adres en az 2 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Adres en fazla 600 karakter olabilir!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Şifre en az 4 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Şifre en fazla 50 karakter olabilir!");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("Kullanıcı adı en az 4 karakter olmalıdır!")
                .MaximumLength(80)
                .WithMessage("Kullanıcı adı  en fazla 50 karakter olabilir!");

            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithMessage("Kullanıcı rolü seçmelisiniz!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez!")
                .MaximumLength(150)
                .WithMessage("Email en fazla 150 karakter olabilir!")
                .Must(p => p != null && Regex.IsMatch(p, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                .WithMessage("Eposta uygun biçimde girilmemiş!");



        }
    }
}
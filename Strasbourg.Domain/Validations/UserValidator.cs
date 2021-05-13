using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class UserValidator : BaseValidator<UsersViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad Boş Geçilemez")
                .Length(1, 100).WithMessage("Ad Soyad 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Boş Geçilemez")
                .Length(1, 100).WithMessage("Email 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Degree)
             .NotEmpty().WithMessage("Derece Boş Geçilemez")
             .Length(1, 100).WithMessage("Derece Boş Geçilemez.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre Boş Geçilemez")
                .Length(1, 16).WithMessage("Şifre 1 İle 16 Karakter Arasında Olmalıdır.");
        }
    }
}

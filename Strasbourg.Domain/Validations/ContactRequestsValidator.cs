using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class ContactRequestsValidator : BaseValidator<ContactRequestsViewModel>
    {
        public ContactRequestsValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad Boş Geçilemez")
                .Length(1, 100).WithMessage("Ad Soyad 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Boş Geçilemez")
                .Length(1, 100).WithMessage("Email 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu Boş Geçilemez")
                .Length(1, 150).WithMessage("Konu 1 İle 100 Karakter Arasında Olmalıdır.");

 
        }
    }
}

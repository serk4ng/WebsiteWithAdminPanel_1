using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SacrificeDonationValidator : BaseValidator<SacrificeDonationViewModel>
    {
        public SacrificeDonationValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad Boş Geçilemez");

            RuleFor(x => x.Surname)
             .NotEmpty().WithMessage("Soyad Boş Geçilemez.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon Numarası Boş Geçilemez");

            RuleFor(x => x.ZipCode)
        .NotEmpty().WithMessage("Posta Kodu Boş Geçilemez");

            RuleFor(x => x.Adress)
        .NotEmpty().WithMessage("Adres Boş Geçilemez");
            RuleFor(x => x.City)
        .NotEmpty().WithMessage("Şehir Boş Geçilemez");

            RuleFor(x => x.Total)
        .NotEmpty().WithMessage("Toplam Fiyat Boş Geçilemez");

            RuleFor(x => x.Email)
     .NotEmpty().WithMessage("Email Boş Geçilemez");
            RuleFor(x => x.SacrificeType)
.NotEmpty().WithMessage("Kurban Tipi Boş Geçilemez");

            RuleFor(x => x.SacrificeCount)
.NotEmpty().WithMessage("Kurban Sayısı Boş Geçilemez");

 

        }
    }
}


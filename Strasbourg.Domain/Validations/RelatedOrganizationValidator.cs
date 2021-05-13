using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{

    public class RelatedOrganizationValidator : BaseValidator<RelatedOrganizationViewModel>
    {
        public RelatedOrganizationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kuruluş Adı Boş Geçilemez")
                .Length(1, 100).WithMessage("Kuruluş Adı 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Website)
                .NotEmpty().WithMessage("Website Boş Geçilemez");


            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adres Boş Geçilemez")
                .Length(1, 200).WithMessage("Adres Boş Geçilemez.");
        }
    }
}

using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{

    public class AssociationValidator : BaseValidator<AssociationViewModel>
    {
        public AssociationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dernek Adı Boş Geçilemez")
                .Length(1, 100).WithMessage("Dernek Adı 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim Boş Geçilemez");

 

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adres Boş Geçilemez")
                .Length(1, 100).WithMessage("Adres Boş Geçilemez.");
        }
    }
}

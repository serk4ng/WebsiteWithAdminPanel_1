using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class PublicationValidator : BaseValidator<PublicationViewModel>
    {
        public PublicationValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama Boş Geçilemez");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Yayın Adı Boş Geçilemez");
        }

    }
}

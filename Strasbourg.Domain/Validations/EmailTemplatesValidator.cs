using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class EmailTemplatesValidator : BaseValidator<EmailTemplatesViewModel>
    {
        public EmailTemplatesValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu");


            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj Boş Geçilemez");

        }

    }
}

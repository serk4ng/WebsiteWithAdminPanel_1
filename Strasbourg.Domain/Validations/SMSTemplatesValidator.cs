using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SMSTemplatesValidator : BaseValidator<SMSTemplatesViewModel>
    {
        public SMSTemplatesValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu Boş Geçilemez");


            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj Boş Geçilemez");

        }
    }
}

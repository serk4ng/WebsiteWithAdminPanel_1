using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SubscriberValidator : BaseValidator<SubscriberViewModel>
    {
        public SubscriberValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Boş Geçilemez");
        }
    }
}

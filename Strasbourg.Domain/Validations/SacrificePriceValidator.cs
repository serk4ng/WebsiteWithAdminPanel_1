using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SacrificePriceValidator : BaseValidator<SacrificePriceViewModel>
    {
        public SacrificePriceValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat Adı Boş Geçilemez");
        }
    }
}

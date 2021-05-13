using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class NewsCategoryValidator : BaseValidator<NewsCategoryViewModel>
    {
        public NewsCategoryValidator()
        {
            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        }
    }
}

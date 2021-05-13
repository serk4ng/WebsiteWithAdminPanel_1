using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class BoardValidator : BaseValidator<BoardViewModel>
    {
        public BoardValidator()
        {


            RuleFor(x => x.Degree)
                .NotEmpty().WithMessage("Unvan Boş Geçilemez");

            RuleFor(x => x.Image)
             .NotEmpty().WithMessage("Resim Boş Geçilemez.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad Boş Geçilemez");
        }

    }
}

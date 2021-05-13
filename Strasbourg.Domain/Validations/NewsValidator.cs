using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class NewsValidator : BaseValidator<NewsViewModel>
    {
        public NewsValidator()
        {

            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.Content)
        .NotEmpty().WithMessage("İçerik Boş Geçilemez");

            RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Resim Boş Geçilemez");
        }

    }
}

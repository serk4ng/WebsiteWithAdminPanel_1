using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SermonValidator : BaseValidator<SermonViewModel>
    {
        public SermonValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Hutbe Başlığı Boş Geçilemez")
               .Length(1, 100).WithMessage("Hutbe Başlığı 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Content)
             .NotEmpty().WithMessage("Hutbe İçeriği Boş Geçilemez");
 
        }
    }
}

using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class SiteSettingsValidator : BaseValidator<SiteSettingsViewModel>
    {
        public SiteSettingsValidator()
        {
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon Numarası Boş Geçilemez");
            
            RuleFor(x => x.Facebook)
                .NotEmpty().WithMessage("Facebook Boş Geçilemez");
            RuleFor(x => x.Twitter)
    .NotEmpty().WithMessage("Twitter Boş Geçilemez");
            RuleFor(x => x.Instagram)
    .NotEmpty().WithMessage("Instagram Boş Geçilemez");
            RuleFor(x => x.Youtube)
    .NotEmpty().WithMessage("Youtube Boş Geçilemez");

            RuleFor(x => x.Adress)
.NotEmpty().WithMessage("Adres Boş Geçilemez");

            RuleFor(x => x.AboutUs)
.NotEmpty().WithMessage("Hakkımızda Boş Geçilemez");

            RuleFor(x => x.Fax)
.NotEmpty().WithMessage("Faks Boş Geçilemez");

            RuleFor(x => x.OurGoals)
.NotEmpty().WithMessage("Hedeflerimiz Boş Geçilemez");

            RuleFor(x => x.Map)
.NotEmpty().WithMessage("Harita Boş Geçilemez");


            RuleFor(x => x.Principle)
.NotEmpty().WithMessage("İlkelerimiz Boş Geçilemez");

 

 
        }
    }
}

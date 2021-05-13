using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{
    public class VideoValidator : BaseValidator<VideoViewModel>
    {
        public VideoValidator()
        {
            RuleFor(x => x.Title)
              .NotEmpty().WithMessage("Video Başlığı Boş Geçilemez")
              .Length(1, 100).WithMessage("Video 1 İle 100 Karakter Arasında Olmalıdır.");

            RuleFor(x => x.Url)
             .NotEmpty().WithMessage("Video Linki Boş Geçilemez");

            RuleFor(x => x.Thumbnail)
            .NotEmpty().WithMessage("Video Küçük Resmi Boş Geçilemez");
        }
    }
}

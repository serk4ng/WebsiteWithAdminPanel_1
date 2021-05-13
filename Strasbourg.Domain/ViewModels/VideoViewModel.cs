using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        [Display(Name = "Başlık : ")]
        public string Title { get; set; }
        [Display(Name = "Resim : ")]
        public string Thumbnail { get; set; }
        [Display(Name = "Video Linki : ")]
        public string Url { get; set; }
    }
}

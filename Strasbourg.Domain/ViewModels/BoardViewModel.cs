using Strasbourg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        [Display(Name = "Ad Soyad : ")]
        public string NameSurname { get; set; }

        [Display(Name = "Unvan : ")]
        public string Degree { get; set; }

        [Display(Name = "BoardType : ")]
        public BoardType BoardType { get; set; }

        [Display(Name = "Resim : ")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }

        [Display(Name = "Sıra : ")]
        public int Count { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class SacrificeDonationViewModel : BaseViewModel
    {
        [Display(Name = "Ad : ")]
        public string Name { get; set; }
        [Display(Name = "Soyad : ")]
        public string Surname { get; set; }
        [Display(Name = "Email : ")]
        public string Email { get; set; }
        [Display(Name = "Telefon : ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Posta Kodu : ")]
        public string ZipCode { get; set; }
        [Display(Name = "Şehir : ")]
        public string City { get; set; }
        [Display(Name = "Adres : ")]
        public string Adress { get; set; }
        [Display(Name = "Kurban Tipi : ")]
        public string SacrificeType { get; set; }
        [Display(Name = "Kurban Sayısı : ")]
        public int SacrificeCount { get; set; }
        [Display(Name = "Diğer : ")]
        public string Other { get; set; }
        [Display(Name = "Toplam : ")]
        public double Total { get; set; }
    }
}

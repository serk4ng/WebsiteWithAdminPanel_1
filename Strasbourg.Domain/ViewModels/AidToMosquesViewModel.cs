using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class AidToMosquesViewModel : BaseViewModel
    {
        [Display(Name = "Ad : ")]
        public string Name { get; set; }
        [Display(Name = "Spyad : ")]
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
        [Display(Name = "Açıklama : ")]
        public string Description { get; set; }
        [Display(Name = "Bağış Miktarı : ")]
        public double DonationAmount { get; set; }
    }
}

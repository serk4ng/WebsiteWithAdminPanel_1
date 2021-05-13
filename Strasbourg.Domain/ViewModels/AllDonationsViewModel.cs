using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class AllDonationsViewModel : BaseViewModel
    {
        [Display(Name = "Ad : ")]
        public string Name { get; set; }

        [Display(Name = "Soyad : ")]
        public string Surname { get; set; }

        [Display(Name = "Telefon Numarası : ")]
        public string Phone { get; set; }
        [Display(Name = "Bağış Tipi : ")]
        public string DonationType { get; set; }

        [Display(Name = "Bağış Miktarı : ")]
        public double Price { get; set; }

    }
}

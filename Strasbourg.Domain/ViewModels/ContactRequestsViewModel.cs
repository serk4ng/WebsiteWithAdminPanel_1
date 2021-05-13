using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class ContactRequestsViewModel : BaseViewModel
    {
        [Display(Name = "Ad Soyad : ")]
        public string NameSurname { get; set; }

        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Display(Name = "Konu : ")]
        public string Subject { get; set; }

        [Display(Name = "Mesaj : ")]
        public string Message { get; set; }
 
    }
}

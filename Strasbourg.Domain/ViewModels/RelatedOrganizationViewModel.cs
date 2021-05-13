using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class RelatedOrganizationViewModel : BaseViewModel
    {
        [Display(Name = "Ad Soyad : ")]
        public string Name { get; set; }

        [Display(Name = "Adres : ")]
        public string Adress { get; set; }

        [Display(Name = "Website : ")]
        public string Website { get; set; }

    }
}

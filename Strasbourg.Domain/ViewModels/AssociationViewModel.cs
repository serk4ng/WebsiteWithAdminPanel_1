using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{

    public class AssociationViewModel : BaseViewModel
    {
        [Display(Name = "Dernek Adı : ")]
        public string Name { get; set; }

        [Display(Name = "Adres : ")]
        public string Adress { get; set; }

        [Display(Name = "Resim : ")]
        public string Image { get; set; }

        [Display(Name = "Sıra : ")]
        public int Count { get; set; }


    }
}

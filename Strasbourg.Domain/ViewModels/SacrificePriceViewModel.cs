using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class SacrificePriceViewModel : BaseViewModel
    {
        [Display(Name = "Fiyat : ")]
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class SMSHistoryViewModel : BaseViewModel
    {
        [Display(Name = "Telefon : ")]
        public string Phone { get; set; }
        [Display(Name = "Mesaj : ")]
        public string Message { get; set; }
    }
}

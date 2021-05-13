using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class EmailHistoryViewModel : BaseViewModel 
    {
        [Display(Name = "Alıcı Emaili : ")]
        public string ReceiverMail { get; set; }
        [Display(Name = "Konu : ")]
        public string Subject { get; set; }
        [Display(Name = "Mesaj : ")]
        public string Message { get; set; }

    }
}

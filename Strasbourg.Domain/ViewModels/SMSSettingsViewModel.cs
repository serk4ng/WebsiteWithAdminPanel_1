using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class SMSSettingsViewModel : BaseViewModel
    {

        [Display(Name = "AppKey : ")]
        public string AppKey { get; set; }
        [Display(Name = "Secret : ")]
        public string Secret { get; set; }
        [Display(Name = "ConsumerKey : ")]
        public string ConsumerKey { get; set; }

        [Display(Name = "ServiceName : ")]
        public string ServiceName { get; set; }
    }
}

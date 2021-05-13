using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class EmailSettingsViewModel : BaseViewModel
    {
        [Display(Name = "Kullanıcı Adı : ")]
        public string Username { get; set; }
        [Display(Name = "Şifre : ")]
        public string Password { get; set; }
        [Display(Name = "Host : ")]
        public string Host { get; set; }
        [Display(Name = "Port : ")]
        public int Port { get; set; }
        [Display(Name = "Mail : ")]
        public string Mail { get; set; }
    }
}

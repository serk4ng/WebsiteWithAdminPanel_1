using Strasbourg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        [Display(Name = "Ad Soyad : ")]
        public string NameSurname { get; set; }

        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Display(Name = "Şifre : ")]
        public string Password { get; set; }
        
        [Display(Name = "Ünvan : ")]
        public string Degree { get; set; }
        [Display(Name = "Kullanıcı Türü : ")]
        public UserType UserType { get; set; }
    }
}

using Strasbourg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Strasbourg.DAL.Models
{
    public class Users : BaseModel
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Degree { get; set; }
        public UserType UserType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class SacrificeDonation : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string SacrificeType { get; set; }
        public int SacrificeCount { get; set; }
        public string Other { get; set; }
        public double Total { get; set; }

    }
}

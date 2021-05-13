using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class EmailSettings : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Mail { get; set; }
    }
}

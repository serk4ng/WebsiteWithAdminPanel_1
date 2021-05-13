using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class SMSHistory : BaseModel
    {
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}

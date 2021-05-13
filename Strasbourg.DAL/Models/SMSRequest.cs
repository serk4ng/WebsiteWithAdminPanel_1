using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
   public class SMSRequest
    {
        public string message { get; set; }
        public string httpCode { get; set; }
        public string errorCode { get; set; }
    }
}

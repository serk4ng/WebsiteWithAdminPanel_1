using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class SMSSettings : BaseModel
    {
        public string AppKey { get; set; }
        public string Secret { get; set; }
        public string ConsumerKey { get; set; }
        public string ServiceName { get; set; }
    }
}

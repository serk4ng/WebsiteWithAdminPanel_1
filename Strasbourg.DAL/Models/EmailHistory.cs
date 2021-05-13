using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class EmailHistory : BaseModel
    {
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

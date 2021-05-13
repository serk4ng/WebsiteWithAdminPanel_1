using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class EmailTemplates : BaseModel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class Association : BaseModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}

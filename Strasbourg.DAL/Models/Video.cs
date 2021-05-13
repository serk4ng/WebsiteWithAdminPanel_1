using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class Video : BaseModel
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Url { get; set; }
    }
}

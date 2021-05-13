using Strasbourg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class Board : BaseModel
    {
        public BoardType BoardType { get; set; }
        public string NameSurname { get; set; }
        public string Degree { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}

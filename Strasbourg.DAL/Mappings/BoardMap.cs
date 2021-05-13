using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class BoardMap : BaseMap<Board>
    {
        public BoardMap()
        {
            ToTable("Boards");

            Property(x => x.BoardType)
              .IsRequired();
            Property(x => x.NameSurname)
                .HasMaxLength(100)
                .IsRequired();
            
            Property(x => x.Degree)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Image)
                .IsRequired();
        }
    }
}

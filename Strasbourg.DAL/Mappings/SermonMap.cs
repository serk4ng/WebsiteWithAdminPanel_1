using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SermonMap : BaseMap<Sermon>
    {
        public SermonMap()
        {
            ToTable("Sermons");

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Content)
                .IsRequired();

            Property(x => x.Image)
                .IsRequired();       
        }
    }
}

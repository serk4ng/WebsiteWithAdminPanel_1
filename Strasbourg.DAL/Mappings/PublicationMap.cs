using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class PublicationMap : BaseMap<Publication>
    {
        public PublicationMap()
        {
            ToTable("Publications");

            Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Image)
                .IsRequired();



        }
    }
}

using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class AssociationMap : BaseMap<Association>
    {
        public AssociationMap()
        {
            ToTable("Associations");

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Adress)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Image)
                .IsRequired();

     

        }
    }
}

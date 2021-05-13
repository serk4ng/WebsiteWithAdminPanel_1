using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SisterOrganizationMap : BaseMap<SisterOrganization>
    {
        public SisterOrganizationMap()
        {
            ToTable("SisterOrganizations");

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Adress)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.EstablishmentYear)
               .IsRequired();

            Property(x => x.Website)
                .IsRequired();

        }
    }
}

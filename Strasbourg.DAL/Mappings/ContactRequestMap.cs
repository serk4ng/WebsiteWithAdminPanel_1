using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class ContactRequestsMap : BaseMap<ContactRequest>
    {
        public ContactRequestsMap()
        {
            ToTable("ContactRequests");

            Property(x => x.NameSurname)
                .HasMaxLength(100)
                .IsRequired();
 
            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Subject)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Message)
                .IsRequired();
        }
    }
}

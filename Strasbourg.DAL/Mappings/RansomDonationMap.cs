using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class RansomDonationMap : BaseMap<RansomDonation>
    {
        public RansomDonationMap()
        {
            ToTable("RansomDonations");

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Surname)
                .HasMaxLength(100)
                .IsRequired();
 
            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.PhoneNumber)
                  .HasMaxLength(30)
                .IsRequired();

            Property(x => x.ZipCode)
                  .HasMaxLength(10)
                .IsRequired();

            Property(x => x.PhoneNumber)
                  .HasMaxLength(20)
                .IsRequired();


            Property(x => x.City)
                    .HasMaxLength(30)
                 .IsRequired();

            Property(x => x.Adress)
    .HasMaxLength(300)
          .IsRequired();

            Property(x => x.AdditionalInfo)
              .HasMaxLength(150)
               .IsRequired();

            Property(x => x.RansomAmount)
             .IsRequired();

        }
    }
}

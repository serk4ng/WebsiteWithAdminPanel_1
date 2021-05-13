using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SacrificeDonationMap : BaseMap<SacrificeDonation>
    {
        public SacrificeDonationMap()
        {
            ToTable("SacrificeDonations");

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

            Property(x => x.SacrificeType)
              .HasMaxLength(10)
               .IsRequired();

            Property(x => x.SacrificeCount)
               .IsRequired();

            Property(x => x.Other)
                   .HasMaxLength(150);
  

            Property(x => x.Total)
             .IsRequired();

        }
    }
}

using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SiteSettingsMap : BaseMap<SiteSettings>
    {
        public SiteSettingsMap()
        {
            ToTable("SiteSettings");


            Property(x => x.Logo)
             .IsRequired();

            Property(x => x.Adress)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Phone)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Fax)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Map)
                  .HasMaxLength(300)
                .IsRequired();

            Property(x => x.AboutUs)
                .IsRequired();

            Property(x => x.OurGoals)
                .IsRequired();

            Property(x => x.Principle)
                 .IsRequired();


            Property(x => x.Facebook)
              .HasMaxLength(100)
               .IsRequired();

            Property(x => x.Twitter)
              .HasMaxLength(100)
               .IsRequired();
            Property(x => x.Instagram)
              .HasMaxLength(100)
               .IsRequired();
            Property(x => x.Youtube)
              .HasMaxLength(100)
               .IsRequired();



            Property(x => x.Slider1)
               .IsRequired();

            Property(x => x.Slider2)
               .IsRequired();

            Property(x => x.Slider3)
               .IsRequired();

            Property(x => x.Slider4)
               .IsRequired();



    }
    }
}

using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class EmailSettingsMap : BaseMap<EmailSettings>
    {
        public EmailSettingsMap()
        {
            ToTable("EmailSettings");

            Property(x => x.Username)
                .HasMaxLength(100)
                .IsRequired();


            Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Mail)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Port)
                .IsRequired();

            Property(x => x.Host)
                  .HasMaxLength(100)
                .IsRequired();

          
        }
    }
}


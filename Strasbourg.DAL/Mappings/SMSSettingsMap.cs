using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SMSSettingsMap : BaseMap<SMSSettings>
    {
        public SMSSettingsMap()
        {
            ToTable("SMSSettings");

            Property(x => x.AppKey)
                .HasMaxLength(400)
                .IsRequired();

            Property(x => x.ConsumerKey)
      .HasMaxLength(400)
    .IsRequired();

            Property(x => x.Secret)
      .HasMaxLength(400)
.IsRequired();
            Property(x => x.ServiceName)
     .HasMaxLength(400)
.IsRequired();


        }

    }
}

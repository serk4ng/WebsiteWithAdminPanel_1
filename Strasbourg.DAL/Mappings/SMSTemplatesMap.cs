using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SMSTemplatesMap : BaseMap<SMSTemplates>
    {
        public SMSTemplatesMap()
        {
            ToTable("SMSTemplates");

            Property(x => x.Subject)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Message)
                .IsRequired();

        }
    }
}

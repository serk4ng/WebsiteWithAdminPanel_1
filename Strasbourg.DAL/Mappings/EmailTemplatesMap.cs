using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class EmailTemplatesMap : BaseMap<EmailTemplates>
    {
        public EmailTemplatesMap()
        {
            ToTable("EmailTemplates");

            Property(x => x.Subject)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Message)
                .IsRequired();

        }
    }
}

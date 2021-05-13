using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class EmailHistoryMap : BaseMap<EmailHistory>
    {
        public EmailHistoryMap()
        {
            ToTable("EmailHistory");

            Property(x => x.ReceiverMail)
                .HasMaxLength(200)
                .IsRequired();


            Property(x => x.Subject)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Message)
                .IsRequired();

        }
    }
}

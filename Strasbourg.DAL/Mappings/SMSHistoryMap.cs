using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SMSHistoryMap : BaseMap<SMSHistory>
    {
        public SMSHistoryMap()
        {
            ToTable("SMSHistory");


            Property(x => x.Phone)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Message)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}

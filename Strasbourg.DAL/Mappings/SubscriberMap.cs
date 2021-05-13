using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SubscriberMap : BaseMap<Subscriber>
    {
        public SubscriberMap()
        {
            ToTable("Subscribers");

            Property(x => x.Email)
                .IsRequired();

        }
    }
}

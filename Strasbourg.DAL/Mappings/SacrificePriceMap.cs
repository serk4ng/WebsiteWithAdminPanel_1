using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class SacrificePriceMap : BaseMap<SacrificePrice>
    {
        public SacrificePriceMap()
        {
            ToTable("SacrificePrice");
            Property(x => x.Price)
              .IsRequired();
        }
    }
}

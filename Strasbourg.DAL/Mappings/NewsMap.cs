using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class NewsMap : BaseMap<News>
    {
        public NewsMap()
        {
            ToTable("News");

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

 

            Property(x => x.Content)
                .IsRequired();

            Property(x => x.Image)
                .IsRequired();

            Property(x => x.NewsType)
             .IsRequired();
            Property(x => x.Category)
             .IsRequired();


        }
    }
}

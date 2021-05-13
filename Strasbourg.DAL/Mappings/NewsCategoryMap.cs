using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
   public class NewsCategoryMap : BaseMap<NewsCategory>
    {
        public NewsCategoryMap()
        {
            ToTable("NewsCategories");

            Property(x => x.CategoryName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class VideoMap : BaseMap<Video>
    {
        public VideoMap()
        {
            ToTable("Videos");

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Thumbnail)
                .IsRequired();

            Property(x => x.Url)
                .IsRequired();

        }
    }
}

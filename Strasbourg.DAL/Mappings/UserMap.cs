using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Mappings
{
    public class UsersMap : BaseMap<Users>
    {
        public UsersMap()
        {
            ToTable("Users");

            Property(x => x.NameSurname)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Degree)
     .HasMaxLength(50)
     .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}

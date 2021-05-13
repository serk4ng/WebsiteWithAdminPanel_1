using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Enums
{
    public enum UserType : byte
    {
        SuperAdmin = 1,
        Admin = 2,
        Personel = 3,
        Editor = 4
    }
}

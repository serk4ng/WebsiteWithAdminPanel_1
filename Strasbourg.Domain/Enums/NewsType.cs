using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Enums
{
    public enum NewsType : byte
    {
        [Display(Name = "Ditibden Haberler")]
        Ditibden = 1,
        [Display(Name = "Derneklerden Haberler")]
        Derneklerden = 2

 

}
  
}

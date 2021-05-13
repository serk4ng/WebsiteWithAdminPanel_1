using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Models
{
    public class Monetico : BaseModel
    {
        public string Version { get; set; }
        public string TPE { get; set; }
        public string Reference { get; set; }
        public string MAC { get; set; }
        public string Url_Retour_Ok { get; set; }
        public string Url_Retour_Err { get; set; }
        public string Lgue { get; set; }
        public string Societe { get; set; }
        public string Contexte_Commande { get; set; }
        public string Text_Libre { get; set; }

    }
}

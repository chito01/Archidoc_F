using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Archidoc_F.Models
{
    public class InscriptionModelcs
    {
        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_user { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string prenom_user { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string password { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string sexe { get; set; }

    }
}

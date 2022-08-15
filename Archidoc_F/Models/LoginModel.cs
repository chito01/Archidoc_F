using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Archidoc_F.Models
{
    public class LoginModel:ConnexionModel
    {
        [Required(ErrorMessage = "champs obligatoire")]
        public string username { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string password { get; set; }
        public bool UserExit(string u)
        {
            connecter();
            cmd.CommandText = "SELECT COUNT(id_agent) from Agent_porteur where nom_utilisateur='" + u + "'"; ;
            cmd.Connection = con;
            int statut = (int)cmd.ExecuteScalar();
            deconnecter();

            if (statut == 1)
            {
                return true;
            }
            return false;
        }

        public bool UserPWDExit(string u, string p)
        {
            connecter();
            cmd.CommandText = "SELECT COUNT(id_agent) from Agent_porteur where nom_utilisateur='" + u + "' AND mot_passe='" + p + "'";
            cmd.Connection = con;
            int statut = (int)cmd.ExecuteScalar();
            deconnecter();

            if (statut == 1)
            {
                return true;
            }
            return false;
        }

        public DataTable recupuserPwd(string u, string p)
        {
            connecter();
            cmd.CommandText = "SELECT * from Agent_porteur where nom_utilisateur='" + u + "' AND mot_passe='" + p + "'";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
       

    }
}

    


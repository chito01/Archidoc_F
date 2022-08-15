using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archidoc_F.Models
{
    public class Inscri : ConnexionModel
    {
        public bool AjouterUser(String query)
        {
            connecter();
            cmd.Connection = con;
            cmd.CommandText = query; 
            
            int result=cmd.ExecuteNonQuery();
            deconnecter();
            if (result >= 1)
            {
                return true;
            }
            return false;
        }
            }
}

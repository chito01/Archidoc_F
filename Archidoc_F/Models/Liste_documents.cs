using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Archidoc_F.Models
{
    public class Liste_documents:ConnexionModel
    {
        //Document
        
        [Required(ErrorMessage = "champs obligatoire")]
        public int numero_document { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string code_document { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_document { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string acronyme_document { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        
        //Commune

        public int numero_commune { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_commune { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string District { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        
        //Service de provenance
        
        public int numero_service { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        public string code_service { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_service { get; set; }

        //Employeur
        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_Employeur { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        
        public int numero_Employeur { get; set; }
        
        [Required(ErrorMessage = "champs obligatoire")]
        public string numero_Affiliation { get; set; }
        
        [Required(ErrorMessage = "champs obligatoire")]
        
                public string nom_District { get; set; }
        
        [Required(ErrorMessage = "champs obligatoire")]
        public string nom_TypeE { get; set; }
        
        [Required(ErrorMessage = "champs obligatoire")]
        public string Libelle_periode { get; set; }
        
        [Required(ErrorMessage = "champs obligatoire")]
        public string type_Document { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        public string Code_Archive { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        public string Libelle_Rayon { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string Nom_utilisateur { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]
        public string Prenom_utilsateur { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string username { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string password { get; set; }
       
        public DataTable recupuserPwd()
        {
            connecter();
            cmd.CommandText = "SELECT * from Nombre";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        
        public DataTable recupuserRegistre()
        {
            connecter();
            cmd.CommandText = "SELECT * from Nombre_Registre";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        public DataTable recupuserCommune()
        {
            connecter();
            cmd.CommandText = "SELECT * from Nombre_Commune";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        public DataTable recupuserAgent()
        {
            connecter();
            cmd.CommandText = "SELECT * from nombre_agent";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        public DataTable recupuserArchive()
        {
            connecter();
            cmd.CommandText = "SELECT * from Nombre_Archive";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        public DataTable recupuserService()
        {
            connecter();
            cmd.CommandText = "SELECT * from  nombre_service";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }
        public DataTable recupuserEmployeur()
        {
            connecter();
            cmd.CommandText = "SELECT * from Nombre_E";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);
            deconnecter();
            return dt;

        }

    }
}

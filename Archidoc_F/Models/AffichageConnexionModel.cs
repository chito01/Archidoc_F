using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Archidoc_F.Models
{
    public class AffichageConnexionModel:ConnexionModel
    {

        public List<Liste_documents>GetDocuments(string query)
        {
            List<Liste_documents> liste_Documents = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
                li.numero_document = Convert.ToInt16(rs["id_intitule"]);
                li.nom_document = Convert.ToString(rs["intitule_document"]);
                li.acronyme_document = Convert.ToString(rs["acronyme_document"]);
                liste_Documents.Add(li);
            }
            deconnecter();
            return (liste_Documents);
        }
        public List<Liste_documents> GetCommune(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
                li.numero_commune = Convert.ToInt16(rs["numero_commune"]);
                li.nom_commune = Convert.ToString(rs["nom_commune"]);
                li.District = Convert.ToString(rs["district"]);
                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public List<Liste_documents> GetService(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
                li.numero_service = Convert.ToInt16(rs["numero_service"]);
                li.code_service= Convert.ToString(rs["code_service"]);
                li.nom_service = Convert.ToString(rs["nom_service"]);
                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public List<Liste_documents> GetEmployeur(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
     
                li.nom_Employeur= Convert.ToString(rs["nom_employeur"]);
                li.numero_Affiliation = Convert.ToString(rs["num_affiliation"]);
                li.nom_commune = Convert.ToString(rs["nom_commune"]);
                li.nom_District = Convert.ToString(rs["district"]);
                li.nom_TypeE = Convert.ToString(rs["nom_type"]);

                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public List<Liste_documents> GetRegistre(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
     
                li.nom_service= Convert.ToString(rs["nom_service"]);
                li.nom_Employeur = Convert.ToString(rs["nom_employeur"]);
                li.nom_commune = Convert.ToString(rs["nom_commune"]);
                li.numero_Affiliation = Convert.ToString(rs["num_affiliation"]);
                li.nom_document = Convert.ToString(rs["intitule_document"]);
                li.Libelle_periode = Convert.ToString(rs["libele_periode"]);
                li.type_Document = Convert.ToString(rs["nom_typeD"]);
                li.nom_TypeE = Convert.ToString(rs["nom_type"]);

                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public List<Liste_documents> GetPorteur(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();

                li.nom_service = Convert.ToString(rs["nom_service"]);
                li.Nom_utilisateur = Convert.ToString(rs["nom_utilisateur"]);
                li.Prenom_utilsateur = Convert.ToString(rs["prenom_utilisateur"]);
                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public List<Liste_documents> Archivage(string query)
        {
            List<Liste_documents> liste_Document = new List<Liste_documents>();
            connecter();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Liste_documents li = new Liste_documents();
                li.Code_Archive = Convert.ToString(rs["code_Archive"]);
                li.nom_document = Convert.ToString(rs["intitule_document"]);
                li.type_Document = Convert.ToString(rs["nom_typeD"]);
                li.nom_Employeur = Convert.ToString(rs["nom_employeur"]);
                li.nom_TypeE = Convert.ToString(rs["nom_type"]);
                li.numero_Affiliation = Convert.ToString(rs["num_affiliation"]);
                li.nom_commune = Convert.ToString(rs["nom_commune"]);
                li.Libelle_periode = Convert.ToString(rs["libele_periode"]);
                li.Libelle_Rayon = Convert.ToString(rs["Libelle_rayon"]);
                li.nom_service = Convert.ToString(rs["nom_service"]);
                
                
                

                liste_Document.Add(li);
            }
            deconnecter();
            return (liste_Document);
        }
        public void AjouterID(Liste_documents ed)
        {
            connecter();
            cmd.Connection = con;
            cmd.CommandText = "insert into Intitule_document (intitule_document,acronyme_document) values (@intitule_document,@acronyme_document)";
           cmd.Parameters.Add("@intitule_document", SqlDbType.VarChar).Value = ed.nom_document;
            cmd.Parameters.Add("@acronyme_document", SqlDbType.VarChar).Value = ed.acronyme_document;
         
            //cmd.Connection = con;
            cmd.ExecuteNonQuery();


        }
        public void AjouterUser(InscriptionModelcs ed)
        {
            try
            {
                connecter();
                cmd.Connection = con;
                cmd.CommandText = "insert into Administrateur (nom_utilisateur,mot_passe,Sexe,prenom_utilisateur) values (@nom_utilisateur,@mot_passe,@Sexe,@prenom_utilisateur)";
                cmd.Parameters.Add("@nom_utilisateur", SqlDbType.VarChar).Value = ed.nom_user;
                cmd.Parameters.Add("@mot_passe", SqlDbType.VarChar).Value = ed.password;
                cmd.Parameters.Add("@Sexe", SqlDbType.NVarChar).Value = ed.sexe;
                cmd.Parameters.Add("@prenom_utilisateur", SqlDbType.NVarChar).Value = ed.prenom_user;
                cmd.ExecuteNonQuery();
                deconnecter();
            }
            catch (SqlException e)
            {
                
            }
            


        }
        public void Supprdoc(Liste_documents ed)
        {
            try
            {
                connecter();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Intitule_document where intitule_document=@intitule_document or acronyme_document=@acronyme_document )";
                cmd.Parameters.Add("@intitule_document", SqlDbType.VarChar).Value = ed.nom_document;
                cmd.Parameters.Add("@acronyme_document", SqlDbType.VarChar).Value = ed.acronyme_document;
                cmd.ExecuteNonQuery();
                deconnecter();
            }
            catch (SqlException e)
            {

            }



        }
    }
}

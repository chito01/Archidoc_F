using Archidoc_F.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rotativa;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Rotativa.AspNetCore;
using ViewAsPdf = Rotativa.AspNetCore.ViewAsPdf;
using Microsoft.AspNetCore.Http;
using System;

namespace Archidoc_F.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["id_user"] != null)
            {
                return RedirectToAction("Dashbord", "Home");
            }
            return View();
           
        }
        
        public IActionResult Inscription()
        {
            if (TempData["id_user"] == null)
            {
                return RedirectToAction("Login", "Home");
            } 
            return View();
        }
        [HttpPost]
        public IActionResult Inscription(InscriptionModelcs p)
        {
            if (ModelState.IsValid)
            {
                AffichageConnexionModel op = new AffichageConnexionModel();
                op.AjouterUser(p);
                TempData["valide"] = "L'enregistrement est effectué";
                //return RedirectToAction("Dashbord");
            }
            return View();
        }
        [HttpGet]

        public IActionResult S_Reception(Liste_documents list)
        {
           Liste_documents et = new Liste_documents(); 
            DataTable tb1 = et.recupuserCommune() ;
            foreach (DataRow row in tb1.Rows)
            {
                TempData["Commune"] = (int)row["Nombre_Commune"];
            }
            Aff_nombreA();
            Aff_nombre();
            Aff_nombreR();
            Aff_nombreE();
            Aff_nombreS();
            Aff_nombreAg();
            return View();
        }
        public void Aff_nombreAg()
        {
            Liste_documents et1 = new Liste_documents();

            DataTable tb = et1.recupuserAgent();
            foreach (DataRow row in tb.Rows)
            {
                TempData["idAg"] = (int)row["nombre_agent"];
            }

        }
        public void Aff_nombre()
        {
            Liste_documents et1 = new Liste_documents();

            DataTable tb = et1.recupuserPwd();
            foreach (DataRow row in tb.Rows)
            {
                TempData["id"] = (int)row["Nombre"];
            }

        }
        public void Aff_nombreA()
        {
            Liste_documents et2 = new Liste_documents();

            DataTable tb = et2.recupuserArchive();
            foreach (DataRow row in tb.Rows)
            {
                TempData["idA"] = (int)row["Nombre_Archive"];
            }

        }
        public void Aff_nombreR()
        {
            Liste_documents et3 = new Liste_documents();

            DataTable tb = et3.recupuserRegistre();
            foreach (DataRow row in tb.Rows)
            {
                TempData["idR"] = (int)row["Nombre_Registre"];
            }

        }
        public void Aff_nombreE()
        {
            Liste_documents et4 = new Liste_documents();

            DataTable tb = et4.recupuserEmployeur();
            foreach (DataRow row in tb.Rows)
            {
                TempData["idE"] = (int)row["Nombre_employeur"];
            }

        }
        public void Aff_nombreS()
        {
            Liste_documents et4 = new Liste_documents();

            DataTable tb = et4.recupuserService();
            foreach (DataRow row in tb.Rows)
            {
                TempData["idS"] = (int)row["nombre_service"];
            }

        }

        public IActionResult S_Reception()
        {
            return View();
        }  
        
        public IActionResult S_Communication()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query2 = "SELECT* from Intitule_document";
            List<Liste_documents> list = et.GetDocuments(query2);

            return View(list);

        }
        
        public IActionResult S_comAA()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type,rayon.Libelle_rayon,Archiver.code_Archive from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document,Archiver where Document.id_document=Archiver.id_document and Type_Document.id_typeD=Document.id_typeD and service_provenance.numero_service=Document.id_service and Employeur.numero_employeur=Document.numero_employeur and Document.id_intitule=intitule_document.id_intitule and Document.id_periodicite=Periode.id_periode and Commune.numero_commune=Employeur.numero_commune and Document.numero_employeur=Employeur.numero_employeur and rayon.numero_commune=Commune.numero_commune";
            List<Liste_documents> liste = et.Archivage(query1);
            return View(liste);
        }
        public IActionResult S_comAD()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from Intitule_document";
            List<Liste_documents> liste = et.GetDocuments(query1);
            return View(liste);

        }
        public IActionResult S_comAS()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from service_provenance";
            List<Liste_documents> liste = et.GetService(query1);
            return View(liste);

        }
        public IActionResult S_comAC()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from Commune";
            List<Liste_documents> liste = et.GetCommune(query1);
            return View(liste);
        }
        public IActionResult S_comAE()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "select Employeur.nom_employeur,Employeur.num_affiliation,Commune.nom_commune,Commune.district,Type_Employeur.nom_type from Employeur inner join  Commune on Commune.numero_commune = Employeur.numero_commune inner join Type_Employeur on Type_Employeur.numero_TypeE = Employeur.numero_type; ";
            List<Liste_documents> liste = et.GetEmployeur(query1);
            return View(liste);
        }
        [HttpGet]
        public IActionResult ID()
        {
            return View(new Liste_documents());
        }

        [HttpPost]
        public IActionResult ID(Liste_documents pe)
        {
            string intitule_document = pe.nom_document;
            string acronyme = pe.acronyme_document;
            string query= "insert into Intitule_document(intitule_document,acronyme_document) values ('"+intitule_document+ "','" + acronyme + "')";
                Inscri op = new Inscri();
            if (op.AjouterUser(query))
            {
                TempData["valide"] = "insertion est effectué";

            }
            else
            {
                TempData["valide"] = "insertion non effectué";

            }

            return View();
        }
        [HttpGet]
        public IActionResult IC()
        {
            return View(new Liste_documents());
        }

        [HttpPost]
        public IActionResult IC(Liste_documents pe)
        {
            string nc = pe.nom_commune;
            string di = pe.District;
            if (nc != null && di != null)
            {
                string query = "insert into Commune(nom_commune,district) values ('" + nc + "','" + di + "')";
                Inscri op = new Inscri();
                if (op.AjouterUser(query))
                {
                    TempData["valide"] = "insertion est effectué";

                }
                else
                {
                    TempData["valide"] = "insertion non effectué";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult IS()
        {
            return View(new Liste_documents());
        }

        [HttpPost]
        public IActionResult IS(Liste_documents pe)
        {
            string ns = pe.nom_service;
            string cs = pe.code_service;
            if (cs != null && ns != null)
            {
                string query = "insert into service_provenance(code_service,nom_service) values ('" + cs + "','" + ns + "')";
                Inscri op = new Inscri();
                if (op.AjouterUser(query))
                {
                    TempData["valide"] = "insertion effectué";

                }
                else
                {
                    TempData["valide"] = "insertion non effectué";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult MS()
        {
            return View(new Liste_documents());
        }

        [HttpPost]
        public IActionResult MS(Liste_documents pe)
        {
            string ns = pe.nom_service;
            string cs = pe.code_service;
            if (cs !=null && ns!=null)
            {
            string query= "DELETE FROM service_provenance where nom_service='" + ns+ "' or code_service='" + cs + "'";
                Inscri op = new Inscri();
            if (op.AjouterUser(query))
            {
                TempData["valide"] = "suppression effectué";

            }
            else
            {
                TempData["valide"] = "insertion non effectué";
            }
            }
            return View();
        }
        public IActionResult Inserer_document()
        {
            
            return View();
        }
       
        public IActionResult S_comAR()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document where Type_Document.id_typeD = Document.id_typeD and service_provenance.numero_service = Document.id_service and Employeur.numero_employeur = Document.numero_employeur and Document.id_intitule = intitule_document.id_intitule and Document.id_periodicite = Periode.id_periode and Commune.numero_commune = Employeur.numero_commune and Document.numero_employeur = Employeur.numero_employeur; ";
            List<Liste_documents> liste = et.GetRegistre(query1);
            return View(liste);
        }
          public IActionResult Affichage_Document()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from Intitule_document";
            List<Liste_documents> liste = et.GetDocuments(query1);
            return View(liste);
        }
        public IActionResult Affichage_Do()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from Intitule_document";
            List<Liste_documents> liste = et.GetDocuments(query1);
            return new ViewAsPdf(liste);
        }

        public IActionResult Affichage_Service()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from service_provenance";
            List<Liste_documents> liste = et.GetService (query1);
            return View(liste);
        }
        public IActionResult Affichage_Se()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT* from service_provenance";
            List<Liste_documents> liste = et.GetService(query1);
            return new ViewAsPdf(liste);
        }
        public IActionResult Affichage_AgentPorteur()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "Select Agent_porteur.nom_utilisateur,Agent_porteur.prenom_utilisateur,service_provenance.nom_service from  Agent_porteur,service_provenance where Agent_porteur.numero_service=service_provenance.numero_service";
            List<Liste_documents> liste = et.GetPorteur(query1);
            return View(liste);
            
        }
        public IActionResult S_comAP()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "Select Agent_porteur.nom_utilisateur,Agent_porteur.prenom_utilisateur,service_provenance.nom_service from  Agent_porteur,service_provenance where Agent_porteur.numero_service=service_provenance.numero_service";
            List<Liste_documents> liste = et.GetPorteur(query1);
            return View(liste);

        }
        public IActionResult Affichage_Registre_Global()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document where Type_Document.id_typeD = Document.id_typeD and service_provenance.numero_service = Document.id_service and Employeur.numero_employeur = Document.numero_employeur and Document.id_intitule = intitule_document.id_intitule and Document.id_periodicite = Periode.id_periode and Commune.numero_commune = Employeur.numero_commune and Document.numero_employeur = Employeur.numero_employeur; ";
            List<Liste_documents> liste = et.GetRegistre(query1);
            return View(liste);
        }
        public IActionResult Affichage_Registre_Glo()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document where Type_Document.id_typeD = Document.id_typeD and service_provenance.numero_service = Document.id_service and Employeur.numero_employeur = Document.numero_employeur and Document.id_intitule = intitule_document.id_intitule and Document.id_periodicite = Periode.id_periode and Commune.numero_commune = Employeur.numero_commune and Document.numero_employeur = Employeur.numero_employeur; ";
            List<Liste_documents> liste = et.GetRegistre(query1);
            return new ViewAsPdf(liste);
        }
        [HttpGet]

        public IActionResult Affichage_Archivage()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type,rayon.Libelle_rayon,Archiver.code_Archive from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document,Archiver where Document.id_document=Archiver.id_document and Type_Document.id_typeD=Document.id_typeD and service_provenance.numero_service=Document.id_service and Employeur.numero_employeur=Document.numero_employeur and Document.id_intitule=intitule_document.id_intitule and Document.id_periodicite=Periode.id_periode and Commune.numero_commune=Employeur.numero_commune and Document.numero_employeur=Employeur.numero_employeur and rayon.numero_commune=Commune.numero_commune";
            List<Liste_documents> liste = et.Archivage(query1);
            return View(liste);
        }
        public IActionResult Affichage_Archi()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "SELECT service_provenance.nom_service,Employeur.nom_employeur,Employeur.num_affiliation,Intitule_document.intitule_document,Periode.libele_periode,Commune.nom_commune,Type_Document.nom_typeD,Type_Employeur.nom_type,rayon.Libelle_rayon,Archiver.code_Archive from Periode,Commune,Employeur,Intitule_document,service_provenance,rayon,Type_Document,Type_Employeur,Document,Archiver where Document.id_document=Archiver.id_document and Type_Document.id_typeD=Document.id_typeD and service_provenance.numero_service=Document.id_service and Employeur.numero_employeur=Document.numero_employeur and Document.id_intitule=intitule_document.id_intitule and Document.id_periodicite=Periode.id_periode and Commune.numero_commune=Employeur.numero_commune and Document.numero_employeur=Employeur.numero_employeur and rayon.numero_commune=Commune.numero_commune";
            List<Liste_documents> liste = et.Archivage(query1);
            return new ViewAsPdf(liste);
        }
        public IActionResult Affichage_Employeur()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "select Employeur.nom_employeur,Employeur.num_affiliation,Commune.nom_commune,Commune.district,Type_Employeur.nom_type from Employeur inner join  Commune on Commune.numero_commune = Employeur.numero_commune inner join Type_Employeur on Type_Employeur.numero_TypeE = Employeur.numero_type; ";
            List<Liste_documents> liste = et.GetEmployeur(query1);
            return View(liste);
        }
        public IActionResult Affichage_Emplo()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query1 = "select Employeur.nom_employeur,Employeur.num_affiliation,Commune.nom_commune,Commune.district,Type_Employeur.nom_type from Employeur inner join  Commune on Commune.numero_commune = Employeur.numero_commune inner join Type_Employeur on Type_Employeur.numero_TypeE = Employeur.numero_type; ";
            List<Liste_documents> liste = et.GetEmployeur(query1);
            return new ViewAsPdf(liste);
        }
        public IActionResult Affichage_Commune()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query2 = "SELECT* from Commune";
            List<Liste_documents> list = et.GetCommune(query2);
            return View(list);
        }
        public IActionResult Affichage_Co()
        {
            AffichageConnexionModel et = new AffichageConnexionModel();
            string query2 = "SELECT* from Commune";
            List<Liste_documents> list = et.GetCommune(query2);
            return new ViewAsPdf(list);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
        public IActionResult Login()
        {
            if (TempData["id_user"] != null)
            {
                return RedirectToAction("Dashbord", "Home");
            }
                return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel b)
        {
            LoginModel et = new LoginModel();
            int m;
            string t, v, n, l, w, x, y, z;
            string u = b.username;
            string p = b.password;
            if (u != null && p != null)
            {
                if (et.UserExit(u) == true)
                {
                    if (et.UserPWDExit(u, p))
                    {
                        DataTable tb = et.recupuserPwd(u, p);
                        foreach (DataRow row in tb.Rows)
                        {
                            //creation des sessions
                            t = row["id_agent"].ToString();
                            w = row["nom_utilisateur"].ToString();
                            x = row["mot_passe"].ToString();
                            y = row["Sexe"].ToString();
                            z = row["prenom_utilisateur"].ToString();

                            //TempData["id_user"] = (Int32) HttpContext.Session.GetInt32(t) ;
                            ViewBag.L = HttpContext.Session.GetString(w);
                            TempData["password"] = HttpContext.Session.GetString(x);
                            TempData["sexe"] = HttpContext.Session.GetString(y);
                            TempData["user"] = HttpContext.Session.GetString(z);


                            //retourne une action ou vue
                            return RedirectToAction("S_reception", "Home");

                            //ViewBag.M = row["firstname"].ToString();
                        }

                    }
                    else
                    {
                        ViewData["name"] = "le user ou le password est incorrect...";
                    }


                }
                else
                {
                    ViewData["name"] = "Cet utilisateur n'existe pas";
                }
            }
            return View();
        }
       
        public IActionResult Dashbord()
        {
           
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeuDeNim.Models;

namespace JeuDeNim.Controllers
{
    public class NimController : Controller
    {
        public ActionResult ConfigPartie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfigPartie(ConfigModels model)
        {
            if (ModelState.IsValid)
            {
                //SI c'est ok, on redirige vers la page "Jeu" en fournissant l'instance model avec les informations saisies
                return RedirectToAction("Jeu", model);
            }
            else
            {
                //sinon on reste sur la même page en fournissant l'instance model avec les paramètres saisis; cela permet d'afficher les messages d'erreur et de concerver les infos correctes
                return View(model);
            }
        }

        public ActionResult Jeu(ConfigModels model)
        {
            int nbLigne = model.NbLignes;
            int nbSabre = 1;
           
            JeuModels jeuModels = new JeuModels();
            jeuModels.ligneDeSabre = new Dictionary<int,List<int>>();

            jeuModels.ligneDeSabre.Add(0, new List<int>() { 1 });
            
            for (int i = 1; i < nbLigne; i++)
            {
                List<int> mylist = new List<int>();
                nbSabre = nbSabre + 2;

                for (int j = 0; j < nbSabre; j++)
                {
                    mylist.Add(1);
                }
                jeuModels.ligneDeSabre.Add(i, mylist);
            }
               
            

            return View(jeuModels);
        }

        public ActionResult FinDePartie()
        {
            return View();
        }
    }
}
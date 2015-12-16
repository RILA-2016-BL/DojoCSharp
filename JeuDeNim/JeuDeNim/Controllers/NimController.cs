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
        public ActionResult ConfigPartie(JeuViewModels model)
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

        public ActionResult Jeu(JeuViewModels model)
        {
            return View(model);
        }

        public ActionResult FinDePartie()
        {
            return View();
        }
    }
}
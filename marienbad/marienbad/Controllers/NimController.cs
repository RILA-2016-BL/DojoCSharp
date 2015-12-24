using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marienbad.Models;

namespace marienbad.Controllers
{
    public class NimController : Controller
    {
        // GET
        public ActionResult Nim()
        {
            
                return View();
            

        }
        // POST: 
        [HttpPost]
        public ActionResult Nim(ConfigModels model )
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Jeu", model);
               
            }
            else
            {
                return View(model);
            }
           
        }
        public ActionResult Jeu(ConfigModels model)
        {
            int myRow = model.Row;
            int nbElement = 1;
            JeuModels jeuModels = new JeuModels();
            jeuModels.Items = new List<int>();

            jeuModels.Items.Add(1);
            for (int i = 1; i < myRow; i++)
            {
                nbElement = nbElement + 2;
                jeuModels.Items.Add(nbElement);
            }
            jeuModels.Nickname = model.Nickname;
            jeuModels.Checked = model.RememberMe;
;           return View(jeuModels);
        }
        // POST: 
        [HttpPost]
        public ActionResult Human(JeuModels model)
        {
            model.Items[model.Row] -= model.Count;
            return PartialView("Pyramide", model);

        }
        // POST: 
        [HttpPost]
        public ActionResult Computer(JeuModels model)
        {
            
            
           
            int result = this.SommeDeNim(model.Items);
            var indexAtMax = model.Items.ToList().IndexOf(model.Items.Max());
            if (result == 0)
            {
                // strategie perdante, rien de particulier à faire
                model.Items[indexAtMax] -= 1;
                return PartialView("Pyramide", model);
            }
            else
            {
                //strategie gagnante, j'essaye de la conserver, il faut donc trouver une combinaison 
                //qui donnera une somme de nim = 0
                model.Items = this.Recherche(model.Items);
                return PartialView("Pyramide", model);
            }
           
        }

        private int SommeDeNim(List<int> mylist)
        {
            int result = mylist[0];
            int len = mylist.Count;
            for (int i = 1; i < len; i++)
            {
                result = result ^ mylist[i];
            }
            return result;
        }
        private List<int> Recherche(List<int> mylist)
        {
            int test;
            int len = mylist.Count;
            List<int> tempList = new List<int>(mylist);
            for (int i = len; i > 0; i--)
            {
                
                int max = mylist[i-1];
                for (int j = 0; j < max; j++)
                {
                    tempList[i-1] -= 1;
                    test = SommeDeNim(tempList);
                    if (test == 0)
                    {
                        return tempList;
                    }
                    
                }
                tempList[i - 1] = max;

            }
            return mylist;
        }
    }
}
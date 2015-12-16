using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TourDeHanoi_Console
{
    public class Tour
    {
        public string Nom { get; set; }
        public List<int> Disques { get; set; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
    class Program
    {

        static List<Tour> Tours = new List<Tour>();
        static int nbDeplacements = 0;

        static void Main(string[] args)
        {
            Tour tour1 = new Tour()
            {
                Nom = "Tour d'origine",
                Disques = new List<int>()
            };
            Tour tour2 = new Tour()
            {
                Nom = "Tour intermediaire",
                Disques = new List<int>()
            };
            Tour tour3 = new Tour()
            {
                Nom = "Tour d'arrivée",
                Disques = new List<int>()
            };
            Tours.Add(tour1);
            Tours.Add(tour2);
            Tours.Add(tour3);

            DebutDuJeu();

            Deplacer(tour1.Disques.First(), tour1, tour2, tour3);

            Console.WriteLine("Fin du jeu : Nombre total de déplacement : " + nbDeplacements);
            RenduTours();

            Console.ReadLine();
        }

        static void DebutDuJeu()
        {

            Console.WriteLine("Veuillez entrer le nombre de disques : ");
            string nbDisquesTexte = Console.ReadLine();
            int nbDisques = 0;
            int.TryParse(nbDisquesTexte, out nbDisques);
            if (nbDisques == 0)
                DebutDuJeu();
            else
            {
                while(nbDisques > 0)
                {
                    Tours.First().Disques.Add(nbDisques);
                    nbDisques--;
                }
                Console.WriteLine("Lancement de l'algorithme de résolution : ");
                Thread.Sleep(500);
            }
        }

        static void RenduTours()
        {
            Thread.Sleep(1000);
            Console.WriteLine("**************************");
            Console.WriteLine(Tours.ElementAt(0).ToString() + " : " + string.Join(",", Tours.ElementAt(0).Disques));
            Console.WriteLine(Tours.ElementAt(1).ToString() + " : " + string.Join(",", Tours.ElementAt(1).Disques));
            Console.WriteLine(Tours.ElementAt(2).ToString() + " : " + string.Join(",", Tours.ElementAt(2).Disques));
            Console.WriteLine("************************** \n");
        }

        static void Deplacer(int ndisque, Tour tourSource, Tour tourPivot, Tour tourDestination)
        {
            if(ndisque == 1)
            {
                Console.WriteLine("On déplace le disque "+ tourSource.Disques.Last() +" de " + tourSource.ToString() + " vers " + tourDestination.ToString());
                
                int disque = tourSource.Disques.Last();
                tourSource.Disques.RemoveAt(tourSource.Disques.Count-1);
                tourDestination.Disques.Add(disque);
                nbDeplacements++;

                RenduTours();
            }
            else
            {
                Deplacer(ndisque - 1, tourSource, tourDestination, tourPivot);
                Deplacer(1, tourSource, tourPivot, tourDestination);
                Deplacer(ndisque - 1, tourPivot, tourSource, tourDestination);
            }
        } 
    }
}

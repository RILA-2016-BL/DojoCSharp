using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maevaCalc
{
    enum operateurs { addition,soustraction,division,multiplication}
    class calcul
    {
        decimal operande1, operande2;
        operateurs operateur;

        public calcul(decimal operande1, operateurs operateur, decimal operande2) {

            this.operande1 = operande1;
            this.operande2 = operande2;
            this.operateur = operateur;
        }

        public override string ToString()
        {
            string operateurHistorique = "";

            switch (this.operateur)
            {
                case operateurs.addition:
                    operateurHistorique = "+";
                    break;
                case operateurs.soustraction:
                    operateurHistorique = "-";
                    break;
                case operateurs.division:
                    operateurHistorique = "/";
                    break;
                case operateurs.multiplication:
                    operateurHistorique = "*";
                    break;
                default:
                    break;

            }
            operande1.ToString();
            operande2.ToString();
            return operande1 +" "+ operateurHistorique +" "+ operande2 ;
        }

        public decimal operation()
        {
            decimal resultat = 0;

            switch (this.operateur)
            {
                case operateurs.addition:
                    resultat = operande1 + operande2;
                    break;
                case operateurs.soustraction:
                    resultat = operande1 - operande2;
                    break;
                case operateurs.division:
                    if (operande2 == 0)
                    {
                        throw new Exception();

                    }
                    resultat = operande1 / operande2;
                    break;
                case operateurs.multiplication:
                    resultat = operande1 * operande2;
                    break;
                default:
                    break;
            }
            return resultat;
        }
    }
}

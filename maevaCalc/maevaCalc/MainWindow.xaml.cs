using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace maevaCalc
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {
        private decimal operande1;
        private decimal operande2;
        private DerniereAction action = DerniereAction.VIDE;
        string operateur = "";

        public Calculatrice calculatrice = new Calculatrice();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChiffreClick(object sender, RoutedEventArgs e)
        {
            if (action == DerniereAction.ENTREE_OPERATION)
            {
                tb_Affichage.Text = "";
            }
            string valeurClick = ((Button) sender).Content.ToString();
            if ((tb_Affichage.Text.Length)<29)
             tb_Affichage.Text += valeurClick;
            action = DerniereAction.ENTREE_CHIFFRE;
        }

        private void bt_division_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_Affichage.Text))
            {
                action = DerniereAction.ENTREE_OPERATION;
                if (operateur == "")
                {
                    operateur = "/";
                    operande1 = decimal.Parse(tb_Affichage.Text);
                    tb_Affichage.Text = "/";

                }
                else
                {
                    decimal tamp;
                    tamp=operande1/decimal.Parse(tb_Affichage.Text);
                    tb_Affichage.Text = tamp.ToString();
                    operande1 = tamp;
                    
                }
            }
        }

        private void bt_multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_Affichage.Text))
            {
                action = DerniereAction.ENTREE_OPERATION;
                if (operateur == "")
                {
                    operateur = "*";
                    operande1 = decimal.Parse(tb_Affichage.Text);
                    tb_Affichage.Text = operateur;

                }
                else
                {
                    decimal tamp;
                    tamp = operande1 / decimal.Parse(tb_Affichage.Text);
                    tb_Affichage.Text = tamp.ToString();
                    operande1 = tamp;

                }
            }
        }

        private void bt_moins_Copy_Click(object sender, RoutedEventArgs e)
        {
            operande1 = decimal.Parse(tb_Affichage.Text);
            tb_Affichage.Text += "-";
        }

        private void bt_plus_Copy_Click(object sender, RoutedEventArgs e)
        {
            operande1 = decimal.Parse(tb_Affichage.Text);
            tb_Affichage.Text += "+";
        }

        private void bt_egal_Click(object sender, RoutedEventArgs e)
        {
        
        }
        
    }
}

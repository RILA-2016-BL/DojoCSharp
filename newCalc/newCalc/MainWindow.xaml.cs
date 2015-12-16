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

namespace newCalc
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string OperateurEnCours = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }
        private void ChiffreClick(object sender, RoutedEventArgs e)
        {
            textBox.Text += ((Button)sender).Content;
        }
        private void EgalClick(object sender, RoutedEventArgs e)
        {
            CalculerResultat();
            OperateurEnCours = null;
        }
        private void OperateurClick(object sender, RoutedEventArgs e)
        {
            string operateur = ((Button)sender).Content.ToString();

            if (string.IsNullOrEmpty(OperateurEnCours))
            {
                OperateurEnCours = operateur;
                textBox.Text += operateur;
            }
            else
            {
                CalculerResultat();
                OperateurEnCours = operateur;
                textBox.Text += operateur;
            }

        }

        private void CalculerResultat()
        {
            bool flag = false;
            string text = textBox.Text;


            if (text[0] == '-')
            {
                text = text.Remove(0, 1);
                flag = true;
            }

            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(OperateurEnCours) && text.Split(OperateurEnCours.ToCharArray()).Count() > 1)
            {
                decimal operande1 = 0;
                decimal operande2 = 0;

                string test = text.Split(OperateurEnCours.ToCharArray()).First();
                decimal.TryParse(test, out operande1);

                if (flag)
                {
                    operande1 = -operande1;
                    flag = false;
                }

                test = text.Split(OperateurEnCours.ToCharArray()).Last();
                decimal.TryParse(test, out operande2);

                switch (OperateurEnCours)
                {
                    case "+":
                        textBox.Text = (operande1 + operande2).ToString();
                        break;
                    case "-":
                        textBox.Text = (operande1 - operande2).ToString();
                        break;
                    case "*":
                        textBox.Text = (operande1 * operande2).ToString();
                        break;
                    case "/":
                        if (operande2 != 0)
                            textBox.Text = (operande1 / operande2).ToString();
                        break;
                }

            }


        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            bool numValable = false;

            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                numValable = true;
                textBox.Text += e.Key;
            }
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
            {
                numValable = true;
            }
            switch (e.Key)
            {
                case Key.Multiply:
                    numValable = true;
                    break;
                case Key.Add:
                    numValable = true;
                    break;
                case Key.Subtract:
                    numValable = true;
                    break;
                case Key.Divide:
                    numValable = true;
                    break;
                case Key.Enter:
                    numValable = true;
                    break;

            } 
            
              
        }
    }
}

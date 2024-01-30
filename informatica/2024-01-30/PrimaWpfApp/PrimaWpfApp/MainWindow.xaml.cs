/* Marco Balducci 3H 2024-01-30
 * Prima applicazione wpf
*/
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

namespace PrimaWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcola() //funzione per il calcolo del perimetro
        {
            string lato1 = lato1txt.Text;
            string lato2 = lato2txt.Text;

            bool flag = true;

            //check input
            if (!double.TryParse(lato1, out double lato1num)) { lato1txt.Text = "Questo non è un numero!"; flag = false; MessageBox.Show("Valore per lato 1 non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error); }
            if (!double.TryParse(lato2, out double lato2num)) { lato2txt.Text = "Questo non è un numero!"; flag = false; MessageBox.Show("Valore per lato 2 non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error); }

            if (flag) { risultatotxt.Text = ((lato1num + lato2num) * 2).ToString(); lato1txt.IsEnabled = false; lato2txt.IsEnabled = false; }
        }

        private void btnCalcolaPerimetro_Click(object sender, RoutedEventArgs e) //evento pressione button calcola
        {
            Calcola();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e) //evento button reset
        {
            lato1txt.Text = string.Empty;
            lato2txt.Text = string.Empty;
            risultatotxt.Text = string.Empty;

            lato1txt.IsEnabled = true;
            lato2txt.IsEnabled = true;
        }
    }
}

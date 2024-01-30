/* Marco Balducci 3H 2024-30-01
 * App Wpf che converte un numero in input in parola utilizzando una funzione creata in precedenza
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

namespace CifreToLettereWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 1;
        private string converti(int numero) //converte un numero in input compreso tra 0 e 9999 in parole
        {

            //dichiarazione dati
            bool teenCase = false; //controllo input e casi particolari (11-19)
            string result = "";


            #region traduzione numero

            #region migliaia

            switch (numero / 1000) //considero solo le migliaia
            {
                case 1:
                    result = "mille"; //aggiunta migliaia
                    break;
                case 2:
                    result = "duemila";//aggiunta migliaia
                    break;
                case 3:
                    result = "tremila"; //aggiunta migliaia
                    break;
                case 4:
                    result = "quattromila"; //aggiunta migliaia
                    break;
                case 5:
                    result = "cinquemila"; //aggiunta migliaia
                    break;
                case 6:
                    result = "seimila"; //aggiunta migliaia
                    break;
                case 7:
                    result = "settemila";//aggiunta migliaia
                    break;
                case 8:
                    result = "ottomila"; //aggiunta migliaia
                    break;
                case 9:
                    result = "novemila"; //aggiunta migliaia
                    break;
            }

            numero = numero % 1000; //number diventa centinaia + decine + unità

            #endregion

            #region centinaia

            switch (numero / 100) //considero solo le centinaia
            {
                case 1:
                    result += "cento"; //aggiunta centinaia
                    break;
                case 2:
                    result += "duecento"; //aggiunta centinaia
                    break;
                case 3:
                    result += "trecento"; //aggiunta centinaia
                    break;
                case 4:
                    result += "quattrocento"; //aggiunta centinaia
                    break;
                case 5:
                    result += "cinquecento"; //aggiunta centinaia
                    break;
                case 6:
                    result += "seicento"; //aggiunta centinaia
                    break;
                case 7:
                    result += "settecento"; //aggiunta centinaia
                    break;
                case 8:
                    result += "ottocento"; //aggiunta centinaia
                    break;
                case 9:
                    result += "novecento"; //aggiunta centinaia
                    break;
            }

            numero = numero % 100; //number diventa decine + unità

            #endregion

            #region decine

            switch (numero / 10) //considero solo le decine
            {
                case 1: //casi particolari tra 11 e 19
                    switch (numero)
                    {
                        case 11:
                            result += "undici";
                            break;
                        case 12:
                            result += "dodici";
                            break;
                        case 13:
                            result += "tredici";
                            break;
                        case 14:
                            result += "quattordici";
                            break;
                        case 15:
                            result += "quindici";
                            break;
                        case 16:
                            result += "sedici";
                            break;
                        case 17:
                            result += "diciassette";
                            break;
                        case 18:
                            result += "diciotto";
                            break;
                        case 19:
                            result += "diciannove";
                            break;
                    }

                    teenCase = true; //se rientra in uno dei casi da 11 a 19 lo ricordo per quando dovrò considerare le unità
                    break;

                case 2:
                    result += "venti"; //aggiunta decina
                    break;
                case 3:
                    result += "trenta";//aggiunta decina
                    break;
                case 4:
                    result += "quaranta";//aggiunta decina
                    break;
                case 5:
                    result += "cinquanta";//aggiunta decina
                    break;
                case 6:
                    result += "sessanta";//aggiunta decina
                    break;
                case 7:
                    result += "settanta";//aggiunta decina
                    break;
                case 8:
                    if (result != "")
                    {
                        if (!result.EndsWith("A")) result = result.Substring(0, result.Length - 1); //se finisce con A non può essere troncato
                    }
                    result += "ottanta"; //aggiunta decina
                    break;
                case 9:
                    result += "novanta"; //aggiunta decina
                    break;
            }

            #endregion

            #region unità

            if (!teenCase) //se il numero rientra nei casi tra 11 e 19, allora non vengono considerate le unità nel tradurre.
            {
                switch (numero % 10) //considero le unità, il numero contiene ancora sia decine che unità
                {
                    case 0:
                        if (result == "") result = "zero"; //lo zero viene aggiunto solo se il numero è 0.
                        break;
                    case 1:
                        if (numero / 10 != 0) result = result.Substring(0, result.Length - 1); //se il numero ha una decina diversa da 0, allora avviene il troncamento
                        result += "uno"; //aggiunta unità
                        break;
                    case 2:
                        result += "due"; //aggiunta unità
                        break;
                    case 3:
                        result += "tre"; //aggiunta unità
                        break;
                    case 4:
                        result += "quattro"; //aggiunta unità
                        break;
                    case 5:
                        result += "cinque";//aggiunta unità
                        break;
                    case 6:
                        result += "sei"; //aggiunta unità
                        break;
                    case 7:
                        result += "sette"; //aggiunta unità
                        break;
                    case 8:
                        if (numero / 10 != 0) result = result.Substring(0, result.Length - 1); //se il numero ha una decina diversa da 0 aviene il troncamento
                        result += "otto"; //aggiunta unità
                        break;
                    case 9:
                        result += "nove"; //aggiunta unità
                        break;
                }
            }

            #endregion

            #endregion

            return result;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            //controllo dell'input per la funzione converti
            if (!int.TryParse(txtInput.Text, out int numero)) MessageBox.Show("Valore inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            else {
                if (numero < 0 || numero > 9999) MessageBox.Show("Valore inserito deve essere compreso tra 0 e 9999", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                else { txtOutput.Text = converti(numero); liCronologia.Items.Insert(0, $"{counter++}: {txtOutput.Text}"); }//stampa risultato
            }
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e) //funzione del placeholder sotto la finestra di input
        {
            if (txtInput.Text.Length > 0) txtPlaceHolder.Visibility = Visibility.Hidden;
            else txtPlaceHolder.Visibility = Visibility.Visible;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e) //funzione azionata dal button reset che pulisce tutti i campi inclusa la cronologia
        {
            liCronologia.Items.Clear();
            counter = 1;
            txtOutput.Text = "risultato";
            txtInput.Text = string.Empty;
        }
    }
}

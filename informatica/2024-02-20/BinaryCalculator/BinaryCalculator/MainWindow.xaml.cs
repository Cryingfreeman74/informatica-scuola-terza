/* Marco Balducci 3H 06/02/2024
 * Programma wpf - calcolatrice che utilizza operatori bitwise
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

namespace BinaryCalculator
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

        #region conversioni
        private string ConvertTo2(int num) //conversione 10 -> 2 
        {
            string result = "";

            //conversione
            while(num > 0)
            {
                result = num%2 + result;
                num /= 2;
            }

            //padding stringa risultato in modo da avere sempre 8 bit
            while(result.Length < 8) result = "0" + result;

            return result;
        } 
        private int ConvertTo10(string input) //conversione 2 -> 10
        {
            int value = 0;

            //conversione
            for (int i = input.Length - 1; i >= 0; i--)
            {
                value += int.Parse(input[i].ToString()) * (int)Math.Pow(2, input.Length - 1 - i);
            }
            return value;
        }

        #endregion

        #region primo Input
        private void btn1_1_Click(object sender, RoutedEventArgs e) //aggiunta 1 a prima label
        {
            txtInput1.Content = txtInput1.Content.ToString().Substring(1, 7) + "1";
        }

        private void btn0_1_Click(object sender, RoutedEventArgs e) //aggiunta 0 a prima label
        {
            txtInput1.Content = txtInput1.Content.ToString().Substring(1, 7) + "0";
        }

        private void btn1_2_Click(object sender, RoutedEventArgs e) //aggiunta 1 a seconda label
        {
            txtInput2.Content = txtInput2.Content.ToString().Substring(1, 7) + "1";
        }

        private void btn0_2_Click(object sender, RoutedEventArgs e) //aggiunta 0 a seconda label
        {
            txtInput2.Content = txtInput2.Content.ToString().Substring(1, 7) + "0";
        }

        private void btnback_Click(object sender, RoutedEventArgs e) //diminuisce il valore con cui shiftare
        {
            int value = int.Parse(txtShift.Content.ToString());
            if (value > 0)
                txtShift.Content = --value;
        }

        private void btnforward_Click(object sender, RoutedEventArgs e) //aumenta il valore con cui shiftare
        {
            int value = int.Parse(txtShift.Content.ToString());
            txtShift.Content = ++value;
        }

        private void btnShiftDirection_Click(object sender, RoutedEventArgs e) //cambia la direzione in cui shiftare
        {
            if (btnShiftDirection.Content.ToString() == "<-") btnShiftDirection.Content = "->";
            else btnShiftDirection.Content = "<-";
        }

        private void btnNot_Click(object sender, RoutedEventArgs e) //effettua il not del contenuto della prima label
        {
            string input = txtInput1.Content.ToString();
            int value = ConvertTo10(input);
            value = ~value;
            int bitmask = (1 << 9) -1; //1111 1111
            string result = ConvertTo2(value & bitmask); //il risultato dell'and sono gli ultimi 8 bit del risultato del not e non viene generato un problema derivante dal segno del numero da convertire in 2
            txtInput1.Content = result.Substring(result.Length-8,8);
        }

        private void btnShift_Click(object sender, RoutedEventArgs e) //shift in base alla direzione contenuta nel bottone btnShiftDirection
        {
            //ottengo il valore
            int value = ConvertTo10(txtInput1.Content.ToString());
            if (btnShiftDirection.Content == "->")
                value = value >> int.Parse(txtShift.Content.ToString());
            else value = value << int.Parse(txtShift.Content.ToString());

            string exposed_result = ConvertTo2(value);

            //scarto bit in eccesso
            if(exposed_result.Length > 8)
                exposed_result = exposed_result.Substring(exposed_result.Length-8,8);

            txtInput1.Content = exposed_result;
        }

        #endregion

        #region secondo Input
        private void btnNot_2_Click(object sender, RoutedEventArgs e) //not del valore contenuto nella seconda label
        {
            string input = txtInput2.Content.ToString();
            int value = ConvertTo10(input);
            value = ~value;
            int bitmask = (1 << 9) - 1; //1111 1111
            string result = ConvertTo2(value & bitmask); //il risultato dell'and sono gli ultimi 8 bit del risultato del not e non viene generato un problema derivante dal segno del numero da convertire in 2
            txtInput2.Content = result.Substring(result.Length - 8, 8);
        }

        private void btnShift_2_Click(object sender, RoutedEventArgs e) //effettua lo shift del valore contenuto nella seconda label in base alla direzione contenuta nel bottone btnShiftDirection_2
        {
            //ottengo il valore
            int value = ConvertTo10(txtInput2.Content.ToString());
            if (btnShiftDirection_2.Content == "->")
                value = value >> int.Parse(txtShift_2.Content.ToString());
            else value = value << int.Parse(txtShift_2.Content.ToString());

            string exposed_result = ConvertTo2(value);

            //scarto bit in eccesso
            if (exposed_result.Length > 8)
                exposed_result = exposed_result.Substring(exposed_result.Length - 8, 8);

            txtInput2.Content = exposed_result;
        }

        private void btnback_2_Click(object sender, RoutedEventArgs e) //diminuisce il valore con cui shiftare
        {
            int value = int.Parse(txtShift_2.Content.ToString());
            if (value > 0)
                txtShift_2.Content = --value;
        }

        private void btnforward_2_Click(object sender, RoutedEventArgs e) //aumenta il valore con cui shiftare
        {
            int value = int.Parse(txtShift_2.Content.ToString());
            txtShift_2.Content = ++value;
        }

        private void btnShiftDirection_2_Click(object sender, RoutedEventArgs e) //cambia la direzione verso cui shiftare
        {
            if (btnShiftDirection_2.Content.ToString() == "<-") btnShiftDirection_2.Content = "->";
            else btnShiftDirection_2.Content = "<-";
        }

        #endregion

        #region operazioni a 2 operandi
        private void btnAnd_Click(object sender, RoutedEventArgs e) //and tra i 2 operandi
        {
            //ottengo i valori
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            //operazione e conversione
            int result = value1 & value2;
            string exposed_result = ConvertTo2(result);

            txtResult.Content = exposed_result;
        }

        private void btnOr_Click(object sender, RoutedEventArgs e) //or tra i 2 operandi
        {
            //ottengo i valori
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            //operazione e conversione
            int result = value1 | value2;
            string exposed_result = ConvertTo2(result);

            txtResult.Content = exposed_result;
        }

        private void btnXor_Click(object sender, RoutedEventArgs e) //xor tra i 2 operandi
        {
            //ottengo i valori
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            //operazione e conversione
            int result = value1 ^ value2;
            string exposed_result = ConvertTo2(result);

            txtResult.Content = exposed_result;
        }

        #endregion

        private void btnReset_Click(object sender, RoutedEventArgs e) //reset completo
        {
            //azzera i valori di tutte caselle di testo
            txtInput1.Content = "00000000";
            txtInput2.Content = "00000000";
            txtResult.Content = "00000000";

            //azzera i valori delle caselle di testo dello shift
            txtShift.Content = "0";
            txtShift_2.Content = "0";

            //le direzioni di shift tornano allo stato iniziale
            btnShiftDirection.Content = "<-";
            btnShiftDirection_2.Content = "<-";
        }
    }
}

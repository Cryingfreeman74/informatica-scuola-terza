/* Marco Balducci 3H 06702/2024
 * Programma wpf - calcolatrice che utilizza operatori bitwise
 * */

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

        private string ConvertTo2(int num)
        {
            string result = "";

            while(num > 0)
            {
                result = num%2 + result;
                num /= 2;
            }

            return result;
        }
        private int ConvertTo10(string input)
        {
            int value = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                value += int.Parse(input[i].ToString()) * (int)Math.Pow(2, input.Length - 1 - i);
            }
            return value;
        }

        private void btn1_1_Click(object sender, RoutedEventArgs e)
        {
            txtInput1.Content = txtInput1.Content.ToString().Substring(1, 7) + "1";
        }

        private void btn0_1_Click(object sender, RoutedEventArgs e)
        {
            txtInput1.Content = txtInput1.Content.ToString().Substring(1, 7) + "0";
        }

        private void btn1_2_Click(object sender, RoutedEventArgs e)
        {
            txtInput2.Content = txtInput2.Content.ToString().Substring(1, 7) + "1";
        }

        private void btn0_2_Click(object sender, RoutedEventArgs e)
        {
            txtInput2.Content = txtInput2.Content.ToString().Substring(1, 7) + "0";
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(txtShift.Content.ToString());
            if (value > 0)
                txtShift.Content = --value;
        }

        private void btnforward_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(txtShift.Content.ToString());
            txtShift.Content = ++value;
        }

        private void btnShiftDirection_Click(object sender, RoutedEventArgs e)
        {
            if (btnShiftDirection.Content.ToString() == "<-") btnShiftDirection.Content = "->";
            else btnShiftDirection.Content = "<-";
        }

        private void btnNot_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput1.Content.ToString();
            int value = ConvertTo10(input);
            string result = Convert.ToString(~value, 2);
            txtInput1.Content = result.Substring(result.Length-8,8);
        }

        private void btnAnd_Click(object sender, RoutedEventArgs e)
        {
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            int result = value1 & value2;
            string exposed_result = ConvertTo2(result);
            while (exposed_result.Length < 8) exposed_result = "0" + exposed_result; 

            txtResult.Content = exposed_result;
        }

        private void btnOr_Click(object sender, RoutedEventArgs e)
        {
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            int result = value1 | value2;
            string exposed_result = ConvertTo2(result);
            while (exposed_result.Length < 8) exposed_result = "0" + exposed_result;

            txtResult.Content = exposed_result;
        }

        private void btnXor_Click(object sender, RoutedEventArgs e)
        {
            int value1 = ConvertTo10(txtInput1.Content.ToString());
            int value2 = ConvertTo10(txtInput2.Content.ToString());

            int result = value1 ^ value2;
            string exposed_result = ConvertTo2(result);
            while (exposed_result.Length < 8) exposed_result = "0" + exposed_result;

            txtResult.Content = exposed_result;
        }

        private void btnShift_Click(object sender, RoutedEventArgs e)
        {
            int value = ConvertTo10(txtInput1.Content.ToString());
            if (btnShiftDirection.Content == "->")
                value = value >> int.Parse(txtShift.Content.ToString());
            else value = value << int.Parse(txtShift.Content.ToString());

            string exposed_result = ConvertTo2(value);
            if(exposed_result.Length <= 8)
                while (exposed_result.Length < 8) exposed_result = "0" + exposed_result;
            else
                exposed_result = exposed_result.Substring(exposed_result.Length-8,8);


            txtInput1.Content = exposed_result;
        }

        private void btnNot_2_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput2.Content.ToString();
            int value = ConvertTo10(input);
            string result = Convert.ToString(~value, 2);
            txtInput2.Content = result.Substring(result.Length - 8, 8);
        }

        private void btnShift_2_Click(object sender, RoutedEventArgs e)
        {
            int value = ConvertTo10(txtInput2.Content.ToString());
            if (btnShiftDirection_2.Content == "->")
                value = value >> int.Parse(txtShift_2.Content.ToString());
            else value = value << int.Parse(txtShift_2.Content.ToString());

            string exposed_result = ConvertTo2(value);
            if (exposed_result.Length <= 8)
                while (exposed_result.Length < 8) exposed_result = "0" + exposed_result;
            else
                exposed_result = exposed_result.Substring(exposed_result.Length - 8, 8);


            txtInput2.Content = exposed_result;
        }

        private void btnback_2_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(txtShift_2.Content.ToString());
            if (value > 0)
                txtShift_2.Content = --value;
        }

        private void btnforward_2_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(txtShift_2.Content.ToString());
            txtShift_2.Content = ++value;
        }

        private void btnShiftDirection_2_Click(object sender, RoutedEventArgs e)
        {
            if (btnShiftDirection_2.Content.ToString() == "<-") btnShiftDirection_2.Content = "->";
            else btnShiftDirection_2.Content = "<-";
        }
    }
}

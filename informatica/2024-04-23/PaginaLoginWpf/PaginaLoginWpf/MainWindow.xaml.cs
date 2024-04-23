using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PaginaLoginWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Credenziali Credenziali;
        public MainWindow()
        {
            InitializeComponent();
            Credenziali = new Credenziali(@"..\..\..\..\archivio.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Credenziali.AutenticaUtente(txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("bravo");
                }
                else MessageBox.Show("!bravo");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Credenziali.Register(txtNome.Text, txtCognome.Text, txtUsernameReg.Text, txtPasswordReg.Text);
        }
    }
}

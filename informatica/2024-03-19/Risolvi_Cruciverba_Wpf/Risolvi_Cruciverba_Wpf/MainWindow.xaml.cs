/* Marco Balducci 3H 2024-03-12
 * Programma Risolutore di cruciPuzzle con gestione di file in input e di elementi grafici wpf
*/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Compression;
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

using Path = System.IO.Path;

namespace Risolvi_Cruciverba_Wpf
{
    public partial class MainWindow : Window
    {
        private char[,] matrix;                 //matrice dove viene salvato il crucipuzzle
        private HashSet<string> solutions;      //soluzioni fornite in input
        private Random rnd = new Random();      
        private SolidColorBrush defaultBrush;   //colore default del brush

        Button[,] buttons;                      //matrice di buttons necessaria per la grafica

        private char[,] SetUpMatrix(string percorso)    //funzione richiamata per creare la mappa del crucipuzzle
        {

            List<string> lista = new List<string>();    //lista dove vengono salvate le linee lette
            using (StreamReader sr = new StreamReader(percorso))
            {
                while (!sr.EndOfStream) //lettura file 
                {
                    string linea = sr.ReadLine();
                    if (linea == "") break; //se trovo una linea vuota allora ho finito di leggere la mappa

                    lista.Add(linea); //memorizzo la linea letta
                }
                sr.Close();
            }

            char[,] matrix = new char[lista.Count, lista[0].Length]; //istanzio la matrice che contiene il crucipuzzle

            //riempio la matrice utilizzando le stringhe lette salvate nella lista
            for (int ir = 0; ir < matrix.GetLength(0); ir++)
            {
                for (int ic = 0; ic < matrix.GetLength(1); ic++)
                {
                    matrix[ir, ic] = lista[ir][ic];
                }
            }
            return matrix;
        }

        private HashSet<string> SetUpSolutions(char[,] matrix, string percorso) //deve essere chiamata dopo SetUpMatrix
        {
            HashSet<string> tempSolutions = new HashSet<string>(); //hashset temporaneo che contiene le soluzioni
            using (StreamReader sr = new StreamReader(percorso))
            {
                //skip delle linee contenenti la matrice
                for (int i = 0; i <= matrix.GetLength(0); i++)
                    sr.ReadLine();

                //ottengo le soluzioni effettive
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    tempSolutions.Add(linea);
                }
                sr.Close();
            }

            //controllo che ci sia almeno una soluzione
            if (tempSolutions.Count == 0) throw new Exception("Non abbastanza soluzioni contenute nel file.");

            return tempSolutions; //passando il riferimento all'hashset temporaneo salvo le soluzioni in un altro hashset
        }

        private void Risolvi(string to_find)
        {

            int count = typeof(Brushes).GetProperties().Length;
            int index = rnd.Next(count);
            var brush = (SolidColorBrush)typeof(Brushes).GetProperties()[index].GetValue(null);

            List<(int riga, int colonna)> posizioni = new List<(int,int)>();

            if (to_find == null) return;

            for(int ir = 0; ir < matrix.GetLength(0); ir++)
                for(int ic = 0; ic <  matrix.GetLength(1); ic++)
                    if (matrix[ir, ic] == to_find[0])
                        posizioni.Add((ir, ic));

            bool found = false;

            foreach ((int riga, int colonna) posizione  in posizioni)
            {
                if (found) break;

                int ir = posizione.riga;
                int ic = posizione.colonna;

                string current;

                current = "";
                //caso alto
                for (int r = ir; r >= 0; r--)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[r, ic];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }

                }

                if (found) break;

                current = "";
                //caso alto-dx
                for (int j = 0; j >= 0; j++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir - j, ic + j];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic + i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso dx
                for (int c = ic; c < matrix.GetLength(1); c++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir, c];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir, ic + i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso basso-dx
                for (int j = 0; j >= 0; j++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir + j, ic + j];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic + i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso basso
                for (int r = ir; r < matrix.GetLength(0); r++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[r, ic];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso basso-sx
                for (int j = 0; j >= 0; j++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir + j, ic - j];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic - i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso sx
                for (int c = ic; c >= 0; c--)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir, c];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir, ic - i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

                if (found) break;

                current = "";
                //caso alto-sx
                for (int j = 0; j >= 0; j++)
                {
                    try
                    {
                        if (current.Length > to_find.Length) break;

                        current += matrix[ir - j, ic - j];
                        if (current == to_find)
                        {
                            lstParole.Items.Remove(current);
                            solutions.Remove(current);
                            for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic - i].Background = brush;
                            found = true;
                            break;
                        }
                    }
                    catch { break; }
                }

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LeggiFile(string percorso)
        {
            matrix = SetUpMatrix(percorso);
            solutions = SetUpSolutions(matrix, percorso);
            buttons = new Button[matrix.GetLength(0), matrix.GetLength(1)];
        }

        private void btnCarica_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                const string FILEDEFAULT = "matrice.txt";
                string percorso = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\");

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = percorso;
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                openFileDialog.FileName = FILEDEFAULT;
                if (openFileDialog.ShowDialog() == true)
                {
                    percorso = openFileDialog.FileName;
                    LeggiFile(percorso);
                }

                lstParole.Items.Clear();
                gridMap.Children.Clear();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Button b = new Button();
                        b.Height = 29;
                        b.Width = 29;
                        b.HorizontalAlignment = HorizontalAlignment.Left;
                        b.VerticalAlignment = VerticalAlignment.Top;
                        b.Margin = new Thickness(j * 30, i * 30, 0, 0);
                        b.Content = matrix[i, j];
                        gridMap.Children.Add(b);
                        buttons[i, j] = b;
                    }
                }

                defaultBrush = (SolidColorBrush)buttons[0, 0].Background;

                lstParole.IsEnabled = true;
                btnRisolvi.IsEnabled = true;
                btnParolaNascosta.IsEnabled = true;
                btnRisolviTutto.IsEnabled = true;

                lstParole.IsEnabled = true;
                List<string> temp = solutions.ToList<string>();
                foreach (string solution in temp)
                    lstParole.Items.Add(solution);
            } catch 
            { 
                MessageBox.Show("Errore nell'importazione del file!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                lstParole.IsEnabled = false;
                btnRisolvi.IsEnabled = false;
                btnParolaNascosta.IsEnabled = false;
                btnRisolviTutto.IsEnabled = false;
            }
            
        }

        private void btnRisolvi_Click(object sender, RoutedEventArgs e)
        {
            if(lstParole.SelectedValue != null)
            {
                Risolvi(lstParole.SelectedValue?.ToString());
                btnRisolvi.IsEnabled = false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRisolvi.IsEnabled = true;
        }

        private void risolvi_tutto_Click(object sender, RoutedEventArgs e)
        {
            string[] parole = new string[lstParole.Items.Count];
            lstParole.Items.CopyTo(parole, 0);

            foreach(string item in parole)
            {
                Risolvi(item);
            }
        }

        private void btnParolaNascosta_Click(object sender, RoutedEventArgs e)
        {
            if(solutions.Count == 0)
            {
                string parolaNascosta = "";

                foreach(Button b in buttons)
                {
                    BrushConverter brushConverter = new BrushConverter();
                    if (b.Background == defaultBrush)
                        parolaNascosta += b.Content;
                }

                MessageBox.Show($"Congratulations! La parola nascosta essere: {parolaNascosta}", "WOW!", MessageBoxButton.OK, MessageBoxImage.Information);
            } else MessageBox.Show("Non hai ancora risolto tutto il crucipuzzle!", "ehrm, actually...", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
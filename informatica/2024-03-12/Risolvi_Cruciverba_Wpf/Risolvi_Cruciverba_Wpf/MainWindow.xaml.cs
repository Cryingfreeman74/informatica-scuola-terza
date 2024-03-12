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

using Path = System.IO.Path;

namespace Risolvi_Cruciverba_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[,] matrix;
        private HashSet<string> solutions;

        Button[,] buttons;

        private char[,] SetUpMatrix(string percorso)
        {

            List<string> lista = new List<string>();
            using (StreamReader sr = new StreamReader(percorso))
            {
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    if (linea == "") break;

                    lista.Add(linea);
                }
                sr.Close();
            }
            char[,] matrix = new char[lista.Count, lista[0].Length];

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
            HashSet<string> tempSolutions = new HashSet<string>();
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

            return tempSolutions;
        }

        private void Risolvi()
        {
            for (int ir = 0; ir < matrix.GetLength(0); ir++)
            {
                for (int ic = 0; ic < matrix.GetLength(1); ic++)
                {
                    string current;

                    current = "";
                    //caso alto
                    for (int r = ir; r >= 0; r--)
                    {
                        try
                        {
                            current += matrix[r, ic];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }

                    }

                    current = "";
                    //caso alto-dx
                    for (int j = 0; j >= 0; j++)
                    {
                        try
                        {
                            current += matrix[ir - j, ic + j];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic + i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso dx
                    for (int c = ic; c < matrix.GetLength(1); c++)
                    {
                        try
                        {
                            current += matrix[ir, c];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir, ic+i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso-dx
                    for (int j = 0; j >= 0; j++)
                    {
                        try
                        {
                            current += matrix[ir + j, ic + j];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic + i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso
                    for (int r = ir; r < matrix.GetLength(0); r++)
                    {
                        try
                        {
                            current += matrix[r, ic];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso-sx
                    for (int j = 0; j >= 0; j++)
                    {
                        try
                        {
                            current += matrix[ir + j, ic - j];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir + i, ic - i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso sx
                    for (int c = ic; c >= 0; c--)
                    {
                        try
                        {
                            current += matrix[ir, c];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir, ic - i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso alto-sx
                    for (int j = 0; j >= 0; j++)
                    {
                        try
                        {
                            current += matrix[ir - j, ic - j];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                for (int i = current.Length - 1; i >= 0; i--) buttons[ir - i, ic - i].Background = Brushes.IndianRed;
                            }
                        }
                        catch { break; }
                    }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

            btnStart.IsEnabled = false;
            btnRisolvi.IsEnabled = true;
        }

        private void btnCarica_File_Click(object sender, RoutedEventArgs e)
        {
            const string FILEDEFAULT = "matrice.txt";
            string percorso = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = percorso;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.FileName = FILEDEFAULT;
            if(openFileDialog.ShowDialog() == true)
            {
                percorso = openFileDialog.FileName;
                LeggiFile(percorso);
                btnStart.IsEnabled = true;
            }
        }

        private void btnRisolvi_Click(object sender, RoutedEventArgs e)
        {
            btnRisolvi.IsEnabled = false;
            Console.WriteLine(btnStart.Background);
            Risolvi();
            btnRisolvi.IsEnabled = true;
        }
    }
}

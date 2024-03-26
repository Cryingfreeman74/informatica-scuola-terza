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
using System.Net.Http.Headers;
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
using System.Drawing;

using Path = System.IO.Path;
using System.Xaml;

namespace Risolvi_Cruciverba_Wpf
{
    public partial class MainWindow : Window
    {
        private char[,] matrix;                 //matrice dove viene salvato il crucipuzzle
        private HashSet<string> solutions;      //soluzioni fornite in input
        private Random rnd = new Random();      
        private SolidColorBrush defaultBrush;   //colore default del brush

        Button[,] buttons;                      //matrice di buttons necessaria per la grafica

        private double hue = 100;               //necessario per generare il colore delle caselle dall'hsv

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

        public static System.Drawing.Color ColorFromHSV(double hue, double saturation, double value) //ritorna il colore generato con l'hue attuale
        {
            //coversione hsv -> rgb
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            //ritorno colore in base al valore di hi
            if (hi == 0)
                return System.Drawing.Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return System.Drawing.Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return System.Drawing.Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return System.Drawing.Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return System.Drawing.Color.FromArgb(255, t, p, v);
            else
                return System.Drawing.Color.FromArgb(255, v, p, q);
        }

        private SolidColorBrush getRandomSolidColorBrush() //ritorna un SolidColorBrush random da applicare alle caselle
        {
            var color = ColorFromHSV(hue, 0.92, 0.92);                                                                                  //ottengo il colore dall'hsv con l'hue attuale
            SolidColorBrush result = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));      //cast SolidColorBrush
            hue = (hue + rnd.Next(30, 50)) % 360;                                                                                       //modifico il valore dell'hue

            return result;
        }

        private bool cerca(string to_find, SolidColorBrush brush, int ir, int ic, int v, int o)
        {
            //v = 1 -----> direzione alto
            //v = -1 ----> direzione basso
            //v = 0 -----> direzione neutrale
            //o = 1 -----> direzione destra
            //o = -1 ----> direzione sinistra
            //o = 0 -----> direzione neutrale

            string current = ""; //stringa costruita
            try
            {
                int times;       //numero di caratteri in current = numero di iterazioni
                for (times = 0; times < to_find.Length; times++)
                {
                    current += matrix[ir, ic];          //costruisco la stringa fintanto che il numero dei caratteri di questa sia minore del numero dei caratteri della stringa da trovare
                    if (current[times] != to_find[times]) return false; //se a parità di posizione il char è diverso -> parola non trovata
                    ir += v; ic += o;
                }

                if (to_find == current)                 //caso parola trovata
                {
                    //rimozione parola dalle soluzioni
                    lstParole.Items.Remove(current);
                    solutions.Remove(current);

                    //colorazione bottoni
                    for (; times > 0; times--)
                    {
                        ir -= v; ic -= o;
                        buttons[ir, ic].Background = brush;
                        
                    }
                        
                    return true;    //parola trovata
                }
                else return false;  //parola non trovata
            } catch { return false; } //out of bound = non trovata
            
        }

        private void Risolvi(string to_find)                        //colora le caselle in cui trova la stringa passata in argomento
        {
            SolidColorBrush brush = getRandomSolidColorBrush();     //ottengo il SolidColorBrushRandom
            
            List<(int riga, int colonna)> posizioni = new List<(int,int)>(); //ottimizzazione: lista contenente le coordinate di tutte le caselle con l'iniziale giusta

            if (to_find == null) return;

            //setup lista ottimizzazione
            for(int ir = 0; ir < matrix.GetLength(0); ir++)
                for(int ic = 0; ic <  matrix.GetLength(1); ic++)
                    if (matrix[ir, ic] == to_find[0])
                        posizioni.Add((ir, ic));

            //controllo in ogni direzione partendo dalle celle che hanno l'iniziale giusta
            foreach ((int riga, int colonna) posizione  in posizioni)
            {
                //ottengo riga e colonna di partenza
                int ir = posizione.riga;
                int ic = posizione.colonna;
                
                //cerco in ogni direzione
                if (cerca(to_find, brush, ir, ic, 1, 0)) break;
                if (cerca(to_find, brush, ir, ic, 1, 1)) break;
                if (cerca(to_find, brush, ir, ic, 0, 1)) break;
                if (cerca(to_find, brush, ir, ic, -1, 1)) break;
                if (cerca(to_find, brush, ir, ic, -1, 0)) break;
                if (cerca(to_find, brush, ir, ic, -1, -1)) break;
                if (cerca(to_find, brush, ir, ic, 0, -1)) break;
                if (cerca(to_find, brush, ir, ic, 1, -1)) break;

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LeggiFile(string percorso)
        {
            matrix = SetUpMatrix(percorso);                                 //inizializzazione matrice
            solutions = SetUpSolutions(matrix, percorso);                   //inizializzazione hashset soluzioni
            buttons = new Button[matrix.GetLength(0), matrix.GetLength(1)]; //matrice di bottoni per la GUI
        }

        private void btnCarica_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //scelta file
                const string FILEDEFAULT = "matrice.txt";                                                   //file default
                string percorso = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\");     //percorso di default

                //impostazione finestra windows di selezione file
                OpenFileDialog openFileDialog = new OpenFileDialog();                                       
                openFileDialog.InitialDirectory = percorso;             //percorso default
                openFileDialog.Filter = "Text files (*.txt)|*.txt";     //filtro tipologia file
                openFileDialog.FileName = FILEDEFAULT;                  //nome default del file
                if (openFileDialog.ShowDialog() == true)                //file scelto correttamente: caricamento in memoria di quest'ultimo
                {
                    percorso = openFileDialog.FileName;
                    LeggiFile(percorso);
                }
                else throw new Exception("File non scelto.");           //file non scelto

                //clear della matrice di bottoni e delle soluzioni per caricare + file in una sola run del programma
                lstParole.Items.Clear();
                gridMap.Children.Clear();

                //creazione matrice bottoni
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

                //salvo il colore default dei brush
                defaultBrush = (SolidColorBrush)buttons[0, 0].Background;
                
                //abilito tutti i bottoni
                lstParole.IsEnabled = true;
                btnRisolvi.IsEnabled = true;
                btnParolaNascosta.IsEnabled = true;
                btnRisolviTutto.IsEnabled = true;
                lstParole.IsEnabled = true;

                //riempio la lista delle soluzioni
                List<string> temp = solutions.ToList<string>();
                foreach (string solution in temp)
                    lstParole.Items.Add(solution);
            }
            catch //errore nell'importazione del file: messaggio a video e disabilito tutti i bottoni
            { 
                MessageBox.Show("Errore nell'importazione del file!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                lstParole.IsEnabled = false;
                btnRisolvi.IsEnabled = false;
                btnParolaNascosta.IsEnabled = false;
                btnRisolviTutto.IsEnabled = false;
            }
            
        }

        private void btnRisolvi_Click(object sender, RoutedEventArgs e) //prende il valore selezionato nella lista delle soluzioni e chiama risolvi con quello come argomento
        {
            if (lstParole.SelectedValue != null)
            {
                Risolvi(lstParole.SelectedValue?.ToString());
                btnRisolvi.IsEnabled = false;                           //btn disabilitato fino alla prossima scelta
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //al momento della scelta di una soluzione il btn pre risolvere si abilita
        {
            btnRisolvi.IsEnabled = true;
        }

        private void risolvi_tutto_Click(object sender, RoutedEventArgs e)
        {
            //creo un array temporaneo contenente le soluzioni
            string[] parole = new string[lstParole.Items.Count];
            lstParole.Items.CopyTo(parole, 0);

            //cerco con risolvi ogni elemento dell'array
            foreach(string item in parole)
            {
                Risolvi(item);
            }
        }

        private void btnParolaNascosta_Click(object sender, RoutedEventArgs e)
        {
            if(solutions.Count == 0) //posso trovare la parola nascosta solo dopo aver risolto tutto il crucipuzzle
            {
                string parolaNascosta = "";

                //la parola nascosta è data da tutti i content dei bottoni che hanno ancora il default brush color
                foreach(Button b in buttons)
                {
                    BrushConverter brushConverter = new BrushConverter();
                    if (b.Background == defaultBrush)
                        parolaNascosta += b.Content;
                }

                //parola nascosta a video
                MessageBox.Show($"Congratulations! La parola nascosta essere: {parolaNascosta}", "WOW!", MessageBoxButton.OK, MessageBoxImage.Information);
            } else MessageBox.Show("Non hai ancora risolto tutto il crucipuzzle!", "ehrm, actually...", MessageBoxButton.OK, MessageBoxImage.Error);    //crucipuzzle non ancora risolto
        }
    }
}
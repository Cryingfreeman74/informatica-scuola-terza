using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risolvi_Cruciverba
{
    internal class Program {

        static char[,] matrix; //campo di gioco
        
        static HashSet<string> solutions = new HashSet<string>(); //le soluzioni da trovare

        static HashSet<string> SetUpSolutions() //deve essere chiamata dopo SetUpMatrix
        {
            HashSet<string> tempSolutions = new HashSet<string>();
            using (StreamReader sr = new StreamReader(@"..\..\matrice.txt"))
            {
                //skip delle linee contenenti la matrice
                for(int i = 0; i <= matrix.GetLength(0); i++)
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
        static char[,] SetUpMatrix(){

            List<string> lista = new List<string>();
            using (StreamReader sr = new StreamReader(@"..\..\matrice.txt"))
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

            for(int ir = 0; ir < matrix.GetLength(0); ir++)
            {
                for (int ic = 0; ic < matrix.GetLength(1); ic++)
                {
                    matrix[ir, ic] = lista[ir][ic];
                }
            }
            return matrix;
        }

        static void FindSolutions()
        {
            for(int ir = 0; ir < matrix.GetLength(0); ir++)
            {
                for(int ic = 0; ic < matrix.GetLength(1); ic++)
                {
                    string current;

                    current = "";
                    //caso alto
                    for(int r = ir; r >= 0; r--)
                    {
                        try
                        {
                            current += matrix[r, ic];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }

                    }

                    current = "";
                    //caso alto-dx
                    for(int i = 0; i >= 0; i++)
                    {
                        try
                        {
                            current += matrix[ir - i, ic + i];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
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
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso-dx
                    for (int i = 0; i >= 0; i++)
                    {
                        try
                        {
                            current += matrix[ir + i, ic + i];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso
                    for (int r = ir; r < matrix.GetLength(1); r++)
                    {
                        try
                        {
                            current += matrix[r, ic];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso basso-sx
                    for (int i = 0; i >= 0; i++)
                    {
                        try
                        {
                            current += matrix[ir + i, ic - i];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
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
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }
                    }

                    current = "";
                    //caso alto-sx
                    for (int i = 0; i >= 0; i++)
                    {
                        try
                        {
                            current += matrix[ir - i, ic - i];
                            if (solutions.Contains(current))
                            {
                                solutions.Remove(current);
                                Console.WriteLine("Trovata " + current);
                            }
                        }
                        catch { break; }
                    }

                }
            }
        }

        static void PrintMatrix()
        {
            for(int ir = 0; ir < matrix.GetLength(0); ir++)
            {
                for(int ic = 0; ic < matrix.GetLength(1); ic++)
                {
                    Console.Write(matrix[ir, ic] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            matrix = SetUpMatrix();
            solutions = SetUpSolutions();
            PrintMatrix();
            FindSolutions();

            Console.ReadKey();

        }
    }
}

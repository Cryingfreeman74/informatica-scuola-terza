/* Marco Balducci 3H 23/01/2024
 * Gioco 2048 con matrice 4 x 4
*/

using System.ComponentModel.DataAnnotations;

namespace _2048
{
    internal class Program
    {
        static int[,] map = new int[4, 4];
        static Random rnd = new Random();

        static ConsoleColor[] colors = {ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Magenta, ConsoleColor.White};

        enum directions
        {
            up,
            down,
            right,
            left
        }

        static void move(directions direction)
        {
            if (direction == directions.up)
            {
                for (int i = 0; i < 4; i++)
                {
                    int free = 0, last = 0, lastSum = -1;

                    for (int j = 0; j < 4; j++)
                        if (map[j, i] != 0)
                        {
                            if (j != 0)
                            {
                                if (map[j, i] == map[last, i])
                                {
                                    if(last != lastSum)
                                    {
                                        map[last, i] *= 2;
                                        map[j, i] = 0;
                                        lastSum = last;
                                    } else
                                        if (free != j)
                                        {
                                            map[free, i] = map[j, i];
                                            map[j, i] = 0;
                                            last = free++;
                                        }
                                }
                                else
                                {
                                    if(free != j)
                                    {
                                        map[free, i] = map[j, i];
                                        map[j, i] = 0;
                                    }
                                    last = free++;
                                }
                            }
                            else free++;
                                
                        }
                }
            }
            else if (direction == directions.down)
            {
                for (int i = 0; i < 4; i++)
                {
                    int free = 3, last = 3, lastSum = -1;

                    for (int j = 3; j >= 0; j--)
                        if (map[j, i] != 0 )
                        {
                            if (j != 3)
                            {
                                if (map[j, i] == map[last, i])
                                {
                                    if(last != lastSum)
                                    {
                                        map[last, i] *= 2;
                                        map[j, i] = 0;
                                        lastSum = last;
                                    } else
                                        if (free != j)
                                        {
                                            map[free, i] = map[j, i];
                                            map[j, i] = 0;
                                            last = free--;
                                        }

                                }
                                else
                                {
                                    if(free != j)
                                    {
                                        map[free, i] = map[j, i];
                                        map[j, i] = 0;
                                    }
                                    last = free--;
                                }
                            }
                            else free--;
                                
                            
                        }
                }
            }
            else if (direction == directions.left)
            {
                for (int i = 0; i < 4; i++)
                {
                    int free = 0, last = 0, lastSum = -1;

                    for (int j = 0; j < 4; j++)
                        if (map[i, j] != 0)
                        {
                            if (j != 0)
                            {
                                if (map[i, j] == map[i, last])
                                {
                                    if(last != lastSum)
                                    {
                                        map[i, last] *= 2;
                                        map[i, j] = 0;
                                        lastSum = last;
                                    } else
                                        if (free != j)
                                        {
                                            map[i, free] = map[i, j];
                                            map[i, j] = 0;
                                            last = free++;
                                        }
                                        

                                }
                                else
                                {
                                    if (free != j)
                                    {
                                        map[i, free] = map[i, j];
                                        map[i, j] = 0;
                                    }
                                    last = free++;
                                }
                            }
                            else free++;
                                
                        }
                }
            }
            else if (direction == directions.right)
            {
                for (int i = 0; i < 4; i++)
                {
                    int free = 3, last = 3, lastSum = -1;

                    for (int j = 3; j >= 0; j--)
                        if (map[i, j] != 0)
                        {
                            if (j != 3)
                            {
                                if (map[i, j] == map[i, last])
                                {
                                    if (last != lastSum)
                                    {
                                        map[i, last] *= 2;
                                        map[i, j] = 0;
                                        lastSum = last;
                                    }
                                    else
                                        if (free != j)
                                    {
                                        map[i, free] = map[i, j];
                                        map[i, j] = 0;
                                        last = free--;
                                    }
                                }
                                else
                                {
                                    if (free != j)
                                    {
                                        map[i, free] = map[i, j];
                                        map[i, j] = 0;
                                    }
                                    last = free--;
                                }
                            }
                            else free--;
                        }
                }
            }
            else throw new Exception("Invalid direction.");
        }

        static void printMap(int linePos, int colPos)
        {
            Console.SetCursorPosition(colPos, linePos);
            Console.Write("╔══════╦══════╦══════╦══════╗");

            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("\n║");
                for(int j = 0; j < map.GetLength(0); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (map[i, j] != 0)
                        Console.BackgroundColor = colors[(int)Math.Log2(map[i, j])];
                    else Console.BackgroundColor = colors[0];
                    Console.Write($" {toBuffer(map[i, j])} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("║");
                        
                }
                if (i != map.GetLength(1) - 1)
                    Console.Write("\n╠══════╬══════╬══════╬══════╣");

            }

            Console.WriteLine("\n╚══════╩══════╩══════╩══════╝");
        }

        static void addNumber()
        {
            bool space_available = false;
            for(int i = 0; i < map.GetLength(0);i++)
                for(int j = 0; j< map.GetLength(1); j++)
                    if (map[i, j] == 0) { space_available = true; break; }
            if (space_available)
                while (true)
                {
                    int col = rnd.Next(0, 4);
                    int line = rnd.Next(0, 4);

                    if (map[line, col] == 0)
                    {
                        map[line, col] = 2;
                        break;
                    }
                }
            else if(checkGameOver()) throw new Exception("Game over.");
        }

        static bool checkWin()
        {
            for(int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    if (map[i, j] == 2048) return true;
            return false;
        }

        static bool checkGameOver()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    try
                    {
                        if (map[i - 1, j] == map[i, j]) return false;
                    } catch (Exception e) { }
                    try
                    {
                        if (map[i, j - 1] == map[i, j]) return false;
                    } catch (Exception e) { }
                    try
                    {
                        if ((map[i + 1, j]) == map[i, j]) return false;
                    } catch (Exception e) { }
                    try
                    {
                        if (map[i, j + 1] == map[i, j]) return false;
                    } catch (Exception e) { }
                }
            } 
            return true;
        }

        static string toBuffer(int num)
        {
            string numero = num.ToString();
            int length = numero.Length;

            if(length != 4)
                for(int i = 0; i < 4 - length; i++) 
                    if(i % 2 == 0)
                        numero = " " + numero;
                    else numero = numero + " ";

            return numero;
        }

        static directions getDirection()
        {
            while(true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        return directions.up;
                    case ConsoleKey.DownArrow:
                        return directions.down;
                    case ConsoleKey.LeftArrow:
                        return directions.left;
                    case ConsoleKey.RightArrow:
                        return directions.right;
                    default:
                        Console.WriteLine("Not a valid move, retry.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = colors[rnd.Next(0,colors.Length)];
            Console.WriteLine("  ______    ______   __    __   ______  \r\n /      \\  /      \\ |  \\  |  \\ /      \\ \r\n|  $$$$$$\\|  $$$$$$\\| $$  | $$|  $$$$$$\\\r\n \\$$__| $$| $$$\\| $$| $$__| $$| $$__/ $$\r\n /      $$| $$$$\\ $$| $$    $$ >$$    $$\r\n|  $$$$$$ | $$\\$$\\$$ \\$$$$$$$$|  $$$$$$ \r\n| $$_____ | $$_\\$$$$      | $$| $$__/ $$\r\n| $$     \\ \\$$  \\$$$      | $$ \\$$    $$\r\n \\$$$$$$$$  \\$$$$$$        \\$$  \\$$$$$$ \r\n                                        \r\n                                        \r\n                                        \n\n");
            Console.ForegroundColor = ConsoleColor.White;
            int linePos = Console.GetCursorPosition().Top;
            int colPos = Console.GetCursorPosition().Left;
            while(true)
            {
                try
                {
                    addNumber();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tGame Over!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                printMap(linePos, colPos);

                if (checkWin())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t You Won!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                directions direction = getDirection();

                move(direction);
                
            }
        }
    }
}
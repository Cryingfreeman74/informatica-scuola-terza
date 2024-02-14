namespace sudoku
{
    internal class Program
    {
        static int[,] board = {
            {0,5,0, 0,7,9, 0,0,0 },
            {0,0,0, 0,0,0, 5,0,0 },
            {0,9,2, 0,0,0, 0,6,0 },

            {0,8,0, 0,0,0, 4,0,7 },
            {0,2,0, 6,0,0, 0,1,0 },
            {0,7,0, 2,5,0, 0,8,0 },

            {0,0,0, 0,4,0, 0,0,0 },
            {0,0,8, 0,2,0, 0,0,0 },
            {7,3,0, 0,0,1, 0,0,0 },
        };

        static bool CheckValid(int ir, int ic, int n)
        {
            //verifica se n può andare in board[ir, ic] senza violare le regole

            //verifica riga
            for (int k = 0; k < 9; k++)
                if (board[ir, k] == n) //già presente?
                    return false;

            //verifica colonna
            for (int k = 0; k < 9; k++)
                if (board[k, ic] == n) //già presente?
                    return false;

            //verifica intorno
            //coordinate intorno
            int base_ir = ir / 3 * 3; //diventa 0, 3 oppure 6 perdendo il resto
            int base_ic = ic / 3 * 3;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (n == board[base_ir + r, base_ic + c])
                        return false;

            //superati tutti i controlli la mossa è valida
            return true;
        }


        static void Main(string[] args)
        {
            HashSet<int>[,] valids = new HashSet<int>[9,9];
            for(int ir = 0; ir < valids.GetLength(0); ir++)
            {
                for(int ic = 0; ic < valids.GetLength(1); ic++)
                {
                    if (board[ir, ic] != 0) //se la cella è già piena
                        continue; //salta al cella

                    valids[ir, ic] = new HashSet<int>(); //crea insieme vuoto dei numeri accettabili in querlla cella

                    for(int n = 1; n <= 9; n++)
                    {
                        if (CheckValid(ir, ic, n)) //se il numero può entrare nella cella
                        { 
                            valids[ir,ic].Add(n);
                        }
                    }
                }
            }
        }
    }
}
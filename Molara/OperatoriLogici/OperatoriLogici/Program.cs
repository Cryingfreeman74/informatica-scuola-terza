namespace OperatoriLogici
{
    internal class Program
    {

        const int OP_NOT = 1;
        const int OP_AND = 2;
        const int OP_OR = 3;
        const int OP_XOR = 4;

        static string OperatorName(int operatore)
        {
            switch (operatore)
            {
                case OP_NOT:
                    return "not";

                case OP_AND:
                    return "and";

                case OP_OR:
                    return "or";
                
                case OP_XOR:
                    return "xor";

                default:
                    return "???";
            }
        }

        static void PrintTable(int operatore)
        {

            Console.WriteLine("  A  |  B   |  A {0} B  ", OperatorName(operatore));
            Console.WriteLine("------------|-----------");
            
            for(int a = 0; a <= 1; ++a)
            {
                bool A = (a != 0);

                for (int b = 0; b <= 1; ++b)
                {
                    bool B = (b != 0);

                    bool ris = false;
                    bool ris2 = false;


                    switch (operatore)
                    {
                        case OP_AND:
                            ris = (A && B);
                            break;

                        case OP_OR:
                            ris = (A || B);
                            break;

                        case OP_XOR:
                            ris= (A != B);
                            break;

                        case OP_NOT:
                            ris = !A;
                            ris2 = !B;
                            break;
                    }


                    if (operatore == OP_NOT) Console.WriteLine("{0,5} {1,5} | {2,5} {3,5}", A, B, ris, ris2);
                    else Console.WriteLine("{0,5} {1,5} | {2,5}", A, B, ris);
                    
                }
            }

            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            PrintTable(OP_NOT);
            PrintTable(OP_AND);
            PrintTable(OP_OR);
            PrintTable(OP_XOR);
        }
    }
}
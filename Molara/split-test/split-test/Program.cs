namespace split_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valori = "10,|20,; 30,40, 50;60;; ; 70;80|90  100";
            char[] separators = { ',', ';', '|',  };
            string[] parti = valori.Split(separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (string s in parti)
            {
                Console.WriteLine(s);
            }
        }
    }
}
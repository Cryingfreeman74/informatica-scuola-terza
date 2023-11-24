namespace SubString
{
    internal class Program
    {
        static int searchFor(string mainString, string subString)
        {
            bool found = false;

            for (int i = 0; i < mainString.Length-subString.Length+1; i++) 
            {
                for (int j = 0; j<subString.Length; j++)
                {
                    if (mainString[i+j] == subString[j]) found = true;
                    else
                    {
                        found = false;
                        break;
                    }
                }

                if (found) return i;
            }
            return -1;
        }
    }
}
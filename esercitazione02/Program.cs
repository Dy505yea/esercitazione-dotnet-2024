class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine($"Fermami con N se ci riesci");
           while(true)
           {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if(keyInfo.Key==ConsoleKey.N)
                {
                    Console.WriteLine($"darn...");
                    break;
                }
           }
        }
    }
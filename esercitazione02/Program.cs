class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        Console.WriteLine("inizio di un programma\n");
        string te= "Dylann";
        while (true)
        {
            string input= Console.ReadLine();
            Console.Write("\n");
            if(input.StartsWith("cmd: "))
            {
                string comando=input.Substring(5);
                switch(comando.ToLower())
                {
                    case "info":
                        Console.WriteLine("Non ho informazioni ._ .");
                        break;
                    case "name":
                        Console.WriteLine($"Te chiami {te}, cervello de pesce rosso");
                        break;
                    case "exit":
                        Console.WriteLine("Addios");
                        return;
                    default:
                        Console.WriteLine("Ma che me scrivi?\nSenti, dato che te non sai na ceppa, ecco a te i comandi:\n\ninfo\nname\nexit\nreprovaci\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("E che vuoi che faccia se non mi dai un comando?!? (per la cronaca, ho solo 'cmd:')");
            }
            Console.WriteLine("*s'accende na siga*\n");
        }
    }
}
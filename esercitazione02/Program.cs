class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine($"Come ti chiami?");
           string? nome= Console.ReadLine();
           //se metti il metodo Convert.ToInt32(Console.ReadLine()), puoi convertire in int ciò che hai messo
           Console.WriteLine($"{nome}... premi da qualche parte per andartene");
           Console.ReadKey();
        }
           
    }
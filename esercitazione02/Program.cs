class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        Console.WriteLine("Trascina un file qui e premi Invio:");
        string filePath=Console.ReadLine().Trim('"'); //toglie le virgolette che possono apparire nel percorso

        try
        {
            string content=File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file:");
            Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            Console.WriteLine("C'è stato un problema: {ex. Message}");
        }
    }
}
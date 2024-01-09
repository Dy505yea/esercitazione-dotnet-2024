class Program
    {
        static void Main(string[] args)
        {
            //usually, c'è bisogno di una libreria a parte
            DateTime DataDiNascita = new DateTime(1980, 1, 1);
            Console.WriteLine($"Sei nato il {DataDiNascita}"); //$ è l'interpolazione di stringhe
        }
    }
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];
            nomi[0]="Mario";
            nomi[1]="Luigi";
            nomi[2]="Giovanni";
            Console.WriteLine($"Buonaseeeeera   {nomi[0]}, {nomi[1]}, {nomi[2]}"); //$ è l'interpolazione di stringhe
            Console.WriteLine($"Siete solo in {nomi.Length}?"); //il .Length accanto al nome dell'array, indica quanti elementi son contenuti
        }
    }
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];   //string è di per sé un array di stringhe, ma un array dinami
            //dal momento che si aggiunge [] subito accanto al tipo, rendendolo un array di array
            //ma, a differenza di string, questo array è predeterminato, quindi necessità di sapere quanto spazio deve essere creato
            nomi[0]="Mario";
            nomi[1]="Luigi";
            nomi[2]="Giovanni";
            Console.WriteLine($"Buonaseeeeera   {nomi[0]} {nomi[1]} {nomi[2]}!!!!!"); //$ è l'interpolazione di stringhe
        }
    }
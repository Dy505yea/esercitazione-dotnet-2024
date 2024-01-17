class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Ti farò un riordinamento di robe a caso:\n");
        //classe random per casualità
        Random ran= new Random();
        //lista di prova per questa dimostrazione
        List<int> prova= new List<int>();
        //mettiamo 10 elementi da riordinare
        for(int i=0; i<10; i++)
        {
            prova.Add(ran.Next(0, 11));
            //stampa di cosa è uscito
            Console.Write($"{prova[i]}, ");
        }
        //riordinamento
        Console.Write($"\n\nOra lo riordino:\n");
        //basta solo richiamare il metodo, dal minore al maggiore
        prova.Sort();
        Console.WriteLine($"{string.Join(", ", prova)}");
        Console.WriteLine($"\nHopefully, tutto è andato come voluto");
    }
}
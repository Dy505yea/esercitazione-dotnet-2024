class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Tempo di provare a fare na selezione:\n");
        //lista di nomi
        List<string> nomi= new List<string>{};
        //facciamo che non lo vogliano prefatto, ma decidere noi cosa mettere
        int i=0;
        while(i<=0)
        {
            Console.WriteLine($"Quanti ne vuoi mettere?");
            string secure=Console.ReadLine();
            if(int.TryParse(secure, out i))
            {
                i=Convert.ToInt32(secure);
                if(i>1)
                {
                    Console.WriteLine($"\nBene, ne abbiamo {i}\n");
                    break;
                }
                Console.WriteLine($"\nQualcuno qui ha un pò di astio\n");
                break;
            }
            Console.WriteLine("\nSo che è difficile, ma almeno un nome lo dobbiamo mettere in questa roulette\n");
        }
        for(int l=0; l<i; l++)
        {
            Console.Write($"Mettiamo il numero {l+1}: ");
            nomi.Add(Console.ReadLine());
            Console.Write($"\n");
        }
        //random
        Random ran=new Random();
        //selezione
        int scelto= ran.Next(0, nomi.Count);
        //debug
        Console.Write($"Ne ho {nomi.Count}, di cui ho scelto il numero {scelto+1}");
        if(i==1)
        {
            Console.Write($", sorprendentemente...");
        }
        //risultato
        Console.WriteLine($"\n\nLo sfortunato vincitore è {nomi[scelto]}");
    }
}
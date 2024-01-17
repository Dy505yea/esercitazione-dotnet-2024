class Program
{
    static void Main(string[] args)
    {
        //guess stavolta si guarderà ai random

        //prima ancora di usarlo, bisogna dichiarare una variabile random
        Random ran=new Random();
        int somma=0;
        Console.WriteLine($"Farò una somma di 10 numeri casuali\n");
        //per vedere lentamente che numeri escono
        Thread.Sleep(1000);
        //facciamo un ciclino da 10
        for(int i=0; i<10; i++)
        {
            //il metodo .Next prenderà un numero tra numero A come, minimo, e numero B-1, come massimo
            int x=ran.Next(1, 11);
            //quindi in questo caso tra 1 e 10 (non 11)
            Console.Write($"{i+1}° numero: ");
            //modifica colore del numero per evidenziarlo
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine($"{x}");
            //reset solo per non evidenziare il resto
            Console.ResetColor();
            //giusto per vedere cosa è uscito
            somma+=x;
            //per vedere lentamente che numeri escono
            Thread.Sleep(1000);
        }
        Console.Write($"\nLa somma è venuta ");
        //un altro colore per non confonderlo con la sequenza di numeri casuali
        Console.ForegroundColor=ConsoleColor.Magenta;
        Console.WriteLine($"{somma}");
        Console.ResetColor();
    }
}
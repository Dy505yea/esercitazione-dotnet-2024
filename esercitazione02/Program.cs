class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Console.WriteLine($"Quindi stavolta i numeri son {a} e {b}");
            switch(a)
            {
                case 10:
                    Console.WriteLine($"As the godfather intended");
                    break;
                case 20:
                    Console.WriteLine($"Temo di vedere cose");
                    break;
                case 30:
                    Console.WriteLine($"Ma non c'era manco questo numero prima");
                    break;
            }
            Console.WriteLine($"Un giorno ti insegnerò a immaginare numeri casuali invece dei soliti multipli di 10");
        }
    }
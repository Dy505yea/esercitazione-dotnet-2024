class Program
    {
        static void Main(string[] args)
        {
            int a=10;
            int b=20;
            decimal c= 1.5m;
            decimal d =a+b+c;
            Console.WriteLine($"Se fai {a} + {b} (due interi) + {c} (un decimale), il risultato è {d}"); //$ è l'interpolazione di stringhe
        }
    }
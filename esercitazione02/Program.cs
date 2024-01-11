class Program
    {
        static void Main(string[] args)
        {
            //Una pila è come mettere delle biglie in un tubo su misura: la prima che metti sarà l'ultima che toglierai
            Stack<string> nomi = new Stack<string>();
            nomi.Push("Mario");
            nomi.Push("Luigi");
            nomi.Push("Giovanni");
            //ed esattamente con questo concetto, l'unico modp per printare gli elementi è col seguente metodo
            Console.WriteLine($"Buonaseeeeera   {nomi.Pop()}, {nomi.Pop()}, {nomi.Pop()}");
            //L'ultimo elemento è il primo a venir fuori
        }
    }
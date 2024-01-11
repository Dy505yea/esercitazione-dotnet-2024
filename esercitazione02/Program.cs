class Program
    {
        static void Main(string[] args)
        {
            //inizializzazione di 2 tipi d'array
            string[] nomi= new string[] {"Mario", "Giovanni", "Salomone"};
            int[] numeri= new int[] {4, 12, 62, 24, 2};
            
            Console.WriteLine($"Buonasera {nomi[0]}, {nomi[1]}, {nomi[2]}\n");
            Console.WriteLine($"I vostri numeri: {numeri[0]}, {numeri[1]}, {numeri[2]}, {numeri[3]}, {numeri[4]}\n\n");

            //inizializzazione di 2 tipi di liste
            List<int> listaNumeri=new List<int> {8, 21, 444, 12, 90};
            List<string> listaNomi=new List<string> {"Osvaldo", "Enrico", "Tommaso"};
            
            Console.WriteLine($"Buonasera {listaNomi[0]}, {listaNomi[1]}, {listaNomi[2]}\n");
            Console.WriteLine($"I vostri numeri: {listaNumeri[0]}, {listaNumeri[1]}, {listaNumeri[2]}, {listaNumeri[3]}, {listaNumeri[4]}\n\n");

            //inizializzione di una pila
            Stack<int> pilaNumeri= new Stack<int> (new int[] {505, 31, 49, 98, 5});
            
            Console.WriteLine($"Ecco numeri i nascosti: {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}\n");

            //inizializzazione di una coda
            Queue<string> codaNomi= new Queue<string> (new string[] {"Dario", "Silvio", "Agata"});
            
            Console.WriteLine($"Sono a nome di {codaNomi.Dequeue()}, {codaNomi.Dequeue()}, {codaNomi.Dequeue()}\n\n");
        }
    }
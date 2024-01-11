class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];
            nomi[0]="Mario";
            nomi[1]="Luigi";
            nomi[2]="Giovanni";
            Console.WriteLine($"Buonaseeeeera   {nomi[0]} {nomi[1]} {nomi[2]}!!!!!"); //$ è l'interpolazione di stringhe
            //prova da qui
            //prima prova, contenitore di singola stringa
            //string cont= nomi[2];
            //prova con una stringa singola
            //char prova= cont;
            //seconda prova: usare l'array di stringhe come se fosse una matrice
            char prova= nomi[2][1]; //se si cerca un altro elemento di un array di stringhe, secondo teoria, dovrebbe uscire un carattere
            Console.WriteLine($"{nomi[2]}, la seconda lettera del tuo nome è {prova}, nevvero?");
            //fine prova
        }
    }
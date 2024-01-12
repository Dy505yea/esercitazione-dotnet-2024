class Program
    {
        static void Main(string[] args)
        {
            //array di nomi random
            string[] nomi= new string[] {"Mario", "Giuseppe", "Marco", "Felipe", "Mirco", "Estriper", "Mario", "Schettino", "Mario"};
            //lista che si occuperà di riempirsi di Mario
            List<string> laLista= new List<string>();
            //associazione di dove sta mario nell'array
            Dictionary<int, string> numeralo=new Dictionary<int, string>();
            //Mario è ricercato, perchè? Boh, avrà messo dell'ananas sulla pizza
            string wanted="Mario";
            //contatore, per sapere quante volte il ricercato è stato trovato
            int conta=0;
            //posizione nell'array
            int pos=0;
            Console.WriteLine($"Ricerca di {wanted} in corso");
            //ciclo foreach nell'array, letto è ciò che ritorna per orgni elemento
            foreach(string letto in nomi)
            {
                //se l'abbiamo stanato
                if(letto==wanted)
                {
                    //aumenta il contatore
                    conta++;
                    //aggiungiamo il nome
                    laLista.Add(letto);
                    //e lo mettiamo nel dizionario con il posto in cui sta
                    numeralo.Add(pos, letto);
                }
                //prossima linea
                pos++;
            }
            Console.WriteLine($"Trovato {wanted} {conta} volta/e");
            //ciclo per stampare un messaggio semplice semplice
            foreach(int chiave in numeralo.Keys)
            {
                //chiave è il corrente key che si sta leggendo in tutto il dizionario
                Console.WriteLine($"Nella linea {chiave}, è stato rilevato {numeralo[chiave]}");
                //numeralo[chiave] è il corrente value di suddetta key
            }
        }
    }
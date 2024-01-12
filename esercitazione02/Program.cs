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
            foreach(string letto in nomi)
            {
                if(letto==wanted)
                {
                    conta++;
                    laLista.Add(letto);
                    numeralo.Add(pos, letto);
                }
                pos++;
            }
            Console.WriteLine($"Trovato {wanted} {conta} volta/e");
            foreach(int chiave in numeralo.Keys)
            {
                Console.WriteLine($"Nella linea {chiave}, è stato rilevato {numeralo[chiave]}");
            }
        }
    }
class Program
{
    static void Main(string[] args)
    {
        /*
        metodo per inserire il primo numero                                     migliorie personali
        idem il secondo                                                         aggiungere na lista di risultati da cui tornare
        metodo per inserire operazione                                          forse una per le operazioni svolte (na cronologia insomma)
        */
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();
        Console.WriteLine("Calcolatrice MOOOLTO basilare\n");
        int primo=0;
        int secondo=0;
        Console.WriteLine("Inserisci il primo numero\n");
        while(true)
        {
            string? safe = Console.ReadLine();
            //controllo che si sia dato un effettivo valore numerico
            if (int.TryParse(safe, out primo))
            {
                //passo il primo numero
                primo = Convert.ToInt32(safe);
                break;
            }
            //sennò faccio ridare l'input
            else
            {
                Console.WriteLine("Necessito di un valore numerico, riprova\n");
            }
        }
        Console.WriteLine("\nInserisci il secondo numero\n");
        while(true)
        {
            string? safe = Console.ReadLine();
            //controllo che si sia dato un effettivo valore numerico
            if (int.TryParse(safe, out secondo))
            {
                //passo il secondo numero
                secondo = Convert.ToInt32(safe);
                break;
            }
            //sennò faccio ridare l'input
            else
            {
                Console.WriteLine("Necessito di un valore numerico, riprova\n");
            }
        }
        bool token=true;
        while(token)
        {
            //disattivo il token per evitare di riscrivere la sua attivazione per tutti i casi positivi
            token=false;
            Console.WriteLine("\nInserisci l'operando:\n'+' per l'addizione\n'-' per la sottrazione\n'*' per la moltiplicazione\n'/' per la divisione\n");
            string? operando=Console.ReadLine();
            switch(operando)
            {
                case "+":
                    int somma=primo + secondo;
                    Console.WriteLine($"\nRisultato dell'addizione è: {somma}");
                    break;
                case "-":
                    int differenza=primo - secondo;
                    Console.WriteLine($"\nRisultato della sottrazione è: {differenza}");
                    break;
                case "*":
                    int prodotto=primo * secondo;
                    Console.WriteLine($"\nRisultato della moltiplicazione è: {prodotto}");
                    break;
                case "/":
                    //here the funny thing: la divisione ha diverse cose da esser controllate rispetto alle altre operazioni
                    //primo, è impossibile fare una divisione per 0
                    if(secondo==0)
                    {
                        Console.WriteLine($"\nImpossibile dividere lo 0");
                        break;
                    }
                    int quoziente=primo/secondo;
                    //secondo, a differenza delle altre operazioni, la divisione ha alta probabilità di dare dei decimali
                    //ma dato che per ora evitiamo di andare fuori dagli interi, aggiungici un resto in tal caso
                    int resto=primo%secondo;
                    Console.WriteLine($"\nRisultato della divisione è: {quoziente}, con resto {resto}");
                    break;
                default:
                    Console.WriteLine($"\nOperando non disponibile, riscrivere");
                    //lo riattivo per far ripartire il ciclo
                    token=true;
                    break;
            }
        }
        Console.WriteLine("\nFine programma");
    }
}
# Calcolatrice

## Versione 01

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Calcolatrice\n");

        //inserimento dei numeri da operare
        int primo=0;
        int secondo=0;
        //il primo numero
        Console.WriteLine("Inserisci il primo numero\n");
        while(true)
        {
            //stringa per una verifica di sicurezza
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
        //il secondo numero
        Console.WriteLine("\nInserisci il secondo numero\n");
        while(true)
        {
            //stringa per una verifica di sicurezza
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

        //inserimento operando
        //token necessario per una procedura
        bool token = true;
        while (token)
        {
            //disattivo il token per evitare di riscrivere la sua attivazione per tutti i casi positivi
            token = false;
            //in caso l'operatore sia disponibile, il ciclo verrà chiuso
            Console.WriteLine("\nInserisci l'operando:\n'+' per l'addizione\n'-' per la sottrazione\n'*' per la moltiplicazione\n'/' per la divisione\n");
            string? operando = Console.ReadLine();
            //diverse operazioni per diversi tipi di operandi
            switch (operando)
            {
                 //Somma
                case "+":
                    int somma = primo + secondo;
                    Console.WriteLine($"\nRisultato dell'addizione è: {somma}");
                    break;
                //Differenza
                case "-":
                    int differenza = primo - secondo;
                    Console.WriteLine($"\nRisultato della sottrazione è: {differenza}");
                    break;
                //Prodotto
                    case "*":
                    int prodotto = primo * secondo;
                    Console.WriteLine($"\nRisultato della moltiplicazione è: {prodotto}");
                    break;
                //Quoziente con Resto
                case "/":
                    //here the funny thing: la divisione ha diverse cose da esser controllate rispetto alle altre operazioni
                    //primo, è impossibile fare una divisione per 0
                    if (secondo == 0)
                    {
                        Console.WriteLine($"\nImpossibile dividere per 0");
                        break;
                    }
                    int quoziente = primo / secondo;
                    //secondo, a differenza delle altre operazioni, la divisione ha alta probabilità di dare dei decimali
                    //ma dato che per ora evitiamo di andare fuori dagli interi, aggiungici un resto in tal caso
                    int resto = primo % secondo;
                    Console.WriteLine($"\nRisultato della divisione è: {quoziente}, con resto {resto}");
                       break;
                //Problema con la stringa digitata
                default:
                    Console.WriteLine($"\nOperando non disponibile, riscrivere");
                    //lo riattivo per far ripartire il ciclo
                    token = true;
                    break;
                }
            }
        Console.WriteLine("\nFine programma");
    }
}
```

## Versione 02 (aggiunta di ripetizione di tutta l'operazione)

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Calcolatrice terra terra\n");

        //Ciclo per far far fare più operazioni finchè si vuole
        while (true)
        {//dichiarazione dei due numeri da usare
            int primo = 0;
            int secondo = 0;


            //scrittura del primo numero
            Console.WriteLine("Inserisci il primo numero\n");
            while (true)
            {
                //stringa temporanea per la procedura di sicurezza
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
            //scrittura secondo numero
            Console.WriteLine("\nInserisci il secondo numero\n");
            while (true)
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
            

            //scrittura dell'operando
            //token necessario per una procedura
            bool token = true;
            while (token)
            {
                //disattivo il token per evitare di riscrivere la sua attivazione per tutti i casi positivi
                token = false;
                //in caso l'operatore sia disponibile, il ciclo verrà chiuso
                Console.WriteLine("\nInserisci l'operando:\n'+' per l'addizione\n'-' per la sottrazione\n'*' per la moltiplicazione\n'/' per la divisione\n");
                string? operando = Console.ReadLine();
                //diverse operazioni per diversi tipi di operandi
                switch (operando)
                {
                    //Somma
                    case "+":
                        int somma = primo + secondo;
                        Console.WriteLine($"\nRisultato dell'addizione è: {somma}");
                        break;
                    //Differenza
                    case "-":
                        int differenza = primo - secondo;
                        Console.WriteLine($"\nRisultato della sottrazione è: {differenza}");
                        break;
                    //Prodotto
                    case "*":
                        int prodotto = primo * secondo;
                        Console.WriteLine($"\nRisultato della moltiplicazione è: {prodotto}");
                        break;
                    //Quoziente con Resto
                    case "/":
                        //here the funny thing: la divisione ha diverse cose da esser controllate rispetto alle altre operazioni
                        //primo, è impossibile fare una divisione per 0
                        if (secondo == 0)
                        {
                            Console.WriteLine($"\nImpossibile dividere per 0");
                            break;
                        }
                        int quoziente = primo / secondo;
                        //secondo, a differenza delle altre operazioni, la divisione ha alta probabilità di dare dei decimali
                        //ma dato che per ora evitiamo di andare fuori dagli interi, aggiungici un resto in tal caso
                        int resto = primo % secondo;
                        Console.WriteLine($"\nRisultato della divisione è: {quoziente}, con resto {resto}");
                        break;
                    //Problema con la stringa digitata
                    default:
                        Console.WriteLine($"\nOperando non disponibile, riscrivere");
                        //lo riattivo per far ripartire il ciclo
                        token = true;
                        break;
                }
            }


            //Richiesta di ripetizione di tutte le operazioni eseguite
            Console.WriteLine("\nVoler continuare?\n(Premi s per si, n per no)");
            //ciclo per evitare di ripetere erroneamente dalla richiesta del primo numero
            while (true)
            {
                //per farla semplice, volevo solo far digitare una lettera
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                //s per far tornare dalla richiesta del primo numero
                if (keyInfo.Key == ConsoleKey.S)
                {
                    Console.WriteLine("\n");
                    break;
                }
                //n per finire il programma da qui
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine($"\n\nFine programma\n");
                    return;
                }
                //questione grafica: in caso di errore, preferisco non vedere nemmeno il carattere
                Console.Write("\r \r"); //ma se fosse necessario vedere, si può lasciare solo "\r"
            }
        }
    }
}
```

## Versione 03

### Tolto il resto per dare un risultato diverso per la divisione, tutti gli interi ora sono float per operazioni decimali, semplificazione di un blocco

```c#
class Program
{
    static void Main(string[] args)
    {
        /*
        metodo per inserire il primo numero                                     migliorie personali
        idem il secondo                                                         aggiungere na lista di risultati da cui tornare
        metodo per inserire operazione                                          forse una per le operazioni svolte (na cronologia insomma)
        */
        //i seguenti due metodi son stati messi solo per preferenza personale
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();


        Console.WriteLine("Calcolatrice terra terra\n");

        //Ciclo per far far fare più operazioni finchè si vuole
        while (true)
        {
            //dichiarazione dei due numeri da usare
            float primo = 0;
            float secondo = 0;
            string operando="";
            float result=0;


            //scrittura del primo numero
            Console.WriteLine("Inserisci il primo numero\n");
            while (true)
            {
                //stringa temporanea per la procedura di sicurezza
                string? safe = Console.ReadLine();
                //controllo che si sia dato un effettivo valore numerico
                if (float.TryParse(safe, out primo))
                {
                    //passo il primo numero
                    primo = float.Parse(safe);
                    break;
                }
                //sennò faccio ridare l'input
                else
                {
                    Console.WriteLine("Necessito di un valore numerico, riprova\n");
                }
            }
            //scrittura secondo numero
            Console.WriteLine("\nInserisci il secondo numero\n");
            while (true)
            {
                string? safe = Console.ReadLine();
                //controllo che si sia dato un effettivo valore numerico
                if (float.TryParse(safe, out secondo))
                {
                    //passo il secondo numero
                    secondo = float.Parse(safe);
                    break;
                }
                //sennò faccio ridare l'input
                else
                {
                    Console.WriteLine("Necessito di un valore numerico, riprova\n");
                }
            }
            

            //scrittura dell'operando
            //token necessario per una procedura
            bool token = true;
            //token per evitare di stampare cose strane
            bool errato=false;
            while (token)
            {
                //disattivo il token per evitare di riscrivere la sua attivazione per tutti i casi positivi
                token = false;
                //in caso l'operatore sia disponibile, il ciclo verrà chiuso
                Console.WriteLine("\nInserisci l'operando:\n'+' per l'addizione\n'-' per la sottrazione\n'*' per la moltiplicazione\n'/' per la divisione\n");
                operando = Console.ReadLine();
                //diverse operazioni per diversi tipi di operandi
                switch (operando)
                {
                    //Somma
                    case "+":
                        result = primo + secondo;
                        break;
                    //Differenza
                    case "-":
                        result = primo - secondo;
                        break;
                    //Prodotto
                    case "*":
                        result = primo * secondo;
                        break;
                    //Quoziente con decimali
                    case "/":
                        //evito di fare l'operazione col 0
                        if (secondo == 0)
                        {
                            Console.WriteLine($"\nImpossibile dividere per 0");
                            errato=true;
                            break;
                        }
                        result = (float)primo / (float)secondo;
                        //Console.WriteLine($"\nRisultato della divisione è: {result}");
                        break;
                    //Problema con la stringa digitata
                    default:
                        Console.WriteLine($"\nOperando non disponibile, riscrivere");
                        //lo riattivo per far ripartire il ciclo
                        token = true;
                        break;
                }
            }
            //stampa risultato, se non è accaduto niente di strano
            if(!errato)
                Console.WriteLine($"{primo} {operando} {secondo} fa {result}");


            //Richiesta di ripetizione di tutte le operazioni eseguite
            Console.WriteLine("\nVoler continuare?\n(Premi s per si, n per no)");
            //ciclo per evitare di ripetere erroneamente dalla richiesta del primo numero
            while (true)
            {
                //per farla semplice, volevo solo far digitare una lettera
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                //s per far tornare dalla richiesta del primo numero
                if (keyInfo.Key == ConsoleKey.S)
                {
                    Console.WriteLine("\n");
                    break;
                }
                //n per finire il programma da qui
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine($"\n\nFine programma\n");
                    return;
                }
                //questione grafica: in caso di errore, preferisco non vedere nemmeno il carattere
                Console.Write("\r \r"); //ma se fosse necessario vedere, si può lasciare solo "\r"
            }
        }
    }
}
```
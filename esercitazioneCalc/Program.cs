using System.Globalization; //such comando è per introdurre delle cose
//in questo caso specifico, è per evitare che la lingua di sistema cambi i decimali in altro

class Program
{
    static void Main(string[] args)
    {
        //per forzare il sistema a funzionare nella versione americana
        //in modo da evitare problemi nell'uso delle virgole e punti per i decimali
        CultureInfo.CurrentCulture=new CultureInfo("en-US");
        //i seguenti due metodi son stati messi solo per preferenza personale
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();


        Console.WriteLine("Calcolatrice terra terra\n");

        //Ciclo per far far fare più operazioni finchè si vuole
        while (true)
        {
            //dichiarazione dei due numeri da usare
            double primo = 0;
            double secondo = 0;
            string operando="";
            double result=0;


            //scrittura del primo numero
            Console.WriteLine("Inserisci il primo numero\n");
            while (true)
            {
                //stringa temporanea per la procedura di sicurezza
                string? safe = Console.ReadLine();
                //controllo che si sia dato un effettivo valore numerico
                if (double.TryParse(safe, out primo))
                {
                    //il rimpiazzo serve per far si che si usino i decimali anche se metti la virgola
                    safe=safe.Replace(",",".");
                    //passo il primo numero
                    primo = double.Parse(safe);
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
                if (double.TryParse(safe, out secondo))
                {
                    safe=safe.Replace(",",".");
                    //passo il secondo numero
                    secondo = double.Parse(safe);
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
                //in caso l'operatore sia disponibile, il ciclo verrà chiuso        '*' per la moltiplicazione\n'/' per la divisione\n
                Console.WriteLine("\nInserisci l'operando:\n'+' per l'addizione\n'-' per la sottrazione");
                Console.WriteLine("'*' per la moltiplicazione\n'/' per la divisione");
                Console.WriteLine("'v' per la radice quadrata del primo numero\n'^' per l'esponenziale");
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
                        result = (double)primo / (double)secondo;
                        //Console.WriteLine($"\nRisultato della divisione è: {result}");
                        break;
                    //quadrato
                    case "v":
                        result = (double)Math.Sqrt(primo);
                        break;
                    //elevazione
                    case "^":
                        result = (double)Math.Pow(primo,secondo);
                        break;
                    //Problema con la stringa digitata
                    default:
                        Console.WriteLine($"\nOperando non disponibile, riscrivere");
                        //lo riattivo per far ripartire il ciclo
                        token = true;
                        break;
                }
            }
            /*
            truncate
            tostring("#.##")
            round
            */
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
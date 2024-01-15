class Program
    {
        static void Main(string[] args)
        {
            //Preferneza personale, almeno ho controllo per l'inizio
            Console.WriteLine($"Aspetto che te mi faccia partire");
            Console.ReadKey();
            Console.WriteLine($"\nInizializzo na cosetta... aspe, voglio dormire");
            //Per liberarsi da sto ciclo, c'è bisogno di un break
            while(true)
            {
                Console.WriteLine($"\ns'hai bisogno di me, premi solo ed esclusivamente solo ctrl + n");
                //inizializzazione della variabile tasto
                ConsoleKeyInfo keyInfo=Console.ReadKey(true);
                //a differenza di normali variabili, per fare un controllo qui si necessità la metà dei caratteri per la condizione
                //credo il .Modifiers sia qualcosa come Ctrl, Alt e Maiusc, il consolmodifiers.control è Ctrl in specifico
                //Comunque, sta attento, ci son un pò di combinazioni che, se non eseguiti da un terminale esterno, non lasciano leggere al programma
                if((keyInfo.Modifiers & ConsoleModifiers.Control)!=0)
                {
                    Console.WriteLine($"control l'hai messo");
                    //Fa un controllo del tasto normale, in sto caso se hai premuto anche N
                    if(keyInfo.Key==ConsoleKey.N)
                    {
                         Console.WriteLine("\nalmeno sai leggere");
                         break;
                     }
                    else
                    {
                        Console.WriteLine($"\nSai dove sta la fricking N?!?");
                    }
                }
                //se non ti fidi, un pò di scazzata ci vuole
                else
                {
                     Console.WriteLine($"\nT'ho detto di non toccar altro");
                }
            }
        }
    }
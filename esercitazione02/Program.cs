using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        //Indovina, Osperà!
        /*
        6 dadi, 2 assist, 4 haunted
        2 numeri da giocatore
        turni predefiniti
        punteggio: modificato in base alle azioni scelte
        puntegio... azione da poi pensarci è il ritiro dei dadi assist
        file? se vuoi un top score or just una cronologia... but for now non lo considero una cosa urgente
        file?? salvataggio del turno corrente, in caso non hai molto tempo, ma vuoi continuare
        file??? token per ripresa, ask se vuole continuare, numero turno, punteggio dadi, punto totale
        messaggi? errori, taunting, indovinato, random e incitazione... ringraziamento
        richiesta? se file, chiedi prima il nome per educazione, screanzato
        richiesta?? voler fare un altra partita
        random? da 1 a 6 per dado, da x a y per messaggio (!random se usi file per messaggio)
        grafica? hard for me, ma se devo separerei di tot per dado haunted, dadi assist rivelati solo su richiesta
        */
        Console.Clear();


        //variabile utilizzata per la reazione da parte del computer
        int critica = 0;
        //utilizzato per il punteggio
        float punto = 0;
        //in caso mi venisse in mente di fare un qualcosa di più complicato
        float totPunto = 0;
        //nome del giocatore, per ora non avrà utilizzo finchè non arrivo al file
        string player = "Player";
        //dadi assist, ce ne saranno 2
        int[] dadAss = new int[2];
        //dadi haunted, ce ne saranno 4
        int[] dadHaunt = new int[4];
        //2 variabili che verranno usate per indovinare i numeri
        int guess = 1;    //base di un dado haunted
        int sumGuess = 2; //somma di 2... o uno base
        //turni di una partita
        int maxTurn = 5;
        //token per rivelare i dadi assist
        bool reveal = false;
        //token per terminare la partita
        bool end = false;
        //basic è il punteggio per indovinare uno base, sarà soggetto a ricalibrazioni in caso vedessi che è troppo o troppo poco
        float basic = 4;
        //sumBasic è il punteggio per indovinare una somma
        float sumBasic = (float)Math.Truncate(basic + (basic / 2));
        //assBas è il punteggio se indovina l'assist un numero base
        float assBas = (float)Math.Ceiling(basic - basic / 4);
        //asSum è il punteggio se l'assist indovina una somma
        float asSum = (float)Math.Ceiling(sumBasic - sumBasic / 4);
        //usato meramente per debug
        int meTime = 500;


        Console.Write("Buongiorno o Buonasera, miei cari telenovelaspettatori, oggi si dà inizio ad un altra partita diiiii\n\t\t");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Thread.Sleep(700);
        Console.WriteLine("INDOVINA, OSPERÀ!\n");
        Console.ResetColor();
        Thread.Sleep(1200);
        Console.WriteLine("...Ok, dopo questa entrata, ora andiamo effetivamente al gioco");
        Thread.Sleep(700);
        while (!end)
        {


            //Regolamento, una lunga serie di print
            Console.WriteLine("\nLe regole:\n- Puoi provare ad indovinare 2 numeri, un numero base di 1 dado ed una somma di 2 dadi");
            Thread.Sleep(meTime);
            Console.Write($"- Indovina il numero base di un dado ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Haunted");
            Console.ResetColor();
            Console.WriteLine($", ottieni {basic} punti, indovina una somma di 2 e ne otterrai {sumBasic}, indovina ambo e ne otterrai {basic * 3}");
            Thread.Sleep(meTime);
            Console.WriteLine("- Volendo, puoi invece provare ad indovinare un altro numero base, ma in quel caso non otterrai più punti");
            Thread.Sleep(meTime);
            Console.Write($"- Hai a disposizione 2 dadi ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Assist");
            Console.ResetColor();
            Console.Write(" che possono aiutarti, ma il loro punteggio è ridotto,");
            Console.WriteLine($" rispettivamente dando {assBas} e {asSum}");
            Thread.Sleep(meTime);
            Console.Write($"- Li puoi rivelare anche se hai indovinato, ma far ciò ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"dimezzerà");
            Console.ResetColor();
            Console.Write($" i punti ottenuti prima di rivelare l'");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"assist");
            Console.ResetColor();
            Thread.Sleep(meTime);
            Console.Write($"- Se per caso nei dadi ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Haunted");
            Console.ResetColor();
            Console.Write($" son presenti dei doppi, indovinando la somma di essi si otterrà {sumBasic + (float)Math.Truncate(sumBasic / 2)}");
            Console.WriteLine($", se si indovina il punto base, allora invece si otterrà {(float)Math.Truncate((basic * 2) + (basic / 2))}");
            Thread.Sleep(meTime);
            Console.Write($"- La stessa regola si applica agli ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Assist");
            Console.ResetColor();
            Console.Write($": rispettivamente {asSum + (float)Math.Truncate(asSum / 2)} per la somma e");
            Console.WriteLine($" {(float)Math.Truncate((assBas * 2) + (assBas / 2))} per il base");
            Thread.Sleep(meTime);
            Console.WriteLine("\nDetto ciò, iniziamo il gioco\n");


            //for now, questo è presente per terminare subito il programma, finché non aggiungerò il check per far scegliere al giocatore se finirla
            end = true;
            //inizio del gioco
            for (int i = 0; i < maxTurn; i++)
            {
                //variabile necessaria per una scelta
                int choice = 0;
                //inizializzazone della variabile volatile del punteggio
                punto = 0;
                //inizializzazione random all'inizio della manche per rendere più casuale possibile
                Random ran = new Random();
                Console.WriteLine($"{i + 1}° turno\n\nInserisci il numero base");
            SelezioneBase:
                //tentativo per indovinare un numero base da parte del giocatore
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    //ritorno alla lettura da tastiera se il numero non è entro le facce del dado
                    if (guess < 1 || guess > 6)
                    {
                        Console.WriteLine("Non stiamo giocando a qualcosa come DnD, le facce son solo 6 e richiedo un numero da 1 a 6");
                        goto SelezioneBase;
                    }
                }
                catch
                {
                    //per ovviare al possibile errore se il giocatore scrive un altra cosa invece di un numero
                    Console.WriteLine("Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 6");
                    goto SelezioneBase;
                }
                Console.WriteLine("Inserisci la somma... o un altro numero base");
            SelezioneSomma:
                //tentativo per indovinare una somma da parte del giocatore
                try
                {
                    //procedimento simile alla selezione del numero base
                    sumGuess = Convert.ToInt32(Console.ReadLine());
                    if (sumGuess < 1 || sumGuess > 12)
                    {
                        Console.WriteLine("Richiedo o la somma di 2 dadi o un altro numero base, dimmene un altra");
                        goto SelezioneSomma;
                    }
                    //ma c'è un ulteriore controllo che il giocatore non abbia scelto lo stesso numero
                    if (guess == sumGuess)
                    {
                        Console.WriteLine("Deve essere diverso dalla tua prima scelta");
                        goto SelezioneSomma;
                    }
                }
                catch
                {
                    Console.WriteLine("Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 12");
                    goto SelezioneSomma;
                }


                //si tirano sia i dadi assist che i dadi haunted
                for (int l = 0; l < dadAss.Length; l++)
                {
                    dadAss[l] = ran.Next(1, 7);
                }
                for (int l = 0; l < dadHaunt.Length; l++)
                {
                    dadHaunt[l] = ran.Next(1, 7);
                }
                //ma solo i dadi haunted vengono rivelati
                Console.WriteLine($"Ecco a te i dadi haunted\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\t{dadHaunt[0]}\t{dadHaunt[1]}\t{dadHaunt[2]}\t{dadHaunt[3]}\n");
                Console.ResetColor();


                //token necessari per i punti e per diversi controlli
                bool gotOne = false;
                bool gotSome = false;
                bool gotDoubleOne = false;
                bool gotDoubleSome = false;
                //li si controlla uno ad uno
                for (int l = 0; l < dadHaunt.Length; l++)
                {
                    //e per controllare le somme, si fa un altro ciclo
                    for (int j = 0; j < dadHaunt.Length; j++)
                    {
                        //se la somma di 2 diversi dadi haunted è uguale al secondo numero deciso dal giocatore
                        if (l != j && dadHaunt[l] + dadHaunt[j] == sumGuess)
                        {
                            //lo si contrassegna
                            gotSome = true;
                            if (dadHaunt[l] == dadHaunt[j])
                                gotDoubleSome = true;
                        }
                    }
                }
                //il motivo per farlo in un ciclo a parte, è per evitare che dei controlli non riuscisserò a rilevare
                //in tempo tutte le somme prima del controllo in singolo
                for (int l = 0; l < dadHaunt.Length; l++)
                {
                    //si fa un controllo per il numero base, che vale per ambo i numeri
                    //ma il secondo numero deciso dal giocatore lo si controlla se non è stata rilevata una somma
                    if (dadHaunt[l] == guess || (dadHaunt[l] == sumGuess && gotSome != true))
                    {
                        gotOne = true;
                        //ci sarà un controllo per vedere se quello azzeccato ha un doppione
                        for (int j = 0; j < dadHaunt.Length; j++)
                        {
                            if (l != j && dadHaunt[l] == dadHaunt[j])
                            {
                                gotDoubleOne = true;
                            }
                        }
                    }
                }
                //giro di chek per il punteggio: pensavo di iniziare dal basso per andare in alto, if successivi insomma
                //controllo se almeno ha indovinato un numero base
                if (gotOne)
                {
                    //il punteggio verrà applicato
                    punto = basic;
                    critica = 1;
                    //ma cambierà se il numero indovinato ha un doppione
                    if (gotDoubleOne)
                    {
                        punto = (float)Math.Truncate((basic * 2) + (basic / 2));
                        critica = 3;
                    }
                }
                //simile al controllo precedente, ma con la somma
                if (gotSome)
                {
                    //il punto verrà applicato
                    punto = sumBasic;
                    critica = 2;
                    //se ha beccato a parte un numero base
                    if (gotOne)
                    {
                        //il punteggio applicato sarà quello speciale
                        punto = basic * 3;
                        critica = 5;
                        //e verrà ulteriormente aumentato se ha beccato i doppioni, una cosa moolto rara
                        if (gotDoubleSome && gotDoubleOne)
                        {
                            punto = basic * 4;
                            critica = 6;
                        }
                    }
                    //altrimenti, si procede con la stessa procedura del numero base
                    else
                    //ciò è fatto in modo da dar priorità al punteggio massimo
                    if (gotDoubleSome)
                    {
                        punto = sumBasic + (float)Math.Truncate(sumBasic / 2);
                        critica = 4;
                    }
                }
                //reazioni in base a quanto ha azzeccato il giocatore
                switch (critica)
                {
                    case 6:
                        Console.WriteLine($"HOLY MOLY, HAI BECCATO SIA IL BASE CHE LA SOMMA COME DOPPIONI!!!\n");
                        break;
                    case 5:
                        Console.WriteLine($"Sheesh, hai beccato sia somma che base\n");
                        break;
                    case 4:
                        Console.WriteLine($"Would ya look at that, hai pigliato 2 somme uguali\n");
                        break;
                    case 3:
                        Console.WriteLine($"Ed ecco a voi 2 single mooooolto simili\n");
                        break;
                    case 2:
                        Console.WriteLine($"Somma centrata\n");
                        break;
                    case 1:
                        Console.WriteLine($"Hai indovinato\n");
                        break;
                }


                //in caso il giocatore avesse indovinato, li si chiede se vuole rischiare anche solo per vedere cosa aveva l'assistente
                if (punto > 0)
                {
                    //si avvisa di quanti punti ha e del rischio in caso si volesse vedere che cosa hanno i dadi assistenti
                    Console.WriteLine($"Congrats, puoi portarti a casa {punto} punti... oppure vuoi provare a vedere cosa tira fuori l'assistente al costo della metà dei tuoi punti?");
                    Console.WriteLine($"(1 per rivelare l'assistente, 2 per tenerti i punti)");
                    choice = 0;
                DecisioneRischio:
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice < 1 || choice > 2)
                        {
                            Console.WriteLine("Unfortunately, non ho altre opzioni");
                            goto DecisioneRischio;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("(Ti ho richiesto 1 o 2)");
                        goto DecisioneRischio;
                    }
                    //se accetta il rischio, si dimezza di già il punteggio, il target è solo cò che ha indovinato il giocatore, non i dadi
                    if (choice == 1)
                    {
                        punto = (float)Math.Round(punto / 2);
                        Console.WriteLine($"Ora i tuoi punti stanno a {punto}, vediamo se ne sarà valsa la pena\n");
                    }
                }
                //invece se il giocatore non ha preso niente...
                else
                {
                    //si dà il messsaggio per avvisarlo e chiedere se vuole vedere se magari l'assistente li da un qualche punto
                    Console.WriteLine($"Uf, pare che la fortuna non sia dalla tua parte, puoi sempre sperare nell'assistente, se vuoi");
                    Console.WriteLine($"(1 per rivelare l'assistente, 2 per gettare la spugna)");
                    choice = 0;
                VuoiContinuare:
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice < 1 || choice > 2)
                        {
                            Console.WriteLine("Unfortunately, non ho altre opzioni");
                            goto VuoiContinuare;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("(Ti ho richiesto 1 o 2)");
                        goto VuoiContinuare;
                    }
                    //ma se per qualche strana ragione il giocatore non abbia voglia, si esprime la sorpresa di questa strana decisione
                    if (choice == 2)
                    {
                        Console.WriteLine("Honestly... non mi aspettavo qualcuno avrebbe rinunciato a prendere dei punti gratis");
                    }
                }



                //ora, questa è l'operazione per i dadi assist, che avranno un simile procedimento a prima... probabilmente in futuro creerò un metodo
                if (choice == 1)
                {
                    Console.WriteLine($"Ecco cosa l'assistente ha scelto per te:\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\t{dadAss[0]}\t{dadAss[1]}\n");
                    Console.ResetColor();
                    //token necessari per i punti e per diversi controlli
                    gotOne = false;
                    gotSome = false;
                    gotDoubleOne = false;
                    gotDoubleSome = false;
                    critica = 0;
                    //a differenza di prima, i dadi assist hanno il vantaggio di aver ben 2 numeri base invece che uno, insieme alla somma
                    for (int l = 0; l < dadHaunt.Length; l++)
                    {
                        int somma=0;
                        //per evitare di rivedere dadi precedenti, inizio dallo stesso dado
                        for (int j = l; j < dadHaunt.Length; j++)
                        {
                            //se la somma di 2 diversi dadi haunted è uguale alla somma dettata da Osperà
                            if (l != j && dadHaunt[l] + dadHaunt[j] == dadAss[0] + dadAss[1])
                            {
                                //controllo se ci son 2 somme uguali tramite il check
                                /*
                                ti toccherà rivedere lo sesso scenario per il giocatore
                                */
                                if (gotSome==true)
                                    gotDoubleSome = true;
                                //lo si contrassegna
                                gotSome = true;
                                somma=dadHaunt[l]+dadHaunt[j];
                            }
                        }
                    }
                    for (int k = 0; k < dadAss.Length; k++)
                    {
                        //il motivo per farlo in un ciclo a parte, è per evitare che dei controlli non riuscisserò a rilevare
                        //in tempo tutte le somme prima del controllo in singolo
                        for (int l = 0; l < dadHaunt.Length; l++)
                        {
                            if (dadHaunt[l] == dadAss[k])
                            {
                                gotOne = true;
                                //ci sarà un controllo per vedere se quello azzeccato ha un doppione
                                for (int j = 0; j < dadHaunt.Length; j++)
                                {
                                    if (l != j && dadHaunt[l] == dadHaunt[j])
                                    {
                                        gotDoubleOne = true;
                                    }
                                }
                            }
                        }
                    }



                    if (gotOne)
                    {
                        //il punteggio verrà applicato
                        punto = assBas;
                        critica = 1;
                        //ma cambierà se il numero indovinato ha un doppione
                        if (gotDoubleOne)
                        {
                            punto = (float)Math.Truncate((assBas * 2) + (assBas / 2));
                            critica = 3;
                        }
                    }
                    //simile al controllo precedente, ma con la somma
                    if (gotSome)
                    {
                        //il punto verrà applicato
                        punto = asSum;
                        critica = 2;
                        //se ha beccato a parte un numero base
                        if (gotOne)
                        {
                            //il punteggio applicato sarà quello speciale
                            punto = assBas * 3;
                            critica = 5;
                            //e verrà ulteriormente aumentato se ha beccato i doppioni, una cosa moolto rara
                            if (gotDoubleSome && gotDoubleOne)
                            {
                                punto = assBas * 4;
                                critica = 6;
                            }
                        }
                        //altrimenti, si procede con la stessa procedura del numero base
                        else
                        //ciò è fatto in modo da dar priorità al punteggio massimo
                        if (gotDoubleSome)
                        {
                            punto = asSum + (float)Math.Truncate(asSum / 2);
                            critica = 4;
                        }
                    }
                    //reazioni in base a quanto ha azzeccato il giocatore
                    switch (critica)
                    {
                        case 6:
                            Console.WriteLine($"HOLYMARYMOTHEROFJOSEPH, OSPERÀ HA TROVATO AMBO I DOPPIONI\n");
                            break;
                        case 5:
                            Console.WriteLine($"Wow, Osperà ha indovinato sia base che la somma\n");
                            break;
                        case 4:
                            Console.WriteLine($"Osperàsmus ha previsto la doppia somma\n");
                            break;
                        case 3:
                            Console.WriteLine($"Osperà è il nuovo cupido, ha trovato 2 single doppioni\n");
                            break;
                        case 2:
                            Console.WriteLine($"Osperà ha preso la somma\n");
                            break;
                        case 1:
                            Console.WriteLine($"Osperà ha pigliato un numero\n");
                            break;
                    }

                    
                }
            }
        }
    }
}
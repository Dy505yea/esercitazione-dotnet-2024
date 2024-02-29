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
        punteggio... azione da poi pensarci è il ritiro dei dadi assist

        punteggio- fare na media di punti minimi per turno
        punteggio! ricalibrare quanto si guadagna, è più facile beccare qualcosa che non
        punteggio!! magari osperà ne guadagna ancora di meno, solo metà

        file? se vuoi un top score or just una cronologia... but for now non lo considero una cosa urgente
        file?? salvataggio del turno corrente, in caso non hai molto tempo, ma vuoi continuare
        file??? token per ripresa, ask se vuole continuare, numero turno, punteggio dadi, punto totale
        file!! nome per sapere chi era, turno per sapere dove era rimasto, punto per sapere i punti, bool per sapere se era finita

        messaggi? errori, taunting, indovinato, random e incitazione... ringraziamento

        richiesta? se file, chiedi prima il nome per educazione, screanzato
        richiesta?? voler fare un altra partita

        random? da 1 a 6 per dado, da x a y per messaggio (!random se usi file per messaggio)

        sottra punteggio? usare un numero costante come prezzo
        sottra punteggio?? non si può se poi si va in debito
        sottra punteggio??? Solo se il giocatore se lo può permettere

        grafica? hard for me, ma se devo separerei di tot per dado haunted, dadi assist rivelati solo su richiesta


        unneeded thing... csv per i testi: adding a number to each sentence
        unneeded thing.. number equals a color, switch case to decide... tho you'll need a function now... ya can't just use the block if you want it polished
        unneeded thing. another variable to know what are ya talking 'bout in file.... i need json for this......
        unneeded thing different files... each one does a specific thing... additional variable to know if one is the same
        unneeded... thing... maybe even a variable to know you need a \n at the end
        thing... unneeded... format=Text, color, how many \n, alternative

        thing.. UNNEEEDEEEED add a way to add variables into the text, like for example: if csv starts with "x", substitute with y[i]
        THING...unneeedeeeeeeeeed.... use a sentence that has no sense to do that.... try with "vialen"
        */
        Console.Clear();


        //variabile utilizzata per la reazione da parte del computer
        int critica = 0;
        //utilizzato per calcolo punti
        float punto = 0;
        //utilizzato per il punteggio finale
        float totPunto = 0;
        //nome del giocatore, per ora non avrà utilizzo finchè non arrivo al file
        string defaultName = "Player";
        string player = defaultName;
        //dadi Osperà (avendo un pò un ruolo da aiutante, lo considero principalmente come assistente), ce ne saranno 2
        int[] dadAss = new int[2];
        //i dadispera, ce ne saranno 4
        int[] dadisp = new int[4];
        //2 variabili che verranno usate per indovinare i numeri
        int guess = 1;    //base di un dadospera
        int sumGuess = 2; //somma di 2 dadispera... o uno base
        //turni di una partita
        int maxTurn = 5;
        //token per rivelare i dadi assist
        int reveal = 0;
        //token per terminare la partita
        bool end = false;
        //token per sapere se il giocatore vuole risentire la spiegazione
        bool rule = false;
        //basic è il punteggio per indovinare uno base, sarà soggetto a ricalibrazioni in caso vedessi che è troppo o troppo poco
        float basic = 4;
        //sumBasic è il punteggio per indovinare una somma
        float sumBasic = (float)Math.Truncate(basic + (basic / 2));
        //assBas è il punteggio se indovina l'assist un numero base
        float assBas = (float)Math.Ceiling(basic - basic / 4);
        //asSum è il punteggio se l'assist indovina una somma
        float asSum = (float)Math.Ceiling(sumBasic - sumBasic / 4);
        //punteggio minimo per effettivamente vincere
        float vinPunt = sumBasic * maxTurn;
        //costo in punti per far tirare nuovamente ad Osperà, metà dei punti per base
        float pricePunt = (float)Math.Round(basic / 2);

        //array di float usato per stampare insieme al file csv
        float[] stampaNumero = new float[1];
        //usato meramente per debug
        int meTime = 500;


        //prova di apertura di un file... altrimenti se ne crea uno nuovo
        //path del file di salvataggio
        string pathSave = @"salvataggio\saveOspera.txt";
        if (!File.Exists(pathSave))
        {
            File.Create(pathSave).Close();
            string[] defaultStuff = { "Nome", player, "Turno", "0", "Punteggio Totale", "0", "WIP?", "False" };
            for (int i = 0; i < 8; i++)
            {
                File.AppendAllText(pathSave, defaultStuff[i] + "\n");
            }
        }
        string[] datiSave = File.ReadAllLines(pathSave);
        bool resume = false;
        try
        {
            resume = Convert.ToBoolean(datiSave[7]);
        }
        catch
        {
            Console.WriteLine("Mistakes were made my friend, devo risistemare una cosa, per ora mi finisco");
            return;
        }
        if (resume)
        {
            Console.Write($"Vedo che la partita era crashata per qualche motivo...\nPartita del giocatore ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{datiSave[1]}");
            Console.ResetColor();
            Console.Write(", Turno ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{datiSave[3]}");
            Console.ResetColor();
            Console.Write(", Punteggio ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{datiSave[5]}");
            Console.ResetColor();
            Console.WriteLine("\nVuoi riprendere da qui?");
            Console.WriteLine("(Premi S per si, N per no)");
            while (true)
            {
                ConsoleKeyInfo risposta = Console.ReadKey(true);
                if (risposta.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"\nAight...");
                    break;
                }
                else if (risposta.Key == ConsoleKey.N)
                {
                    Console.WriteLine($"\nMay you find your books in this place");
                    resume = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Avrei bisogno di sapere se Si o No...");
                }
            }
            Thread.Sleep(1500);
            Console.Clear();
        }

        string pathText = @"..\esercitazione02\csvsenteces\prova.csv";
        bool allGood = true;
        /*
        //mero debug, per provare se funziona con un file csv di prova
        allGood=StampaTestoCsv(pathText, 0);
        if(!allGood)
        {
            return;
        }
        
        
        Thread.Sleep(2000);
*/



        //questo token serve per evitare di dare i messaggi di introduzione se si sta riprendendo una partita ancora non finita
        if (!resume)
        {
            Console.Write("Buongiorno o Buonasera, miei cari telenovelaspettatori, oggi si dà inizio ad un altra partita diiiii\n\n\t\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(700);
            Console.WriteLine("INDOVINA, OSPERÀ!\n");
            Console.ResetColor();
            Thread.Sleep(1200);
            Console.WriteLine("...Ok, dopo questa entrata, ora andiamo effetivamente al gioco");
            Thread.Sleep(900);
            Console.WriteLine("\nMi diresti il tuo nome prima di iniziare?");
            player = Console.ReadLine()!;
            if (player.Trim().Length <= 0)
            {
                Console.WriteLine($"Allora ti chiamerò {defaultName}, dato che ti piace fare il misterioso");
                player = defaultName;
            }
            else
            {
                Console.WriteLine($"Bene, {player}, piacere di conoscerti");
            }
            Thread.Sleep(900);
        }
        while (!end)
        {
            datiSave[1] = player;
            //sarà sempre falso dal secondo ciclo in poi, in modo da evitare la domanda all'inizio
            if (!rule)
            {
                Console.WriteLine("Vuoi sentire le regole?\n(S per si, N per no)");
                rule = Accettare("Fammi rileggere...", "Ok", "Avrei bisogno di sapere se Si o No...", false);
                Thread.Sleep(meTime * 2);
                Console.Clear();
            }
            //ho messo un blocco a parte per via della grandezza per la stampa del regolamento, tutto per questione di grafica
            //il check del token è per prevenire di riscrivere il regolamento di nuovo in una partita
            if (rule)
            {
                pathText = @"..\esercitazione02\csvsenteces\regoleOspera.csv";
                //Regolamento, una lunga serie di print
                float[] valori = { basic, sumBasic, basic * 3, assBas, asSum,
                                    sumBasic + (float)Math.Truncate(sumBasic / 2), (float)Math.Truncate((basic * 2) + (basic / 2)),
                                    asSum + (float)Math.Truncate(asSum / 2), (float)Math.Truncate((assBas * 2) + (assBas / 2)) };
                Array.Resize(ref stampaNumero, valori.Length);
                Array.Copy(valori, stampaNumero, valori.Length);
                allGood = StampaTestoCsv(pathText, 0, stampaNumero);
                if (!allGood)
                {
                    return;
                }
                Thread.Sleep(meTime);
                Console.WriteLine("\nDetto ciò, iniziamo il gioco\n");
                rule = false;
            }


            //questo è necessario solo per debug
            //end = true;

            
            int predefined = 0;
            if (resume)
            {
                predefined = Convert.ToInt32(datiSave[3]);
                totPunto = Convert.ToInt32(datiSave[5]);
            }

            //inizio del gioco
            for (int i = predefined; i < maxTurn; i++)
            {
                //inizializzazone della variabile volatile del punteggio
                punto = 0;

                //Scrittura dei dati in una variabile, per poi salvarli verso la fine del turno...
                //cambio piano, lo faccio salvare subito
                datiSave[3] = i.ToString();
                datiSave[5] = totPunto.ToString();
                datiSave[7] = true.ToString();
                File.WriteAllLines(pathSave, datiSave);

                //inizializzazione random all'inizio della manche per rendere più casuale possibile
                Random ran = new Random();
                Thread.Sleep(meTime);
                Console.WriteLine($"{i + 1}° turno\n\nInserisci il numero base");


                guess = ReplyIntRange("Non stiamo giocando a qualcosa come DnD, le facce son solo 6 e richiedo un numero da 1 a 6",
                                    "Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 6", 1, 6);
                Console.WriteLine("Inserisci la somma... o un altro numero base");


                sumGuess = ReplyIntRange("Richiedo o la somma di 2 dadi o un altro numero base, dimmene un altra",
                                    "Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 12",
                                    "Deve essere diverso dalla tua prima scelta", 1, 12, guess);

                //si tirano sia i dadi assist che i dadispera
                for (int l = 0; l < dadAss.Length; l++)
                {
                    dadAss[l] = ran.Next(1, 7);
                }
                for (int l = 0; l < dadisp.Length; l++)
                {
                    dadisp[l] = ran.Next(1, 7);
                }

                //ma solo i dadispera vengono rivelati
                Thread.Sleep(meTime);

                Console.Write($"Ecco a te i ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Dadispera\n\n\t{dadisp[0]}\t{dadisp[1]}\t{dadisp[2]}\t{dadisp[3]}\n");
                Console.ResetColor();


                //token necessari per i punti e per diversi controlli
                bool gotOne = false;
                bool gotSome = false;
                bool gotDoubleOne = false;
                bool gotDoubleSome = false;
                critica = 0;




                //li si controlla uno ad uno
                for (int l = 0; l < dadisp.Length; l++)
                {
                    //e per controllare le somme, si fa un altro ciclo
                    for (int j = l; j < dadisp.Length; j++)
                    {
                        //se la somma di 2 diversi dadi haunted è uguale al secondo numero deciso dal giocatore
                        if (l != j && dadisp[l] + dadisp[j] == sumGuess)
                        {
                            //gotsome è contrassegnato solamente dopo aver trovato una somma
                            if (gotSome)//di conseguenza, non si riattiva prima di incontrare la stessa somma
                                        //in una combinazione diversa
                                gotDoubleSome = true;
                            //lo si contrassegna
                            gotSome = true;
                        }
                    }
                }
                //il motivo per farlo in un ciclo a parte, è per evitare che dei controlli non riuscisserò a rilevare
                //in tempo tutte le somme prima del controllo in singolo
                for (int l = 0; l < dadisp.Length; l++)
                {
                    //si fa un controllo per il numero base, che vale per ambo i numeri
                    //ma il secondo numero deciso dal giocatore lo si controlla se non è stata rilevata una somma
                    if (dadisp[l] == guess || (dadisp[l] == sumGuess && gotSome != true))
                    {
                        gotOne = true;
                        //ci sarà un controllo per vedere se quello azzeccato ha un doppione
                        for (int j = 0; j < dadisp.Length; j++)
                        {
                            if (l != j && dadisp[l] == dadisp[j])
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

                //la critica indica quale file verrà stampato, ogni file avrà tot numeri di alternative, per rendere meno ripetitivi le reazioni
                pathText = @"csvsenteces\giocaVince0" + critica + ".csv";
                
                //reazioni in base a quanto ha azzeccato il giocatore
                Thread.Sleep(meTime);
                if(!StampaTestoCsv(pathText, 0))
                {
                    return;
                }


                //in caso il giocatore avesse indovinato, li si chiede se vuole rischiare anche solo per vedere cosa aveva l'assistente
                if (punto > 0)
                {
                    //si avvisa di quanti punti ha e del rischio in caso si volesse vedere che cosa hanno i dadi assistenti
                    Thread.Sleep(meTime);


                    pathText = @"csvsenteces\giocaVince.csv";
                    stampaNumero[0] = 3;
                    if (!StampaTestoCsv(pathText, 0, stampaNumero))
                    {
                        return;
                    }

                    Console.WriteLine($"(1 per rivelare l'assistente, 2 per tenerti i punti)");


                    reveal = ReplyIntRange("(Ti ho richiesto 1 o 2)", "Unfortunately, non ho altre opzioni", 1, 2);
                    //se accetta il rischio, si dimezza di già il punteggio, il target è solo cò che ha indovinato il giocatore, non i dadi
                    if (reveal == 1)
                    {
                        Thread.Sleep(meTime);
                        punto = (float)Math.Round(punto / 2);
                        Console.Write($"Ora i tuoi punti stanno a ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Thread.Sleep(meTime);
                        Console.Write(punto);
                        Console.ResetColor();
                        Thread.Sleep(meTime);
                        Console.WriteLine($", vediamo se ne sarà valsa la pena\n");
                    }
                }
                //invece se il giocatore non ha preso niente...
                else
                {
                    //si dà il messsaggio per avvisarlo e chiedere se vuole vedere se magari l'assistente li da un qualche punto
                    pathText = @"csvsenteces\giocaPerde.csv";
                    if (!StampaTestoCsv(pathText, 0))
                    {
                        return;
                    }


                    Console.Write($"(1 per rivelare i dadi ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Osperà");
                    Console.ResetColor();
                    Console.WriteLine($", 2 per gettare la spugna)");

                    reveal = ReplyIntRange("(Ti ho richiesto 1 o 2)", "Unfortunately, non ho altre opzioni", 1, 2);
                    //ma se per qualche strana ragione il giocatore non abbia voglia, si esprime la sorpresa di questa strana decisione
                    if (reveal == 2)
                    {
                        Console.WriteLine("Honestly... non mi aspettavo qualcuno avrebbe rinunciato a prendere dei punti gratis");
                    }
                }
                //solo dopo il bivio, si aggiungerà il punteggio al punteggio finale
                totPunto += punto;



                //ora, questa è l'operazione per i dadi Osperà, che avranno un simile procedimento a prima... probabilmente in futuro creerò un metodo
                if (reveal == 1)
                {
                    Thread.Sleep(meTime);
                    Console.Write($"Ecco cosa dice ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Osperà");
                    Console.ResetColor();
                    Console.WriteLine($":\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Thread.Sleep(meTime);
                    Console.WriteLine($"\t{dadAss[0]}\t{dadAss[1]}\n");
                    Console.ResetColor();
                    //token necessari per i punti, per diversi controlli ed il punteggio
                    gotOne = false;
                    gotSome = false;
                    gotDoubleOne = false;
                    gotDoubleSome = false;
                    critica = 0;
                    float assPunt = 0;
                    //a differenza di prima, i dadi assist hanno il vantaggio di aver ben 2 numeri base invece che uno, insieme alla somma
                    for (int l = 0; l < dadisp.Length; l++)
                    {
                        //per evitare di rivedere dadi precedenti, inizio dallo stesso dado
                        for (int j = l; j < dadisp.Length; j++)
                        {
                            //se la somma di 2 diversi dadi haunted è uguale alla somma dettata da Osperà
                            if (l != j && dadisp[l] + dadisp[j] == dadAss[0] + dadAss[1])
                            {
                                //controllo se ci son 2 somme uguali in combinazioni diverse tramite il check
                                if (gotSome)
                                    gotDoubleSome = true;
                                //some è contrassegnato alla fine per evitare di 
                                gotSome = true;
                            }
                        }
                    }
                    for (int k = 0; k < dadAss.Length; k++)
                    {
                        //il motivo per farlo in un ciclo a parte, è per evitare che dei controlli non riuscisserò a rilevare
                        //in tempo tutte le somme prima del controllo in singolo
                        for (int l = 0; l < dadisp.Length; l++)
                        {
                            if (dadisp[l] == dadAss[k])
                            {
                                gotOne = true;
                                //ci sarà un controllo per vedere se quello azzeccato ha un doppione
                                for (int j = 0; j < dadisp.Length; j++)
                                {
                                    if (l != j && dadisp[l] == dadisp[j])
                                    {
                                        gotDoubleOne = true;
                                    }
                                }
                            }
                        }
                    }

                    if (gotOne)
                    {
                        assPunt = assBas;
                        critica = 1;
                        if (gotDoubleOne)
                        {
                            assPunt = (float)Math.Truncate((assBas * 2) + (assBas / 2));
                            critica = 3;
                        }
                    }
                    //simile al controllo precedente, ma con la somma
                    if (gotSome)
                    {
                        //il punto verrà applicato
                        assPunt = asSum;
                        critica = 2;
                        //se ha beccato a parte un numero base
                        if (gotOne)
                        {
                            //il punteggio applicato sarà quello speciale
                            assPunt = assBas * 3;
                            critica = 5;
                            //e verrà ulteriormente aumentato se ha beccato i doppioni, una cosa moolto rara
                            if (gotDoubleSome && gotDoubleOne)
                            {
                                assPunt = assBas * 4;
                                critica = 6;
                            }
                        }
                        //altrimenti, si procede con la stessa procedura del numero base
                        else
                        //ciò è fatto in modo da dar priorità al punteggio massimo
                        if (gotDoubleSome)
                        {
                            assPunt = asSum + (float)Math.Truncate(asSum / 2);
                            critica = 4;
                        }
                    }


                    //debug
                    //critica = Convert.ToInt32(Console.ReadLine());

                    pathText = @"csvsenteces\ospeVince0" + critica + ".csv";
                    if (!StampaTestoCsv(pathText, 0))
                    {
                        return;
                    }

                    //reazioni in base a quanto ha azzeccato il giocatore
                    Thread.Sleep(meTime);

                    //se osperà indovina qualcosa, si avvisa al giocatore di quanto viene aumentato il punteggio
                    if (assPunt > 0)
                    {
                        Thread.Sleep(meTime);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Osperà");
                        Console.ResetColor();
                        Console.Write(" ti da ");
                        Thread.Sleep(meTime);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(assPunt);
                        Console.ResetColor();
                        Console.Write(" punti insieme ai tuoi ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(punto);
                        Console.ResetColor();
                        Console.WriteLine(" punti\n");
                    }
                    //altrimenti, niente...
                    else
                    {
                        Thread.Sleep(meTime);
                        Console.Write("Stavolta ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Osperà");
                        Console.ResetColor();
                        Console.WriteLine(" non è riuscito a trovare niente...\n");
                    }

                    //si aggiunge il punteggio subito stavolta
                    //in futuro però vorrei vedere un modo per ripetere l'utilizzo di Osperà, col costo di punti
                    totPunto += assPunt;
                }



                //si tiene presente al giocatore quanto si ha di punteggio totale
                Console.Write("Il tuo punteggio totale sta a ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{totPunto}\n");
                Console.ResetColor();

                //randomicamente si avviserà al giocatore quanti punti deve arrivare per vincere
                int warn = 0;
                if (totPunto < vinPunt)
                {
                    warn = ran.Next(0, 2);
                    if (i == maxTurn - 1 || warn == 1)
                    {
                        Console.Write("Ti ricordo che devi raggiungere ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{vinPunt}");
                        Console.ResetColor();
                        Console.WriteLine(" per vincere\n");
                    }
                }
            }

            if (totPunto >= vinPunt)
            {
                Console.WriteLine("Complimenti, hai vinto");
            }
            else
            {
                Console.WriteLine("Spiacente, hai perso");
            }

            //Scrittura dei dati in una variabile, per poi salvarli verso la fine del turno...
            //cambio piano, lo faccio salvare subito
            datiSave[3] = maxTurn.ToString();
            datiSave[5] = totPunto.ToString();
            datiSave[7] = false.ToString();
            File.WriteAllLines(pathSave, datiSave);


            Console.WriteLine("\nVuoi Fare un altra partita?\n(Premi S per si, N per no)");
            end = Accettare("\nAight...", "\nGrazie per aver giocato ad 'Indovina, Osperà'", "Avrei bisogno di sapere se Si o No...", true);
        }
    }


    static bool StampaTestoCsv(string path, int altern)
    //string path= il percorso del file in stringa, int altern= il numero di appartenenza del testo da stampare, params int[] values= opzionale, un array con delle variabili da stampare
    {
        //diversi trycatch per sapere che tipo di errore è accaduto in tutto ciò
        try
        {
            try
            {
                string[] trova = File.ReadAllLines(path);
                string[][] prova = new string[trova.Length][];
                for (int i = 0; i < trova.Length; i++)
                {
                    prova[i] = trova[i].Split("|");//uno può utilizzare ciò che vuole, ma è alquanto importante decidere cosa usare per via della memoria usata per lo split in base al carattere
                }
                for (int i = 0; i < prova.Length; i++)
                {
                    if (Convert.ToInt32(prova[i][3]) == altern)
                    {
                        switch (Convert.ToInt32(prova[i][1]))
                        {
                            case 0:
                                Console.ResetColor();
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            default:
                                Console.WriteLine("Devi riscrivere i file, c'è qualcosa di strano in quel che ho letto");
                                return false;
                        }
                        Console.Write(prova[i][0]);
                        for (int l = 0; l < Convert.ToInt32(prova[i][2]); l++)
                            Console.Write("\n");
                    }
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Riconfigura il codice o il file, qui c'è qualcosa di dannatamente sbagliato\n" + ex.Message);
                return false;
            }
        }
        catch
        {
            Console.WriteLine("Sorry to break it to ya, but your whole team paid me to do this");
            return false;
        }

        return true;
    }

    //versione con array di float, in caso servisse stampare dei numeri variabili, prettamente di tipo float
    static bool StampaTestoCsv(string path, int altern, float[] values)
    //string path= il percorso del file in stringa, int altern= il numero di appartenenza del testo da stampare, params int[] values= opzionale, un array con delle variabili da stampare
    {
        //try catch in caso qualche errore accada
        try
        {
            //lettura e copiatura del file: il file deve esistere perchè è necessario per la stampa del testo customizzato
            string[] trova = File.ReadAllLines(path);
            string[][] prova = new string[trova.Length][];
            for (int i = 0; i < trova.Length; i++)
            {
                prova[i] = trova[i].Split("|");//si utilizza | perchè nel contesto utilizzato, le virgole e punto e virgola hanno una buona chance d'esser usate nel testp
            }
            //count è un contatore riservato per le possibili variabili float
            int count = 0;
            //qui è dove avviene la stampa del testo da csv
            for (int i = 0; i < prova.Length; i++)
            {
                //controllo preventivo che nella linea di testo sia presente una specifica stringa, possibilmente un qualcosa che a nessuno verrebbe in mente di mettere nel testo
                if (prova[i][0].Trim() == "pABLO" && count < values.Length)
                //il trim è usato per prevenire qualche errore nel controllo: gli spazi occupano degli slot della string
                {
                    //se è una linea dedicata ad una variabile, lo si imette al posto di quella stringa
                    prova[i][0] = values[count].ToString();
                    //il contatore aumenta per evitare di sforare l'array imesso come parametro
                    count++;
                }
                //controllo che sia effettivamente 
                if (Convert.ToInt32(prova[i][3]) == altern)
                {
                    switch (Convert.ToInt32(prova[i][1]))
                    {
                        case 0:
                            Console.ResetColor();
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default:
                            Console.WriteLine("Devi riscrivere i file, c'è qualcosa di strano in quel che ho letto");
                            return false;
                    }
                    Console.Write(prova[i][0]);
                    for (int l = 0; l < Convert.ToInt32(prova[i][2]); l++)
                        Console.Write("\n");
                }
            }
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Riconfigura il codice o il file, qui c'è qualcosa di dannatamente sbagliato\n" + ex.Message);
            return false;
        }

        return true;
    }

    //Funzione per leggere qualsiasi numero che sia compreso in un certo range, con dei commenti personalizzabili
    static int ReplyIntRange(string stufo, string fuoriRange, int min, int max)
    {
        //bool per uscire dal while in modo normale
        bool done = false;
        //il numero inserito
        int reply = 0;
        while (!done)
        {
            //done verrà sempre cambiato, in modo da uscire finchè non accade un errore
            done = true;
            //try catch per evitare che l'utente digiti qualcosa che non sia un numero
            try
            {
                reply = Convert.ToInt32(Console.ReadLine());
                //stampa del messaggio per dire che non è nel range il numero scelto
                if (reply < min || reply > max)
                {
                    Console.WriteLine(fuoriRange);
                    //si rimane dentro al ciclo
                    done = false;
                }
            }
            //potrei modificarlo er renderlo esclusivo del problema di conversione
            catch
            {
                //si indica all'utente che il programma necessita di un NUMERO
                Console.WriteLine(stufo);
                //rimane dentro al ciclo per questo
                done = false;
            }
        }
        //ritorna il numero digitato
        return reply;
    }
    //Versione con una condizione in più: un numero da evitare all'interno del range ed un nuovo messaggio d'errore customizzabile
    static int ReplyIntRange(string stufo, string fuoriRange, string paradosso, int min, int max, int original)
    {
        bool done = false;
        int reply = 0;
        while (!done)
        {
            done = true;
            try
            {
                reply = Convert.ToInt32(Console.ReadLine());
                if (reply < min || reply > max)
                {
                    Console.WriteLine(fuoriRange);
                    done = false;
                }
                else
                //messo in un if diverso essendo un errore di tipo diverso
                if (original == reply)
                {
                    Console.WriteLine(paradosso);
                    done = false;
                }
            }
            catch
            {
                Console.WriteLine(stufo);
                done = false;
            }
        }
        return reply;
    }

    //Funzione che restituisce un bool, nel quarto parametro si deve mettere true o false che indica se si vuole usare la risposta S da tastiera
    //per invece ritornare false
    static bool Accettare(string good, string fine, string again, bool reverse)
    {
        //dichiarazione del bool accetta
        bool accetta = false;
        //il while deve essere forzatamente terminato
        while (true)
        {
            //si attende un input da tastiera
            ConsoleKeyInfo risposta = Console.ReadKey(true);
            if (risposta.Key == ConsoleKey.S)
            {
                Console.WriteLine(good);
                accetta = !reverse;
                break;
            }
            else if (risposta.Key == ConsoleKey.N)
            {
                Console.WriteLine(fine);
                accetta = reverse;
                break;
            }
            else
            {
                Console.WriteLine(again);
            }
        }
        return accetta;
    }
}
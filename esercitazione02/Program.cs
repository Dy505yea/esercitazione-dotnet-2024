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
        string player=defaultName;
        //dadi Osperà (avendo un pò un ruolo da aiutante, lo considero principalmente come assistente), ce ne saranno 2
        int[] dadAss = new int[2];
        //i dadispera, ce ne saranno 4
        int[] dadisp = new int[4];
        //2 variabili che verranno usate per indovinare i numeri
        int guess = 1;    //base di un dadospera
        int sumGuess = 2; //somma di 2 dadispera... o uno base
        //turni di una partita
        int maxTurn = 2;
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
        //usato meramente per debug
        int meTime = 500;


        //prova di apertura di un file... altrimenti se ne crea uno nuovo
        //path del file di salvataggio
        string pathSave = @"..\esercitazione02\la provetta\saveOspera.txt";
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
            Console.WriteLine($"Vedo che la partita era crashata per qualche motivo...\nPartita del giocatore {datiSave[1]}, Turno {datiSave[3]}, Punteggio {datiSave[5]}\nVuoi riprendere da qui?");
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

        //Thread.Sleep(2000);




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
            player=Console.ReadLine()!;
            if(player.Trim().Length<=0)
            {
                Console.WriteLine($"Allora ti chiamerò {defaultName}, dato che ti piace fare il misterioso");
                player=defaultName;
            }
            else
            {
                Console.WriteLine($"Bene, {player}, piacere di conoscerti");
            }
            Thread.Sleep(900);
        }
        while (!end)
        {
            datiSave[1]=player;
            //sarà sempre falso dal secondo ciclo in poi, in modo da evitare la domanda all'inizio
            if (!rule)
            {
                Console.WriteLine("Vuoi sentire le regole?\n(S per si, N per no)");
            Rispiega:
                ConsoleKeyInfo reply = Console.ReadKey(true);
                if (reply.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"Fammi rileggere...");
                    rule = true;
                }
                else if (reply.Key == ConsoleKey.N)
                {
                    Console.WriteLine($"Ok");
                }
                else
                {
                    Console.WriteLine("Avrei bisogno di sapere se Si o No...");
                    goto Rispiega;
                }
                Thread.Sleep(meTime * 2);
                Console.Clear();
            }
            //ho messo un blocco a parte per via della grandezza per la stampa del regolamento, tutto per questione di grafica
            //il check del token è per prevenire di riscrivere il regolamento di nuovo in una partita
            if (rule)
            {
                //Regolamento, una lunga serie di print
                Console.WriteLine("\nLe regole:\n- Puoi provare ad indovinare 2 numeri, un numero base di 1 dado ed una somma di 2 dadi");
                Thread.Sleep(meTime);
                Console.Write($"- Indovina il numero base di un ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Dadospera");
                Console.ResetColor();
                Console.Write($", ottieni ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(basic);
                Console.ResetColor();
                Console.Write($" punti, indovina una somma di 2 e ne otterrai ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(sumBasic);
                Console.ResetColor();
                Console.Write($", indovina ambo e ne otterrai ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(basic * 3);
                Console.ResetColor();
                Thread.Sleep(meTime);
                Console.WriteLine("- Volendo, puoi invece provare ad indovinare un altro numero base, ma in quel caso non otterrai più punti");
                Thread.Sleep(meTime);
                Console.Write($"- Hai a disposizione 2 dadi ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Osperà");
                Console.ResetColor();
                Console.Write(" che possono aiutarti, ma il loro punteggio è ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ridotto");
                Console.ResetColor();
                Console.Write(",");
                Console.Write($" rispettivamente dando ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(assBas);
                Console.ResetColor();
                Console.Write($" e ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(asSum);
                Console.ResetColor();
                Thread.Sleep(meTime);
                Console.Write($"- Li puoi rivelare anche se hai indovinato, ma far ciò ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"dimezzerà");
                Console.ResetColor();
                Console.Write($" i punti ottenuti prima di rivelare ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Osperà");
                Console.ResetColor();
                Thread.Sleep(meTime);
                Console.Write($"- Se per caso nei ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Dadispera");
                Console.ResetColor();
                Console.Write($" son presenti dei doppi, indovinando la somma di essi si otterrà ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(sumBasic + (float)Math.Truncate(sumBasic / 2));
                Console.ResetColor();
                Console.Write($", se si indovina il punto base, allora invece si otterrà ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((float)Math.Truncate((basic * 2) + (basic / 2)));
                Console.ResetColor();
                Thread.Sleep(meTime);
                Console.Write($"- La stessa regola si applica ai ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"dadi Osperà");
                Console.ResetColor();
                Console.Write($": rispettivamente ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(asSum + (float)Math.Truncate(asSum / 2));
                Console.ResetColor();
                Console.Write($" per la somma e ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write((float)Math.Truncate((assBas * 2) + (assBas / 2)));
                Console.ResetColor();
                Console.WriteLine($" per il base");
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
            }

            //inizio del gioco
            for (int i = predefined; i < maxTurn; i++)
            {
                //inizializzazone della variabile volatile del punteggio
                punto = 0;

                //Scrittura dei dati in una variabile, per poi salvarli verso la fine del turno...
                //cambio piano, lo faccio salvare subito
                datiSave[3] = i.ToString();
                datiSave[5]= totPunto.ToString();
                datiSave[7]= true.ToString();
                File.WriteAllLines(pathSave, datiSave);

                //inizializzazione random all'inizio della manche per rendere più casuale possibile
                Random ran = new Random();
                Thread.Sleep(meTime);
                Console.WriteLine($"{i + 1}° turno\n\nInserisci il numero base");
                Thread.Sleep(meTime);
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
                for (int l = 0; l < dadisp.Length; l++)
                {
                    dadisp[l] = ran.Next(1, 7);
                }
                //ma solo i dadi haunted vengono rivelati
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
                //reazioni in base a quanto ha azzeccato il giocatore
                Thread.Sleep(meTime);
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
                    reveal = 0;
                    //si avvisa di quanti punti ha e del rischio in caso si volesse vedere che cosa hanno i dadi assistenti
                    Thread.Sleep(meTime);
                    Console.Write($"Congrats, puoi portarti a casa ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(meTime);
                    Console.Write(punto);
                    Console.ResetColor();
                    Console.WriteLine($" punti... oppure vuoi provare a vedere cosa tira fuori l'assistente al costo della metà dei tuoi punti?");
                    Console.WriteLine($"(1 per rivelare l'assistente, 2 per tenerti i punti)");
                DecisioneRischio:
                    try
                    {
                        reveal = Convert.ToInt32(Console.ReadLine());
                        if (reveal < 1 || reveal > 2)
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
                    Console.Write($"Uf, pare che la fortuna non sia dalla tua parte, puoi sempre sperare in ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Osperà");
                    Console.ResetColor();
                    Console.WriteLine($", se vuoi");
                    Console.Write($"(1 per rivelare i dadi ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Osperà");
                    Console.ResetColor();
                    Console.WriteLine($", 2 per gettare la spugna)");
                    reveal = 0;
                VuoiContinuare:
                    try
                    {
                        reveal = Convert.ToInt32(Console.ReadLine());
                        if (reveal < 1 || reveal > 2)
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
                    //reazioni in base a quanto ha azzeccato il giocatore
                    Thread.Sleep(meTime);
                    switch (critica)
                    {
                        case 6:
                            Console.Write($"HOLYMARYMOTHEROFJOSEPH, ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"OSPERÀ");
                            Console.ResetColor();
                            Console.WriteLine($" HA TROVATO AMBO I DOPPIONI\n");
                            break;
                        case 5:
                            Console.Write($"Wow, ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Osperà");
                            Console.ResetColor();
                            Console.WriteLine($" ha indovinato sia base che la somma\n");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Osperàsmus");
                            Console.ResetColor();
                            Console.WriteLine($" ha previsto la doppia somma\n");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Osperà");
                            Console.ResetColor();
                            Console.WriteLine($" è il nuovo cupido, ha trovato 2 single doppioni\n");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Osperà");
                            Console.ResetColor();
                            Console.WriteLine($" ha preso la somma\n");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Osperà");
                            Console.ResetColor();
                            Console.WriteLine($" ha pigliato un numero\n");
                            break;
                    }

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

            }

                //Scrittura dei dati in una variabile, per poi salvarli verso la fine del turno...
                //cambio piano, lo faccio salvare subito
                datiSave[3] = maxTurn.ToString();
                datiSave[5]= totPunto.ToString();
                datiSave[7]= false.ToString();
                File.WriteAllLines(pathSave, datiSave);


            Console.WriteLine("\nVuoi Fare un altra partita?\n(Premi S per si, N per no)");
        Ricomincia:
            ConsoleKeyInfo risposta = Console.ReadKey(true);
            if (risposta.Key == ConsoleKey.S)
            {
                Console.WriteLine($"\nAight...");
                Thread.Sleep(meTime * 2);
                Console.Clear();
            }
            else if (risposta.Key == ConsoleKey.N)
            {
                Console.WriteLine($"\nGrazie per aver giocato ad 'Indovina, Osperà'");
                end = true;
            }
            else
            {
                Console.WriteLine("Avrei bisogno di sapere se Si o No...");
                goto Ricomincia;
            }
        }
    }
}
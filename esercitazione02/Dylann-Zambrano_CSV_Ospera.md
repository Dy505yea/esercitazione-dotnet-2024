# ASSIGNMENT

## README

# Gioco di dadi... Indovina, Osperà

## In che consiste

<p>Basically, ci son 6 dadi, 2 son del giocatore (nominati dadi Osperà) e 4 del gioco in sé (nominati Dadispera)<br>
I 2 dadi verranno usati come aiuto extra, dato che qui sarà un gioco sulla fortuna

Il giocatore deciderà 2 numeri: Il 1° il numero base di un dado ed il 2° è una possibile somma... oppure un altro numero base<br>
I 4 Dadispera son da indovinare, se il giocatore ha beccato un numero base, otterrà dei punti, se becca una somma, otterrà metà dei punti in più, se
becca ambo, otterrà 3 volte i punti base<br>
I 2 dadi verranno tirati nello stesso momento dei Dadispera: se il giocatore lo vorrà, può richiedere l'aiuto dei dadi Osperà, ma il loro
il punteggio verrà diminuito (per ora pensavo di un quarto in questo caso, arrotondato per eccesso)<br>
Anche se il giocatre ha indovinato, può lo stesso richiedere l'aiuto dei dadi Osperà, tho il punteggio totale verrà dimezzato per quel turno<br>
Se c'è un doppio tra i Dadispera, il punto verrà aumentato della metà se si è indovinata la somma, raddoppiato + mezzo punto in caso si fosse indovinato il punto base<br>
Volendo, i dadi Osperà possono essere ritirati più volte, ma il giocatore deve dare dei punti per farlo (still thinking quanto esattamente... per ora sarà solo come cosa extra)<br>
Il giocatore vince se arriva ad un certo punteggio alla fine dei turni</p>

## Definizione dei requisiti

- [x] 6 variabili dadi, separati tra Osperà e Dadispera, 2 variabili per le azzardate del giocatore
- [x] calcolo delle somme dei Dadispera
- [x] confronto delle risposte del giocatore coi Dadispera
- [x] rispettare un token per rivelare i dadi Osperà
- [ ] sottrazione punti per ritiro dadi Osperà
- [x] gestione del punteggio da come il giocatore azzecca i numeri
- [x] gestione sottrazione dei punti se il giocatore richiede i dadi Osperà
- [x] gestione del caso speciale del doppio numero
- [x] scrittura dei dati in file a parte della partita in caso di inaspettato termine programma
- [x] lettura dei dati da file per ripresa della partita salvata
- [x] scrittura messaggio di errore in caso di lettura di dati di un tipo non adatto
- [x] utilizzo dei float per il calcolo del punteggio
- [x] richiesta di un rematch verso il termine del programma, in caso il giocatore volesse riprovare

## Interfaccia utente

- [x] Introduzione personalizzata, ma per mera presentazione
- [x] Regole spiegate all'inizio
- [x] Possibilmente anche per ogni rematch, ma solo su richiesta
- [x] Quando si menziona qualcosa riguardante ai dadi Osperà (o qualche buon evento), si evidenzia con un colore, stessa cosa per i Dadispera (e magari qualche cattivo evento)
- [x] Richiesta di conferma, o anceh solo forzare a premere invio, per evitare che il giocatore per sbaglio scelga la scelta non voluta
- [x] Se la partita era precariamente terminata prima della fine della manche, l'utente potrà decidere se riprendere dall'ultimo salvataggio, che avverrà ad ogni fine turno
> - [ ] (Facoltativo) Il gioco userà una frase diversa casualmente in certi momenti della partita, le frasi saranno presi da un file esterno
- [x] Il punteggio deve rimanere presente, in modo che l'utente tenga presente di quanto ha
- [ ] Ogni qualvolta, si ricorda al giocatore quanti punti necessita per effettivamente vincere

## Definizione del file

- Essendo un salvataggio per necessità, lo scopo è solo di permettere al giocatore di finire la partita se per qualche motivo la partita è crashata

- [x] Nome del giocatore della partita interrotta, quindi necessità di sapere preventivamente il nome del giocatore
- [x] Numero del turno
- [x] Punteggio totale
- [x] Boolean per sapere se la partita era in corso o meno
> - [ ] (Facoltativo) Magari una cronologia del punteggio, che duri nel tempo o solo per confrontare in un periodo di tempo breve (stessa partita)

## Possibili migliorie future

<p>Il gioco è nato col concetto di essere single-player, ma magari fare in modo da permettere di giocare con più giocatori, magari a turno:

Ogni giocatore fa la manche proprio come farebbe in singleplayer, quindi l'unica cosa che cambierebbe e dover ripetere per il numero di giocatori
Se si applica il file, magari farsì che si crei una struttura per tenere presente i dati di ogni giocatore
</p>

## CODICI

```c#

class Program
{

    static void Main(string[] args)
    {
        //Indovina, Osperà!
        
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
                    critica = Convert.ToInt32(Console.ReadLine());

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
    static bool StampaTestoCsv(string path, int altern, params float[] values)
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
```

## I FILE CSV (tutti devono essere contenuti in una sottocartella nominata csvsenteces)

> regoleOsperà.csv
```csv
Le regole|0|1|0
- Puoi provare ad indovinare 2 numeri, un numero base di 1 dado ed una somma di 2 dadi|0|1|0
- Indovina il numero base di un |0|0|0
Dadospera|2|0|0
, ottieni |0|0|0
pABLO|1|0|0
 punti, indovina una somma di 2 e ne otterrai |0|0|0
pABLO|1|0|0
 , indovina ambo e ne otterrai |0|0|0
pABLO|1|1|0
- Volendo, puoi invece provare ad indovinare un altro numero base, ma in quel caso non otterrai più punti|0|1|0
- Hai a disposizione 2 dadi |0|0|0
 Osperà|2|0|0
  che possono aiutarti, ma il loro punteggio è |0|0|0
ridotto|3|0|0
, rispettivamente dando |0|0|0
pABLO|1|0|0
 e |0|0|0
pABLO|1|1|0
- Li puoi rivelare anche se hai indovinato, ma far ciò |0|0|0
dimezzerà|1|0|0
 i punti ottenuti prima di rivelare |0|0|0
 Osperà|2|1|0
- Se per caso nei |0|0|0
Dadispera|3|0|0
 son presenti dei doppi, indovinando la somma di essi si otterrà |0|0|0
pABLO|1|0|0
, se si indovina il punto base, allora invece si otterrà |0|0|0
pABLO|1|1|0
- La stessa regola si applica ai |0|0|0
dadi Osperà|2|0|0
: rispettivamente |0|0|0
pABLO|1|0|0
 per la somma e |0|0|0
pABLO|1|0|0
 per il base|0|1|0
```

> giocaPerde.csv
```csv
Uf, pare che la fortuna non sia dalla tua parte, puoi sempre sperare in |0|0|0
Osperà|2|0|0
, se vuoi|0|1|0
```

> giocaVince.csv
```csv
Congrats, puoi portarti a casa |0|0|0
pABLO|1|0|0
 punti... oppure vuoi provare a vedere cosa tira fuori l'assistente al costo della metà dei tuoi punti?|0|1|0
```

> ospeVince01.csv
```csv
Osperà|2|0|0
 ha pigliato un numero|0|1|0
```

> ospeVince02.csv
```csv
Osperà|2|0|0
 ha preso una somma|0|1|0
```

> ospeVince03.csv
```csv
Osperà|1|0|0
 è il nuovo cupido, ha preso 2 single doppioni|0|1|0
```

> ospeVince04.csv
```csv
Osperasmus|2|0|0
 ha previsto la doppia somma|0|1|0
```

> ospeVince05.csv
```csv
Wow, |0|0|0
Osperà|1|0|0
 ha indovinato sia una base che la somma|0|1|0
```

> ospeVince06.csv
```csv
HOLYMARYMOTHEROFJOSEPH, |0|0|0
Osperà|2|0|0
 HA TROVATO AMBO I DOPPIONI|0|1|0
```

## IL FILE DI TESTO (Contenuto in una sottocartle "la provetta")

> saveOspera.txt
```txt
Nome
Player
Turno
3
Punteggio Totale
30
WIP?
True

```
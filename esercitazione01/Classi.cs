using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

public class Funzioni{
    //Funzione per leggere qualsiasi numero che sia compreso in un certo range, con dei commenti personalizzabili
    public int ReplyIntRange(string stufo, string fuoriRange, int min, int max)
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
    public int ReplyIntRange(string stufo, string fuoriRange, string paradosso, int min, int max, int original)
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
    public bool Accettare(string good, string fine, string again, bool reverse)
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
    public bool StampaTestoCsv(string path, int altern)
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
}


public class Giocatore
{
    public string Nome { get; set; }
    public float Punt { get; set; }
    public float TotPunt { get; set; }
    public int Turno { get; set; }

    public int Guess { get; set; }
    public int SumGuess { get; set; }

    Funzioni fun= new Funzioni();

    public Giocatore(string nome, float punt, float totpunt, int turn)
    {
        Nome = nome;
        Punt = punt;
        TotPunt = totpunt;
        Turno = turn;
    }
    public Giocatore()
    {
        Nome="Player";
        Punt=0;
        TotPunt=0;
        Turno=0;
    }

    public void IndoGioca(int turn)
    {
        Console.WriteLine($"{turn + 1}° turno\n\nInserisci il numero base");
        Guess = fun.ReplyIntRange("Non stiamo giocando a qualcosa come DnD, le facce son solo 6 e richiedo un numero da 1 a 6",
                            "Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 6", 1, 6);
        Console.WriteLine("Inserisci la somma... o un altro numero base");
        SumGuess = fun.ReplyIntRange("Richiedo o la somma di 2 dadi o un altro numero base, dimmene un altra",
                            "Sarebbe strano trovare delle parole sui dadi, necessito un numero... da 1 a 12",
                            "Deve essere diverso dalla tua prima scelta", 1, 12, Guess);
    }

    public void AggiungiPunto()
    {
        TotPunt+=Punt;
    }
    public void AggiungiPunto(int punt)
    {
        TotPunt+=punt;
    }
}
public class DadiAssist
{
    public int Valore { get; set; }
}
public class DadiSpera{

}
public class Punteggio{

}

public class Gioco : Funzioni{
    bool end=false;
    int maxTurn=5;
    Giocatore player = new Giocatore();
    GestoFile manager = new GestoFile(@"salvataggio\saveOspera.txt");
    public void PartitaInCorso()
    {
        while (!end)
        {
            manager.SetDatoAt(1, player.Nome);
            //sarà sempre falso dal secondo ciclo in poi, in modo da evitare la domanda all'inizio
            /*classe regole gestisce quest'area, prova con una funzione void*/
            if (!rule)
            {
                Console.WriteLine("Vuoi sentire le regole?\n(S per si, N per no)");
                rule = Accettare("Fammi rileggere...", "Ok", "Avrei bisogno di sapere se Si o No...", false);
                //Thread.Sleep(meTime * 2);
                Console.Clear();
            }
            //ho messo un blocco a parte per via della grandezza per la stampa del regolamento, tutto per questione di grafica
            //il check del token è per prevenire di riscrivere il regolamento di nuovo in una partita
            /*prevalentemente tra classe file e regole, funzione avviata da quest'ultima*/
            if (rule)
            {
                manager.ChangePath(@"..\esercitazione02\csvsenteces\regoleOspera.csv");
                //Regolamento, una lunga serie di print
                float[] valori = { basic, sumBasic, basic * 3, assBas, asSum,
                                    sumBasic + (float)Math.Truncate(sumBasic / 2), (float)Math.Truncate((basic * 2) + (basic / 2)),
                                    asSum + (float)Math.Truncate(asSum / 2), (float)Math.Truncate((assBas * 2) + (assBas / 2)) };
                bool allGood = manager.StampaTestoCsv(0, valori);
                if (!allGood)
                {
                    return;
                }
                //Thread.Sleep(meTime);
                Console.WriteLine("\nDetto ciò, iniziamo il gioco\n");
                rule = false;
            }


            //questo è necessario solo per debug
            //end = true;

            /*classe file e giocatore*/
            int predefined = 0;
            if (resume)
            {
                predefined = Convert.ToInt32(manager.GetDatoAt(3));
                player.TotPunt = Convert.ToInt32(manager.GetDatoAt(5));
            }

            //inizio del gioco
            for (int i = predefined; i < maxTurn; i++)
            {
                //inizializzazone della variabile volatile del punteggio
                player.Punt = 0;

                //Scrittura dei dati in una variabile, per poi salvarli verso la fine del turno...
                //cambio piano, lo faccio salvare subito
                manager.SalvaTurno(i, player.TotPunt, true);

                //inizializzazione random all'inizio della manche per rendere più casuale possibile
                Random ran = new Random();
                //Thread.Sleep(meTime);
                player.IndoGioca(i);

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
                //Thread.Sleep(meTime);

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
                    if (dadisp[l] == player.Guess || (dadisp[l] == player.SumGuess && gotSome != true))
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
                    player.Punt = basic;
                    critica = 1;
                    //ma cambierà se il numero indovinato ha un doppione
                    if (gotDoubleOne)
                    {
                        player.Punt = (float)Math.Truncate((basic * 2) + (basic / 2));
                        critica = 3;
                    }
                }
                //simile al controllo precedente, ma con la somma
                if (gotSome)
                {
                    //il punto verrà applicato
                    player.Punt = sumBasic;
                    critica = 2;
                    //se ha beccato a parte un numero base
                    if (gotOne)
                    {
                        //il punteggio applicato sarà quello speciale
                        player.Punt = basic * 3;
                        critica = 5;
                        //e verrà ulteriormente aumentato se ha beccato i doppioni, una cosa moolto rara
                        if (gotDoubleSome && gotDoubleOne)
                        {
                            player.Punt = basic * 4;
                            critica = 6;
                        }
                    }
                    //altrimenti, si procede con la stessa procedura del numero base
                    else
                    //ciò è fatto in modo da dar priorità al punteggio massimo
                    if (gotDoubleSome)
                    {
                        player.Punt = sumBasic + (float)Math.Truncate(sumBasic / 2);
                        critica = 4;
                    }
                }

                //la critica indica quale file verrà stampato, ogni file avrà tot numeri di alternative, per rendere meno ripetitivi le reazioni
                manager.ChangePath(@"csvsenteces\giocaVince0" + critica + ".csv");
                
                //reazioni in base a quanto ha azzeccato il giocatore
                //Thread.Sleep(meTime);
                if(!manager.StampaTestoCsv(0))
                {
                    return;
                }


                //in caso il giocatore avesse indovinato, li si chiede se vuole rischiare anche solo per vedere cosa aveva l'assistente
                if (player.Punt > 0)
                {
                    //si avvisa di quanti punti ha e del rischio in caso si volesse vedere che cosa hanno i dadi assistenti
                    //Thread.Sleep(meTime);


                    manager.ChangePath(@"csvsenteces\giocaVince.csv");
                    float[] value=[1];
                    value[0] = 3;
                    if (!manager.StampaTestoCsv(0, value))
                    {
                        return;
                    }

                    Console.WriteLine($"(1 per rivelare l'assistente, 2 per tenerti i punti)");


                    reveal = ReplyIntRange("(Ti ho richiesto 1 o 2)", "Unfortunately, non ho altre opzioni", 1, 2);
                    //se accetta il rischio, si dimezza di già il punteggio, il target è solo cò che ha indovinato il giocatore, non i dadi
                    if (reveal == 1)
                    {
                        //Thread.Sleep(meTime);
                        player.Punt = (float)Math.Round(player.Punt / 2);
                        Console.Write($"Ora i tuoi punti stanno a ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //Thread.Sleep(meTime);
                        Console.Write(player.Punt);
                        Console.ResetColor();
                        //Thread.Sleep(meTime);
                        Console.WriteLine($", vediamo se ne sarà valsa la pena\n");
                    }
                }
                //invece se il giocatore non ha preso niente...
                else
                {
                    //si dà il messsaggio per avvisarlo e chiedere se vuole vedere se magari l'assistente li da un qualche punto
                    manager.ChangePath(@"csvsenteces\giocaPerde.csv");
                    if (!manager.StampaTestoCsv(0))
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
                player.AggiungiPunto();



                //ora, questa è l'operazione per i dadi Osperà, che avranno un simile procedimento a prima... probabilmente in futuro creerò un metodo
                if (reveal == 1)
                {
                    //Thread.Sleep(meTime);
                    Console.Write($"Ecco cosa dice ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Osperà");
                    Console.ResetColor();
                    Console.WriteLine($":\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Thread.Sleep(meTime);
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
                    //Thread.Sleep(meTime);

                    //se osperà indovina qualcosa, si avvisa al giocatore di quanto viene aumentato il punteggio
                    if (assPunt > 0)
                    {
                        //Thread.Sleep(meTime);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Osperà");
                        Console.ResetColor();
                        Console.Write(" ti da ");
                        //Thread.Sleep(meTime);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(assPunt);
                        Console.ResetColor();
                        Console.Write(" punti insieme ai tuoi ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(player.Punt);
                        Console.ResetColor();
                        Console.WriteLine(" punti\n");
                    }
                    //altrimenti, niente...
                    else
                    {
                        //Thread.Sleep(meTime);
                        Console.Write("Stavolta ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Osperà");
                        Console.ResetColor();
                        Console.WriteLine(" non è riuscito a trovare niente...\n");
                    }

                    //si aggiunge il punteggio subito stavolta
                    //in futuro però vorrei vedere un modo per ripetere l'utilizzo di Osperà, col costo di punti
                    player.AggiungiPunto(assPunt);
                }



                //si tiene presente al giocatore quanto si ha di punteggio totale
                Console.Write("Il tuo punteggio totale sta a ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.TotPunt}\n");
                Console.ResetColor();

                //randomicamente si avviserà al giocatore quanti punti deve arrivare per vincere
                int warn = 0;
                if (player.TotPunt < vinPunt)
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

            if (player.TotPunt >= vinPunt)
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
            datiSave[5] = player.TotPunt.ToString();
            datiSave[7] = false.ToString();
            File.WriteAllLines(pathSave, datiSave);


            Console.WriteLine("\nVuoi Fare un altra partita?\n(Premi S per si, N per no)");
            end = Accettare("\nAight...", "\nGrazie per aver giocato ad 'Indovina, Osperà'", "Avrei bisogno di sapere se Si o No...", true);
        }
    }
}

public class GestoFile : Funzioni{
    private string textPath;
    //verrà spesso modificato per poter aprire molti file, necessita di una funzione per evitare problemi dei file as well
    public string CurPath {get; set;}
    //serve per leggere dati dal file di testo, di solito ne ha 8 di slot, ogni pari è un identificazione e il dispari il dato
    private List<string> datiSave= new List<string>();
    private List<float> numeri= new List<float>();

    public GestoFile(string path)
    {
        textPath=path;
        CurPath=textPath;
    }
    public void ChangePath(string path)
    {
        CurPath=path;
    }
    public void SetDatoAt(int slot, string dato)
    {
        datiSave[slot] = dato;
    }
    public string GetDatoAt(int slot)
    {
        return datiSave.ElementAt(slot);
    }
    public void ChangeValues(float[] valori)
    {
        numeri.Clear();
        numeri.AddRange(valori);
    }
    public void Salvataggio()
    {
        File.WriteAllLines(CurPath, datiSave);
    }
    public void SalvaTurno(int turno, float punteggiototale, bool wip)
    {
        SetDatoAt(3, turno.ToString());
        SetDatoAt(5, punteggiototale.ToString());
        SetDatoAt(7, wip.ToString());
        Salvataggio();
    }

    public bool StampaTestoCsv(int altern)
    //string path= il percorso del file in stringa, int altern= il numero di appartenenza del testo da stampare, params int[] values= opzionale, un array con delle variabili da stampare
    {
        //diversi trycatch per sapere che tipo di errore è accaduto in tutto ciò
        try
        {
            try
            {
                string[] trova = File.ReadAllLines(CurPath);
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

    public bool StampaTestoCsv(int altern, float[] values)
    //string path= il percorso del file in stringa, int altern= il numero di appartenenza del testo da stampare, params int[] values= opzionale, un array con delle variabili da stampare
    {
        ChangeValues(values);
        //try catch in caso qualche errore accada
        try
        {
            //lettura e copiatura del file: il file deve esistere perchè è necessario per la stampa del testo customizzato
            string[] trova = File.ReadAllLines(CurPath);
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
                    prova[i][0] = numeri.ElementAt(count).ToString();
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
}
public class Regole{
    
}
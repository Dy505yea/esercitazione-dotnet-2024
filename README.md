# esercitazione-dotnet-2024

>Prima esercitazione sul versionamento

- 1 Versione semplice senza class e metody entry point
- 2 Versione con entry point (metodo main static void)



# INSERIMENTO CODICE

Esercitazioni base su c# senza quei namespace

**dotnet new console >> creazione di un progetto console

**dotnet run >> esecuzione di un progetto console

- 01 - Tipi di dato e variabili
- 02 - Operatori
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli
- 06 print and scan

## 01 - Esercitazioni su tipi di dato e variabili:

### 01 - Dichiarare una variabile di tipo stringa:

```c#
class Program
    {
        static void Main(string[] args)
        {
            string nome = "Christian";
            Console.WriteLine($"Ciao {nome}"); //$ è l'interpolazione di stringhe
            Console.WriteLine("Ciao "+nome); //concatenzaione classica
        }
    }
```


### 02 - Dichiarazione di variabili di tipo intero

```c#
class Program
    {
        static void Main(string[] args)
        {
            int eta = 20;
            Console.WriteLine($"Hai {eta} anni"); //$ è l'interpolazione di stringhe
        }
    }
```

    
### 03 - Dichiarazione di variabili di tipo boolean

```c#
class Program
    {
        static void Main(string[] args)
        {
            bool maggior = true;
            Console.WriteLine($"Sei maggiorenne? \n{maggior}"); //$ è l'interpolazione di stringhe
        }
    }
```

    
### 04 - Dichiarazione di variabili di tipo decimal

```c#
class Program
    {
        static void Main(string[] args)
        {
            //nel decimal, il valore necessità della m alla fine per un fattore di codifica
            decimal altezza = 1.80m;
            //se te lo chiedi, lo scopo dei decimal è per essere precisi ed evitare errori di calcolo
            //che potresti incontrare se usassi i double
            Console.WriteLine($"Sei alto {altezza} metri"); //$ è l'interpolazione di stringhe
        }
    }
```
    
    
### 05 - Dichiarazione di variabili di tipo data

```c#
class Program
    {
        static void Main(string[] args)
        {
            //usually, c'è bisogno di una libreria a parte
            DateTime DataDiNascita = new DateTime(1980, 1, 1);
            Console.WriteLine($"Sei nato il {DataDiNascita}"); //$ è l'interpolazione di stringhe
        }
    }
```


### 06 - Dichiarazione di variabili di tipo data e utilizzo del metodo ToShortDateString

```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime DataDiNascita = new DateTime(1980, 1, 1);
            Console.WriteLine($"Sei nato il {DataDiNascita.ToShortDateString()}"); //$ è l'interpolazione di stringhe
            //durante la scrittura, da quando uno mette il ".", li libreria proverà a suggerire un metodo già esistente
            //se provi a scrivere senza digitare il ".", non va più
        }
    }
```


### 07 - Dichiarazione di variabili di tipo data e utilizzo del metodo ToLongDateString

```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime DataDiNascita = new DateTime(1980, 1, 1);
            Console.WriteLine($"Sei nato il {DataDiNascita.ToLongDateString()}"); //$ è l'interpolazione di stringhe
            //a differenza dell'altro, questo dà anche giorno della settimana e nome del mese
        }
    }
```



## 02 - Esercitazioni coi operatori (quel dollaro semplifica di molto nella stampa, per cui ti mando già sul 4)

### 04 - Utilizzare il "+" per sommare 2 interi

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a=10;
            int b=20;
            int c= a + b;
            Console.WriteLine($"Se fai {a} + {b}, il risultato è {c}"); //$ è l'interpolazione di stringhe
        }
    }
```

### 05 - Utilizzare il "+" per sommare 2 interi ed un decimale

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a=10;
            int b=20;
            decimal c= 1.5m;
            decimal d =a+b+c;
            Console.WriteLine($"Se fai {a} + {b} (due interi) + {c} (un decimale), il risultato è {d}"); //$ è l'interpolazione di stringhe
        }
    }
```

### 06 - Utilizzare il == per fare un confronto d'eguaglianza

```c#
class Program
    {
        static void Main(string[] args)
        {
            string nome ="Mario";
            string cognome ="Rossi";
            bool uguali = nome == cognome; //in questo caso, è possibile già assegnare un bool tramite confronto senza dover fare un if
            Console.WriteLine($"I due nomi son uguali? \n{uguali}"); //$ è l'interpolazione di stringhe
        }
    }
```

### 07 - Utilizzare il != per sapere se son diversi

```c#
class Program
    {
        static void Main(string[] args)
        {
            string nome ="Mario";
            string cognome ="Rossi";
            bool diversi = nome != cognome; //in questo caso, è possibile già assegnare un bool tramite confronto senza dover fare un if
            Console.WriteLine($"I due nomi son diversi? \n{diversi}"); //$ è l'interpolazione di stringhe
        }
    }
```

### 08 - Utilizzare il > per confrontare 2 valori

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a=10;
            int b=20;
            bool maggior= a > b;
            Console.WriteLine($"{a} è più grande di {b}?\n{maggior}"); //$ è l'interpolazione di stringhe
        }
    }
```



## 03 - Esercitazioni con strutture di dati

### 01 - Dichiarare un array di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];   //string è di per sé un array di stringhe, ma un array dinamico
            //dal momento che si aggiunge [] subito accanto al tipo, rendendolo un array di array
            //ma, a differenza di string, questo array è predeterminato, quindi necessità di sapere quanto spazio deve essere creato
            nomi[0]="Mario";
            nomi[1]="Luigi";
            nomi[2]="Giovanni";
            Console.WriteLine($"Buonaseeeeera   {nomi[0]}, {nomi[1]}, {nomi[2]}"); //$ è l'interpolazione di stringhe
        }
    }
```

### 02 - Dichiarare un array di interi

```c#
class Program
    {
        static void Main(string[] args)
        {
            int[] numeri= new int[3];
            numeri[0]=7;
            numeri[1]=24;
            numeri[2]=2;
            Console.WriteLine($"I numeri di quest'oggi sono {numeri[0]}, {numeri[2]} e {numeri[1]}"); //$ è l'interpolazione di stringhe
            /*//puoi anche creare altri slot nel mentre, non è necessario di averlo già dall'inizio...
            //però svuota tutti gli elementi
            numeri = new int[4];
            //però svuota tutti gli elementi
            numeri[3]=0;
            Console.WriteLine($"I numeri di quest'oggi sono {numeri[0]}, {numeri[2]} e {numeri[1]}.... perchè hai la biglia n.{numeri[3]} in mano?");*/
        }
    }
```

### 03 - Dichiarare un array di stringhe e utilizzo del metodo lenght

```c#
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];
            nomi[0]="Mario";
            nomi[1]="Luigi";
            nomi[2]="Giovanni";
            Console.WriteLine($"Buonaseeeeera   {nomi[0]}, {nomi[1]}, {nomi[2]}"); //$ è l'interpolazione di stringhe
            Console.WriteLine($"Siete solo in {nomi.Length}?"); //il .Length accanto al nome dell'array, indica quanti elementi son contenuti
        }
    }
```

### 04 - Dichiarare una lista di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            //<> è definito come diamond
            List<string> nomi = new List<string>();
            //ciò che è sottostante son metodi, non più assegnazioni
            nomi.Add("Mario");
            //infatti, gli elementi son inseriti tramite le parantesi, invece di =
            nomi.Add("Luigi");
            nomi.Add("Giovanni");
            Console.WriteLine($"Buonaseeeeera   {nomi[0]}, {nomi[1]}, {nomi[2]}");
        }
    }
```

### 05 - Dichiarare una lista di stringhe e utilizzare il metodo Count

```c#
class Program
    {
        static void Main(string[] args)
        {
            List<string> nomi = new List<string>();
            nomi.Add("Mario");
            nomi.Add("Luigi");
            nomi.Add("Giovanni");
            Console.WriteLine($"Buonaseeeeera   {nomi[0]}, {nomi[1]}, {nomi[2]}");
            Console.WriteLine($"Siete solo in {nomi.Count}?");  //dato che è stato operato tramite metodi
            //la lista non può essere maneggiata normalmente, per sapere quanti elementi ci sono, serve il metodo apposito
        }
    }
```

### 06 - Dichiarare una pila di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            //Una pila è come mettere delle biglie in un tubo su misura: la prima che metti sarà l'ultima che toglierai
            Stack<string> nomi = new Stack<string>();
            nomi.Push("Mario");
            nomi.Push("Luigi");
            nomi.Push("Giovanni");
            //ed esattamente con questo concetto, l'unico modp per printare gli elementi è col seguente metodo
            Console.WriteLine($"Buonaseeeeera   {nomi.Pop()}, {nomi.Pop()}, {nomi.Pop()}"); //in questo caso, le parentesi del metodo son necessarie
            //L'ultimo elemento è il primo a venir fuori
        }
    }
```

### 07 - Dichiarare una coda di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            //Una coda, invece, funziona proprio come al supermercato: il primo che arriva è il primo ad uscire
            Queue<string> nomi = new Queue<string>();
            nomi.Enqueue("Mario");
            nomi.Enqueue("Luigi");
            nomi.Enqueue("Giovanni");
            //proprio come la pila, ha un solo modo per printare
            Console.WriteLine($"Buonaseeeeera   {nomi.Dequeue()}, {nomi.Dequeue()}, {nomi.Dequeue()}"); //in questo caso, le parentesi del metodo son necessarie
            //il primo elemento è il primo ad esser stampato
        }
    }
```

### 08 - Dichiarare un dizionario di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> nomi = new Dictionary <string, string>();
            nomi.Add("Mario", "Rossi");
            nomi.Add("Luigi", "Verdi");
            nomi.Add("Wario", "Gialli");
            Console.WriteLine($"Ecco a voi i tre candidati di oggi: Sr. {nomi["Mario"]}, Sr. {nomi["Luigi"]} e Sr. {nomi["Wario"]}");
        }
    }
```

### 09 - Inizializzazione con elementi predeterminati nelle precedenti strutture di dati

```c#
class Program
    {
        static void Main(string[] args)
        {
            //inizializzazione di 2 tipi d'array
            string[] nomi= new string[] {"Mario", "Giovanni", "Salomone"};
            int[] numeri= new int[] {4, 12, 62, 24, 2};
            
            Console.WriteLine($"Buonasera {nomi[0]}, {nomi[1]}, {nomi[2]}\n");
            Console.WriteLine($"I vostri numeri: {numeri[0]}, {numeri[1]}, {numeri[2]}, {numeri[3]}, {numeri[4]}\n\n");

            //inizializzazione di 2 tipi di liste
            List<int> listaNumeri=new List<int> {8, 21, 444, 12, 90};
            List<string> listaNomi=new List<string> {"Osvaldo", "Enrico", "Tommaso"};
            
            
            Console.WriteLine($"Buonasera {listaNomi[0]}, {listaNomi[1]}, {listaNomi[2]}\n");
            Console.WriteLine($"I vostri numeri: {listaNumeri[0]}, {listaNumeri[1]}, {listaNumeri[2]}, {listaNumeri[3]}, {listaNumeri[4]}\n\n");

            //inizializzione di una pila
            Stack<int> pilaNumeri= new Stack<int> (new int[] {505, 31, 49, 98, 5});
            
            Console.WriteLine($"Ecco numeri i nascosti: {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}, {pilaNumeri.Pop()}\n");

            //inizializzazione di una coda
            Queue<string> codaNomi= new Queue<string> (new string[] {"Dario", "Silvio", "Agata"});
            
            Console.WriteLine($"Sono a nome di {codaNomi.Dequeue()}, {codaNomi.Dequeue()}, {codaNomi.Dequeue()}\n\n");

            //prova vari metodi
            //join
            string allInOne= String.Join(", ", listaNomi);
            
            Console.WriteLine($"Rispondete, {allInOne}\n\n");

            //remove
            Console.WriteLine($"E ora, uno di voi verrà eliminato\nQuelli che rimangono sono...\n\n");
            string why= "Enrico";
            listaNomi.Remove(why);
            string survived= String.Join(",", listaNomi);
            
            Console.WriteLine($"{survived}.\nQuindi tra {allInOne}; {why} sei eliminato, sgomma\n\n");


            //sort
            Console.WriteLine("Vi ricordate come ordinare i numeri?");
            string allOfEm=String.Join(", ", listaNumeri);
            listaNumeri.Sort();
            string orderEm= String.Join(",", listaNumeri);
            
            Console.WriteLine($"\nVi ricordo che avete {allOfEm}\nDovrebbe essere {orderEm}\n\n");

            //dizionario dichiarato senza usare il metodo add
            int ros=12;
            int ver=5;
            int gia=7;
            Dictionary<int, string> posti = new Dictionary <int, string>
            {
                {ros, "Rossi"},
                {ver, "Verdi"},
                {gia, "Gialli"}
            };
            Console.WriteLine($"Il Sr. {posti[ros]} ha il posto {ros}, il Sr. {posti[ver]} ha il posto {ver} ed il Sr. {posti[gia]} ha il posto {gia}");
        }
    }
```


## 04 - Esercitazioni su condizioni

### 01 - Utilizzare l'istruzione if

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a = 10 + 42 / 6 * 2;
            int b = 20 - 54 / 9 + 2 * 3;
            Console.WriteLine($"Fammi vedere che cosa son a e b\nil primo è {a}, mentre il secondo è {b}, avevo puntato 5 crediti sulla seconda operazione");
            if(a>b)
            {
                Console.WriteLine($"Beh, ecco che se ne vanno dalle mie tasche");
            }
            Console.WriteLine($"Intanto non abbiamo manco puntato granchè\n");
        }
    }
```

### 02 - Utilizzare l'istruzione if else

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a = 10 * 3 - 49 / 7 - 108 / 6;
            int b = 20 * 2 + 3 * 6 - 132 / 4;
            Console.WriteLine($"Fammi vedere che cosa son a e b\nil primo è {a}, mentre il secondo è {b}, ho puntato molto sul secondo senza manco leggere bene le operazioni\n");
            if(a>b)
            {
                Console.WriteLine($"Darn, ecco via metà del mio stipendio\n");
            }
            else
            {
                Console.WriteLine($"SONO UN GENIO INCOMPRESO E ORA ANCHE RICCO\n");
            }
        }
    }
```

### 03 - Utilizzare l'istruzione if else-if

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 20;
            Console.WriteLine($"Quindi stavolta i numeri son {a} e {b}");
            if(a>b)
            {
                Console.WriteLine($"Il primo è più grande");
            }
            else if (a<b)
            {
                Console.WriteLine($"Il secondo è più grande");
            }
            else
            {
                Console.WriteLine($"Che coincidenza, son uguali");
            }
            Console.WriteLine($"Da molto che non giocavo a questo gioco di dadi");
        }
    }
```

### 04 - Utilizzare l'istruzione switch - case

```c#
class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Console.WriteLine($"Quindi stavolta i numeri son {a} e {b}");
            switch(a)
            {
                case 10:
                    Console.WriteLine($"As the godfather intended");
                    break;
                case 20:
                    Console.WriteLine($"Temo di vedere cose");
                    break;
                case 30:
                    Console.WriteLine($"Ma non c'era manco questo numero prima");
                    break;
            }
            Console.WriteLine($"Un giorno ti insegnerò a immaginare numeri casuali invece dei soliti multipli di 10");
        }
    }
```



## 05 - Esercitazioni coi cicli

### 01 - Utilizzare l'istruzione while

```c#
class Program
    {
        static void Main(string[] args)
        {
            int i=1;
            int subject=16;
            Console.WriteLine($"Fammi contare almeno dopo il 2, poi ti dico cosa può già dividere il numero {subject}");
            while((subject%i)!=0||i<=2)
            {
                if(i==1)
                    Console.WriteLine($"{i} sasso");
                else
                    Console.WriteLine($"{i} sassi");
                Console.WriteLine($"Passo\n");
                i++;
            }
            Console.WriteLine($"Per dividere il numero {subject}, va bene il numero {i}");
        }
    }
```

### 02 - Utilizzare l'istruzione do-while

```c#
class Program
    {
        static void Main(string[] args)
        {
            int i=0;
            int subject=16;
            Console.WriteLine($"Fammi contare almeno dopo il 2, poi ti dico cosa può già dividere il numero {subject}\n");
            do
            {
                if(i==1)
                    Console.WriteLine($"{i} sasso");
                else
                    Console.WriteLine($"{i} sassi");
                Console.WriteLine($"Passo\n");
                i++;
            }while((subject%i)!=0||i<=2);
            //La differenza principale è che il controllo viene fatto alla fine del pezzo invece che all'inizio
            Console.WriteLine($"Per dividere il numero {subject}, va bene il numero {i}");
        }
    }
```

### 03 - Utilizzare l'istruzione for

```c#
class Program
    {
        static void Main(string[] args)
        {
            int limite=108;
            int contatore= 0;
            int moltiplicato=1;
            Console.WriteLine($"Non so quanto uno può moltiplicare il 2 per se stesso fino a raggiungere 108, fammi provare");
            for(int i = 0; moltiplicato<limite; i++)
            {
                Console.WriteLine($"Sono a {moltiplicato}, moltiplicato {i} volte");
                moltiplicato*=2;
                contatore=i;
            }
            Console.WriteLine($"Per raggiungere 108, ho dovuto moltiplicare {contatore} volte, arrivando a {moltiplicato}");
        }
    }
```

### 04 - Utilizzare l'istruzione foreach con un array di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi=new string[] {"Mario", "Luigi", "Giorgio"};
            foreach(string nome in nomi)
            {
                Console.WriteLine($"Ciao {nome}");
            }
        }
    }
```

### 05 - Utilizzare l'istruzione foreach con una lista di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            List<string> nomi=new List<string>();
            nomi.Add("Rossi");
            nomi.Add("Luigi");
            nomi.Add("Lorenzo");
            foreach(string nome in nomi)
            {
                Console.WriteLine($"Ciao {nome}");
            }
        }
    }
```

### 05 BONUS - Esercizio: ricerca di un nome e posizione di detta occorrenza

```c#
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
            //ciclo foreach nell'array, letto è ciò che ritorna per ogni elemento
            foreach(string letto in nomi)
            {
                //se l'abbiamo stanato
                if(letto==wanted)
                {
                    //aumenta il contatore
                    conta++;
                    //aggiungiamo il nome
                    laLista.Add(letto);
                    //e lo mettiamo nel dizionario con il posto in cui sta
                    numeralo.Add(pos, letto);
                }
                //prossima linea
                pos++;
            }
            Console.WriteLine($"Trovato {wanted} {conta} volta/e");
            //ciclo per stampare un messaggio semplice semplice
            foreach(int chiave in numeralo.Keys)
            {
                //chiave è il corrente key che si sta leggendo in tutto il dizionario
                Console.WriteLine($"Nella linea {chiave}, è stato rilevato {numeralo[chiave]}");
                //numeralo[chiave] è il corrente value di suddetta key
            }
        }
    }
```

### 06 - Utilizzare l'istruzione while con array di stringhe

```c#
class Program
    {
        static void Main(string[] args)
        {
            string[] nomi= new string[3];
            nomi[0]= "Mario";
            nomi[1]="Luigi";
            nomi[2]="Lorenzo";
            int i=0;
            while(i<nomi.Length)    //.Length è il numero di celle dellì'array
            {
                Console.WriteLine($"Ciao {nomi[i]}");
                i++;
            }
        }
    }
```

### 06 malus - Versione con la lista

```c#
class Program
    {
        static void Main(string[] args)
        {
            List<string> nomi=new List<string>();
            nomi.Add("Rossi");
            nomi.Add("Luigi");
            nomi.Add("Lorenzo");
            int i=0;
            while(i<nomi.Count)
            {
                Console.WriteLine($"Ciao {nomi[i]}");
                i++;
            }
        }
    }
```

## 06 - Piccole prove con WriteLine e ReadLine

### 01 - Write e WriteLine

```c#
class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Salve ");
            Console.Write("Come va? \n");
            //\n serve per indicare che si vuole andare a capo
            Console.WriteLine("Salve ");
            Console.WriteLine("Come va? \n");
            //WriteLine ti mette a capo automaticamente
        }
    }
```

### 02 - ReadLine e ReadKey

```c#
class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine($"Come ti chiami?");
           //anche se ritorna come stringa, viene considerato come null di per se, triggerando un warning
           string? nome= Console.ReadLine();
           //aggiungendo un ? accanto a string, si avvisa alla macchina d'esser coscienti di ciò
           Console.WriteLine($"{nome}... Quanti hanni hai?");
           //dato che ReadLine è puramente di tipo string, c'è bisogno di una conversione per ottenere il valore numerico
           int eta=Convert.ToInt32(Console.ReadLine());
           Console.WriteLine($"{nome}... premi da qualche parte per andartene");
           //a differenza dell'altro, il redkey non necessità di un invio, prenderà qualsiasi chiave tu tocchi quando arriva alla funzione
           Console.ReadKey();
        }
    }
```

### 02 BONUS - ReadLine col ciclo d'array

```c#
class Program
    {
        static void Main(string[] args)
        {
            int i=0;
            Console.Write("mi puoi dire quanti ne vuoi\n");
            //la conversione è necessaria per leggere i valori numerici
            i=Convert.ToInt32(Console.ReadLine());
            //probabilmente ti darà un warning
            string[] nomi= new string[i];
            Console.WriteLine($"Scrivi {i} nomi:\n");
            //è consigliabile fare proprio un altra variabile diversa, ma per me va bene così
            i=0;
            while(i<nomi.Length)
            {
                Console.WriteLine($"nome numero {i+1}");
                nomi[i]=Console.ReadLine();
                i++;
            }
            //forse persino un altro tipo di ciclo, for, almeno fa una variabile che si cancella alla fine
            i=0;
            Console.WriteLine($"Fammi controllare un attimo, leggi:\n");
            while(i<nomi.Length)
            {
                Console.WriteLine($"Ciao {nomi[i]}");
                i++;
            }
        }
    }
```

### 03 - Fermare il programma da ReadKey

```c#
class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine($"Fermami con N se ci riesci");
           //ricorda, il while(true) ha il potenziale di bloccare un intero programma, necessita di un modo di fermarsi nel mentre
           while(true)
           {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if(keyInfo.Key==ConsoleKey.N)
                {
                    Console.WriteLine($"darn...");
                    break;
                }
           }
        }
    }
```

### 04 - Fermare il programma da ReadKey con una combinazione (ctrl + n)

```c#
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
```

## 07 Linee di codici sparsi

### 01 Menù

```c#
class Program
{
    static void Main(string[] args)
    {
        //Console.BackgroundColor = ConsoleColor.DarkCyan;
        while (true)
        {
            Console.Clear(); // Pulisce la console ad ogni iterazione
            //come se non c'avesse scritto niente
            Console.WriteLine("Menu");
            Console.WriteLine("1. (:");
            Console.WriteLine("2. /:");
            Console.WriteLine("3. D:");
            Console.WriteLine("4. Esci");

            Console.Write("Inserisci il numero dell'opzione desiderata: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Risultato ottimale nei PE box");
                    // Aggiungi qui la logica per l'Opzione Uno
                    break;
                case "2":
                    Console.WriteLine("Risultato un pò meh, quasi quasi rischi di scatenare un anormalità");
                    // Aggiungi qui la logica per l'Opzione Due
                    break;
                case "3":
                    Console.WriteLine("Preaparati, abbiamo un anormalità da sopprimere");
                    // Aggiungi qui la logica per l'Opzione Tre
                    break;
                case "4":
                    Console.WriteLine("Dov'è più il tasto per resettare la giornata?!?");
                    return; // Esce dal programma
                default:
                    Console.WriteLine("-_-");
                    break;
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(); // Aspetta che l'utente prema un tasto prima di continuare
        }
    }
}
```

### 02 Riproduzione di una command line molto scheletrica

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        Console.WriteLine("inizio di un programma\nCome te chiami?\n");
        string? te = Console.ReadLine();
        int tenta = 3;
        bool token = false;
        string tonta = "";
        string pass = "spider";
        Console.WriteLine($"(Pss... la password è {pass} ;|\n");
        while (true)
        {
            if (token)
            {
                Console.WriteLine("sei dentro\n");
                string? input = Console.ReadLine();
                Console.Write("\n");
                if (input.StartsWith("cmd: "))
                {
                    string comando = input.Substring(5);
                    switch (comando.ToLower())
                    {
                        case "info":
                            Console.WriteLine("Non ho informazioni ._ .");
                            break;
                        case "name":
                            Console.WriteLine($"M'hai detto che te chiamavi {te}");
                            break;
                        case "exit":
                            Console.WriteLine("Addios");
                            return;
                        default:
                            Console.WriteLine("Ma che me scrivi?\nSenti, dato che te non sai na ceppa, ecco a te i comandi:\n\ninfo\nname\nexit\nreprovaci\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("E che vuoi che faccia se non mi dai un comando?!? (per la cronaca, ho solo 'cmd:')");
                }
                Console.WriteLine("*sorseggia il caffè*\n");
            }
            else
            {
                if (tenta > 0)
                {
                    Console.WriteLine("se c'hai, passa qui il codice");
                    tonta = Console.ReadLine();
                    if (tonta == pass)
                    {
                        token = true;
                    }
                    else
                    {
                        tenta--;
                        Console.WriteLine($"{tonta} è sbagliato\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Hai finito i tentativi, vatte da qui intruso");
                    return;
                }
            }
        }
    }
}
```

### 03 Try Catch coi file

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        Console.WriteLine("Trascina un file qui e premi Invio:");
        string filePath=Console.ReadLine().Trim('"'); //toglie le virgolette che possono apparire nel percorso

        try
        {
            string content=File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file:");
            Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            Console.WriteLine("C'è stato un problema: {ex. Message}");
        }
    }
}
```

### 04 Gestione del tempo (task)

```c#
class Program
{
    static async Task Main(string[] args)
    {
        int timeoutSeconds=5;   //tempo di attesa di 5 secondi

        //oggetto task, probabilkmente per creare un mini thread tramite .Run(()=>{});
        Task inputTask= Task.Run(()=>
        {
            //Questo minithread si occupa solo di prendere in input qualsiasi cosa, usando variabili dal thread principale
            Console.WriteLine($"Metti n'input entro {timeoutSeconds} secondi:");
            //finisce il momento in cui si prema invio
            return Console.ReadLine();
        });
        //il .Delay è per aprire una task dopo x tempo, in sto caso si chiama delayTask
        Task delayTask= Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

        //ricorda, await necessita di essere asincrono, quindi modificare lo static di inizio
        //con "static async Task main(string[] args)
        if(await Task.WhenAny(inputTask, delayTask)==inputTask)
        //comunque, await fa attendere l'if che una task finisca, in sto caso .WhenAny, una qualsiasi task che finisca per prima
        {
            //se inputTask (quello che attende un input) finisce prima della task ritardata (delayTask, che non ha niente da eseguire, per cui già torna subito)
            //allora .WhenAny ritornerà ciò che ha inputTask (e dato che allora diviene inputTask==inputTask, diverrà vero)
            string input= await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");
        }
        else
        {
            //altrimenti, il momento in cui viene avviato delayTask, .WhenAny diverrà ciò, comparando allora delayTask==inputTask
            Console.WriteLine("\nTempo scaduto...");
        }
    }
}
```

### 05 Gestione del tempo (downgrade)

```c#
class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds=5;
        Console.WriteLine($"Metti stop input in {timeoutInSeconds} secondi");
        bool inputReceived=false;
        string? input="";
        //classe riguardo alle date ed ore
        //endtime si scriverà tutto, now è per dire che deve scrivere il momento corrente, addseconds è per aggiungere secondi
        //rispetto all'ora attuale
        DateTime endTime=DateTime.Now.AddSeconds(timeoutInSeconds);
        //controlla che il tempo sia ancora minore a quanto scritto
        while(DateTime.Now<endTime)
        {
            //il momento in cui è vero, è il momento in cui sa che è stato premuto qualcosa
            //ma il problema è che non lo fa in tempo reale dal momento in cui l'input ancora non ha replicato ciò che hai inviato
            if(Console.KeyAvailable)
            {
                input=Console.ReadLine();
                //il token viene attivato no metter what
                inputReceived=true;
                break;
            }
        }
        //principalmente per una questione di cpu
        //Thread.Sleep(100);
        //da qui vede se l'input ha effettivamente qualcosa, tramite token
        if(inputReceived)
        {
            Console.WriteLine($"Hai inserito {input}");
        }
        else
        {
            Console.WriteLine($"You're really pathetic");
        }
        /*
        La ragione per preferire la classe task e i suoi metodi è proprio perchè, grazie alla asincronia, si evita il caso in cui
        L'utente fermi il programma solo per aver messo un tasto per qualsiasi motivo, mentre in multithread c'è bisogno anche dell'invio
        Per confermare che hai messo qualcosa
        */
    }
}
```

### 05 Classe random

```c#
class Program
{
    static void Main(string[] args)
    {
        //guess stavolta si guarderà ai random

        //prima ancora di usarlo, bisogna dichiarare una variabile random
        Random ran=new Random();
        int somma=0;
        Console.WriteLine($"Farò una somma di 10 numeri casuali\n");
        //facciamo un ciclino da 10
        for(int i=0; i<10; i++)
        {
            //il metodo .Next prenderà un numero tra numero A come, minimo, e numero B-1, come massimo
            int x=ran.Next(1, 11);
            //quindi in questo caso tra 1 e 10 (non 11)
            Console.WriteLine($"{i+1}° numero: {x}");
            //giusto per vedere cosa è uscito
            somma+=x;
        }
        Console.WriteLine($"\nLa somma è venuta {somma}");
    }
}
```

### 06 Diversi comandi

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        int i=0;
        while(true)
        {
            Console.WriteLine("Hai 3 opzioni:\n\n-1 Per fare na piccola prova col cursore\n-2 Per pulire la console\n-3 per beepare\n-4 titolo");
            i= Convert.ToInt32(Console.ReadLine());
            if(i<5&&i>0)
            {
                break;
            }
        }
        Console.Title="Na piccola provetta";
        string titolo=Console.Title;
        switch(i)
        {
            case 1:
                Console.CursorVisible=false;
                Console.WriteLine("Dimmi quando vuoi fermarti pigiando qualsiasi cosa");
                Console.ReadKey();
                Console.CursorVisible=true;
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Tutto pulito");
                break;
            case 3:
                Console.Beep();
                Console.Beep(750, 300);
                Console.WriteLine($"Fatto");
                break;
            case 4:
                Console.WriteLine($"{titolo}");
                break;
        };
    }
}
```
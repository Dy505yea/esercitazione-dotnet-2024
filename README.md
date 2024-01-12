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
            //pare che l'if mandi a capo automaticamente il print
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
            //ciclo foreach nell'array, letto è ciò che ritorna per orgni elemento
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
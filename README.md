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

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>


### 02 - Dichiarazione di variabili di tipo intero

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

    
### 03 - Dichiarazione di variabili di tipo boolean

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

    
### 04 - Dichiarazione di variabili di tipo decimal

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>
    
    
### 05 - Dichiarazione di variabili di tipo data

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>


### 06 - Dichiarazione di variabili di tipo data e utilizzo del metodo ToShortDateString

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>


### 07 - Dichiarazione di variabili di tipo data e utilizzo del metodo ToLongDateString

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>


## 02 - Esercitazioni coi operatori (quel dollaro semplifica di molto nella stampa, per cui ti mando già sul 4)

### 04 - Utilizzare il "+" per sommare 2 interi

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 05 - Utilizzare il "+" per sommare 2 interi ed un decimale

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 - Utilizzare il == per fare un confronto d'eguaglianza

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 07 - Utilizzare il != per sapere se son diversi

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 08 - Utilizzare il > per confrontare 2 valori

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>



## 03 - Esercitazioni con strutture di dati

### 01 - Dichiarare un array di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 - Dichiarare un array di interi

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 03 - Dichiarare un array di stringhe e utilizzo del metodo lenght

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 04 - Dichiarare una lista di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 05 - Dichiarare una lista di stringhe e utilizzare il metodo Count

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 - Dichiarare una pila di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 07 - Dichiarare una coda di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 08 - Dichiarare un dizionario di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 09 - Inizializzazione con elementi predeterminati nelle precedenti strutture di dati

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 10 - Metodo Distinct() in una lista di strnighe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Proviamo a vedere come si tolgono le ripetizioni:\n");
        //lista di stringhe per prova, funge anche con valori di diverso tipo
        List<string> prova=new List<string>{"Pc", "Cv", "Sy", "Pc", "Pc", "Sy", "Tv"};
        Console.WriteLine($"La lista ha: {string.Join(", ", prova)}\nOra vedrò di togliere i doppioni");
        //Metodo per togliere doppioni, in questo caso dalla lista stessa
        prova=prova.Distinct().ToList();
        Console.WriteLine($"Ora la lista ha: {string.Join(", ", prova)}\n\nSpero di aver fatto ciò che volevi");
    }
}
```
</pre>
</details>

### 11 - Metodo Sort() in una lista di interi

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Ti farò un riordinamento di robe a caso:\n");
        //classe random per casualità
        Random ran= new Random();
        //lista di prova per questa dimostrazione
        List<int> prova= new List<int>();
        //mettiamo 10 elementi da riordinare
        for(int i=0; i<10; i++)
        {
            prova.Add(ran.Next(0, 11));
            //stampa di cosa è uscito
            Console.Write($"{prova[i]}, ");
        }
        //riordinamento
        Console.Write($"\n\nOra lo riordino:\n");
        //basta solo richiamare il metodo, dal minore al maggiore
        prova.Sort();
        Console.WriteLine($"{string.Join(", ", prova)}");
        Console.WriteLine($"\nHopefully, tutto è andato come voluto");
    }
}
```
</pre>
</details>


## 04 - Esercitazioni su condizioni

### 01 - Utilizzare l'istruzione if

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 - Utilizzare l'istruzione if else

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 03 - Utilizzare l'istruzione if else-if

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 04 - Utilizzare l'istruzione switch - case

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>



## 05 - Esercitazioni coi cicli

### 01 - Utilizzare l'istruzione while

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 - Utilizzare l'istruzione do-while

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 03 - Utilizzare l'istruzione for

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 04 - Utilizzare l'istruzione foreach con un array di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 05 - Utilizzare l'istruzione foreach con una lista di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 05 BONUS - Esercizio: ricerca di un nome e posizione di detta occorrenza

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 - Utilizzare l'istruzione while con array di stringhe

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 malus - Versione con la lista

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 - Liste con ToString e stampa su Join

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Tempo di provare a fare na selezione:\n");
        //lista di nomi
        List<string> values= new List<string>{};
        for(int i=0; i<10; i++)
        {
            int l=i+1;
            //conversione valore intero in stringa per la lista di stringhe
            values.Add(l.ToString());
            //debug
            Console.WriteLine($"siamo a {l}");
        }
        //string.Join() serve per scrivere tutti gli elementi in stringa di una lista direttamente dove hai messo
        Console.WriteLine($"\nFammi vedere se riesco a dirti in modo ordinato quei numeri:\n- {string.Join("\n- ", values)}");
        //il primo parametro è cosa metterci come testo tra le atringhe stampate, il secondo è la lista da cui prendere gli elementi
    }
}
```
</pre>
</details>

## 06 - Piccole prove con WriteLine e ReadLine

### 01 - Write e WriteLine

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 - ReadLine e ReadKey

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 BONUS - ReadLine col ciclo d'array

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 03 - Fermare il programma da ReadKey

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 04 - Fermare il programma da ReadKey con una combinazione (ctrl + n)

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

## 07 Persistenza dei dati

### 01 Lettura e stampa del contenuto del file txt

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string[] lines=File.ReadAllLines(path);//legge tutte le linee separatamente, mettendole in un array
        foreach(string lin in lines)
        {
            Console.WriteLine(lin);//con line, ti stampa come dovresti leggerlo da file, altrimenti tutto attaccato
        }
    }
}
```
</pre>
</details>

### 02 cose txtose

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string[] lines=File.ReadAllLines(path);//legge tutte le linee separatamente, mettendole in un array
        foreach(string lin in lines)
        {
            Console.WriteLine(lin);//con line, ti stampa come dovresti leggerlo da file, altrimenti tutto attaccato
        }
    }
}
```
</pre>
</details>

### 03 diversi modi per trovare una linea che inizia per una lettera

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool trova=false;
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        string[] nomi= new string[lines.Length];                //viene inizializzato con la stessa grandezza per poter fare una copia completa
        string iniz="i";                                        //per ora, volevo metterlo come variabile solo per non doverlo modificare più volte nel codice
        string oniz=iniz.ToUpper();                             //servirà per evitare di ignorare in caso il 
        for(int i=0; i<lines.Length; i++)
        {
            nomi[i]=lines[i];   //niente, è solo na copia del file
        }
        foreach(string lin in lines)
        {
            //con WriteLine, ti stampa come dovresti leggerlo da file, altrimenti sarebbe tutto attaccato
            Console.WriteLine(lin);
        }
        Console.WriteLine("\nNow, te mostro cosa ho trovato con quella condizione:\n");

        //Il seguente foreach contiene la versione più classica per la stampa condizionata
        //*
        foreach(string lin in nomi)
        {
            //se vuoi che ti dica ignorando gli spazi, metti il seguente
            string linea=lin;
            //toglie gli spazi
            //linea=lin.Trim();
            //oltre alla lettera iniziale, ho voluto aggiungere anche la versione maiuscola considerando che magari uno cerca indipendentemente
            if(linea.StartsWith(iniz)||linea.StartsWith(oniz))//da come è stato scritto il carattere
            {
                Console.WriteLine(lin);//con line, ti stampa come dovresti leggerlo da file, altrimenti tutto attaccato
                //il token viene attivato, indicando che almeno una linea è stata trovata con la condizione
                trova=true;
            }
        }
        /*/

        //Mentre in questo si compara da carattere anziché da da stringa
        /*
        foreach(string lin in nomi)
        {
            //se vuoi che ti dica ignorando gli spazi, metti il seguente
            string linea=lin;
            //toglie gli spazi
            //linea=lin.Trim();
            //dato che iniz è una stringa, qui necessitiamo di un charattere invece
            char cerca=iniz[0];
            if(linea[0]=='i')
            {
                Console.WriteLine(lin);//con line, ti stampa come dovresti leggerlo da file, altrimenti tutto attaccato
                trova=true;
            }
        }
        */
        //messaggio in cui non si riesca a trovare una linea che inizia come vuoi
        /*ya gotta study this lambda
        if(!nomi.Any(nome=>nome.StartsWith("a")))
        {
            Console.WriteLine("Beh,,,,,,,,,,,, è strano vedere => qualcosa");
        }
        */
        if(!trova)
        {
            Console.WriteLine("Guess non ho trovato niente che te cercavi");
        }
    }
}
/*
class Program
{
    static void Main(string[] args)
    {
        string[] lines= new string[0];
        Console.Clear();
        try{
        string path=@"test.txt";
        lines=File.ReadAllLines(path);
        }
        catch
        {
            Console.WriteLine("Non riesco a leggere l'inesistente\nO almeno non ho trovato il file dove mi hai detto te");
        }
        foreach(string lin in lines)
        {
            Console.WriteLine(lin);
        }
    }
}
*/
```
</pre>
</details>

### 04 creare un file txt usando un altro txt come contenuto

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool trova=false;
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string pathFin=@"..\esercitazione02\la provetta\kricko.txt";

        var sos=File.Create(pathFin);
        sos.Close();

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        string[] nomi= new string[lines.Length];                //viene inizializzato con la stessa grandezza per poter fare una copia completa
        string iniz="i";                                        //per ora, volevo metterlo come variabile solo per non doverlo modificare più volte nel codice
        string oniz=iniz.ToUpper();                             //servirà per evitare di ignorare in caso il 
        for(int i=0; i<lines.Length; i++)
        {
            nomi[i]=lines[i];   //niente, è solo na copia del file
        }
        foreach(string lin in lines)
        {
            //con WriteLine, ti stampa come dovresti leggerlo da file, altrimenti sarebbe tutto attaccato
            Console.WriteLine(lin);
        }
        Console.WriteLine("\nNow, te mostro cosa ho trovato con quella condizione:\n");

        //Il seguente foreach contiene la versione più classica per la stampa condizionata
        foreach(string lin in nomi)
        {
            //se vuoi che ti dica ignorando gli spazi, metti il seguente
            string linea=lin;
            //toglie gli spazi
            //linea=lin.Trim();
            //oltre alla lettera iniziale, ho voluto aggiungere anche la versione maiuscola considerando che magari uno cerca indipendentemente
            if(linea.StartsWith(iniz)||linea.StartsWith(oniz))//da come è stato scritto il carattere
            {
                File.AppendAllText(pathFin, lin);
                Console.WriteLine(lin);//con line, ti stampa come dovresti leggerlo da file, altrimenti tutto attaccato
                //il token viene attivato, indicando che almeno una linea è stata trovata con la condizione
                trova=true;
            }
        }
        if(!trova)
        {
            Console.WriteLine("Guess non ho trovato niente che te cercavi");
        }
    }
}
```
</pre>
</details>

### 05 selezione casuale di una linea e stampa di essa

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        Random ran= new Random();
        int indx= ran.Next(lines.Length);
        Console.WriteLine($"{lines[indx]}");
    }
}
```
</pre>
</details>

### 06 selezione casuale di una linea e scrittura su un file esterno

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        Random ran= new Random();
        int indx= ran.Next(lines.Length);
        Console.WriteLine($"{lines[indx]}");
        string pathFin=@"..\esercitazione02\la provetta\kricko.txt";
        File.Create(pathFin).Close();
        File.AppendAllText(pathFin, lines[indx]+"\n");
    }
}
```
</pre>
</details>

### 07 aggiunta di una linea di testo solo se non ripetuta

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string pathFin=@"..\esercitazione02\la provetta\kricko.txt";

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        Random ran= new Random();
        int indx= ran.Next(lines.Length);
        Console.WriteLine($"{lines[indx]}");
        if(!File.Exists(pathFin))           //creazione del file solo in caso non esistesse di già
            File.Create(pathFin).Close();   //serve per non riscrivere tutto il testo dall'inizio
        if(!File.ReadAllLines(pathFin).Contains(lines[indx]))   //controllo se la linea di testo non è già scritta
            File.AppendAllText(pathFin, lines[indx]+"\n");
        else
            Console.WriteLine("Frase già inserita");
    }
}
```
</pre>
</details>

### 08 Lettura e stampa del contenuto del file csv, usando il separatore

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        string[] lines=File.ReadAllLines(path);//a differenza di un file di testo, pare che ogni linea sia un array, generando quindi una matrice invece di un solo array
        string[][] nomi= new string[lines.Length][];//per questo motivo, per copiare il testo, si necessita di una matrice di string
        for(int i=0; i<lines.Length; i++)
        {
            nomi[i]=lines[i].Split("|");//uno può utilizzare ciò che vuole, ma è alquanto importante decidere cosa usare per via della memoria usata per lo split in base al carattere
        }
        foreach(string[] nome in nomi)
        {
            foreach(string n in nome)
            {
                Console.Write(n+" ");
            }
            Console.WriteLine();
        }
    }
}
```
</pre>
</details>

### 09 creazione di altri file csv da uno singolo, usando il separatore per crearli

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        string[] lines=File.ReadAllLines(path);//a differenza di un file di testo, pare che ogni linea sia un array, generando quindi una matrice invece di un solo array
        string[][] nomi= new string[lines.Length][];//per questo motivo, per copiare il testo, si necessita di una matrice di string
        for(int i=0; i<lines.Length; i++)
        {
            nomi[i]=lines[i].Split("|");//uno può utilizzare ciò che vuole, ma è alquanto importante decidere cosa usare per via della memoria usata per lo split in base al carattere
        }
        foreach(string[] nome in nomi)
        {
            string path2=@"..\esercitazione01\provadicsv\"+nome[0]+".csv";
            File.Create(path2).Close();
            for(int i=1; i<nome.Length; i++)
            {
                File.AppendAllText(path2, nome[i]+"\n");
            }
        }
        //File.Delete("nome.csv");
    }
}
```
</pre>
</details>

### 10 inserimento di una serie di nomi, cognomi ed età

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        if(!File.Exists(path))           //creazione del file solo in caso non esistesse di già
            File.Create(path).Close();   //serve per non riscrivere tutto il testo dall'inizio
        while(true)
        {
            Console.WriteLine("Dimmi nome, cognome ed età");
            string nome= Console.ReadLine();
            string cognome= Console.ReadLine();
            string etas= Console.ReadLine();
            File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
            Console.WriteLine("Dimmi se vuoi finirla con N, altrimenti continuo");
            string reply=Console.ReadLine();
            if(reply=="n")
            {
                break;
            }
        }
    }
}
```
</pre>
</details>

### 11 inserimento di una serie di nomi, cognomi ed età che non son presenti

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        if(!File.Exists(path))           //creazione del file solo in caso non esistesse di già
            File.Create(path).Close();   //serve per non riscrivere tutto il testo dall'inizio
        while(true)
        {
            Console.WriteLine("Dimmi nome, cognome ed età");
            string nome= Console.ReadLine();
            string cognome= Console.ReadLine();
            string etas= Console.ReadLine();
            string[] lines=File.ReadAllLines(path);
            bool found=false;
            foreach(string lin in lines)
            {
                if(lin.StartsWith(nome))
                {
                    found=true;
                    break;
                }
            }
            if(!found)
                File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
            else
                Console.WriteLine("There's nothing we can do...");
            Console.WriteLine("Dimmi se vuoi finirla con N, altrimenti continuo");
            string reply=Console.ReadLine();
            if(reply=="n")
            {
                break;
            }
        }
    }
}
```
</pre>
</details>

### 12 modifica di una linea se ha lo stesso nome imesso da input

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        if(!File.Exists(path))           //creazione del file solo in caso non esistesse di già
            File.Create(path).Close();   //serve per non riscrivere tutto il testo dall'inizio
        while(true)
        {
            Console.WriteLine("Dimmi nome, cognome ed età");
            string nome= Console.ReadLine();
            string cognome= Console.ReadLine();
            string etas= Console.ReadLine();
            if(!File.ReadAllLines(path).Any(line=>line.StartsWith(nome)))
            {
                File.AppendAllText(path, nome+","+cognome+","+eta+"\n");
            }
            else
            {
                string[] lines=File.ReadAllLines(path);
                string[][] nomi=new string[lines.Length][];
                for(int i=0; i<lines.Length;i++)
                {
                    nomi[i]=lines[i].Split(',');
                }
                for(int i=0; i<nomi.Length;i++)
                {
                    if(nomi[i][0]==nome)    //se nome già presente
                    {
                        nomi[i][2]=eta;     //età aggiornata
                    }
                }
                File.Delete(path);
                File.Create(path).Close();
                foreach(string[] n in nomi)
                {
                    File.AppendAllText(path, n[0]+","+nomi[1]+","+nomi[2]+"\n");
                }
            }
            Console.WriteLine("Dimmi se vuoi finirla con N, altrimenti continuo");
            string reply=Console.ReadLine();
            if(reply=="n")
            {
                break;
            }
        }
    }
}
```
</pre>
</details>

### 13 gestione file: si controlla che file ha la cartella, si stampa cosa c'è e si legge cosa l'utente digita

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
        foreach(string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WrtieLine("Che file me fai legge?");
        string fileScelto=Console.ReadLine()!;
        string[] lines=File.ReadAllLines(fileScelto);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
```
</pre>
</details>

### 14 si controlla che file ha la cartella, si stampa cosa c'è e si elimina il file voluto da utente

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
        foreach(string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WrtieLine("Che file me fai brucià?");
        string fileScelto=Console.ReadLine()!;
        if(File.Exists(fileScelto))
        {
            File.Delete(fileScelto);
        }
        else
        {
            Console.WriteLine("Non c'è sta quel coso, capoh");
        }
    }
}
```
</pre>
</details>

### 15 si controlla che file ha la cartella, si stampa cosa c'è e si legge cosa l'utente digita.... se esiste

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
        foreach(string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WrtieLine("Che file me fai legge");
        string fileScelto=Console.ReadLine()!;
        if(File.Exists(fileScelto))
        {
            string[] lines=File.ReadAllLines(fileScelto);
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Non c'è sta quel coso, capoh");
        }
    }
}
```
</pre>
</details>

### 16 si controlla che file ha la cartella, si stampa cosa c'è e si legge cosa l'utente digita.... se esiste

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
        foreach(string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WrtieLine("Che vuoi fa?\nLegge (invia L) o Elimina (invia E)");
    BruciaOLeggi:
        string reply=console.ReadLine();
        if(reply.ToLower()=="l")
        {
            Console.WrtieLine("Che file me fai legge?");
            string fileScelto=Console.ReadLine()!;
            if(File.Exists(fileScelto))
            {
                string[] lines=File.ReadAllLines(fileScelto);
                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File non presente");
            }
        }
        else if(reply.ToLower()=="e")
        {
            Console.WrtieLine("Che file me fai brucià?");
            string fileScelto=Console.ReadLine()!;
            if(File.Exists(fileScelto))
            {
                File.Delete(fileScelto);
            }
            else
            {
                Console.WriteLine("File non presente");
            }
        }
        else
        {
            Console.WriteLine("So un pò stupido, non so che vuoi se non mi dici l o e\nRiscrivi");
            goto BruciaOLeggi;
        }
    }
}
```
</pre>
</details>

### 17 si controlla che file ha la cartella, si stampa cosa c'è e si legge cosa l'utente digita.... se esiste

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
        foreach(string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WrtieLine("Che vuoi fa?\nLegge (invia L) o Elimina (invia E)");
    BruciaOLeggi:
        string reply=console.ReadLine();
        if(reply.ToLower()=="l")
        {
            Console.WrtieLine("Che file me fai legge?");
            string fileScelto=Console.ReadLine()!;
            try
            {
                string[] lines=File.ReadAllLines(fileScelto);
                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch
            {
                Console.WriteLine("File non presente");
            }
        }
        else if(reply.ToLower()=="e")
        {
            Console.WrtieLine("Che file me fai brucià?");
            string fileScelto=Console.ReadLine()!;
            try
            {
                File.Delete(fileScelto);
            }
            catch
            {
                Console.WriteLine("File non presente");
            }
        }
        else
        {
            Console.WriteLine("So un pò stupido, non so che vuoi se non mi dici l o e\nRiscrivi");
            goto BruciaOLeggi;
        }
    }
}
```
</pre>
</details>

### 18 file JSON

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
//necessita di un package specifico per essere usato appieno
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\somucheffortfornothing.json";
        string json=File.ReadAllText(path);
        //dynamic fa parte del package
        dynamic obj=JsonConvert.DeserializeObject(json)!;
        //ogni obj.x è una variabile chiave valore contenuta nel file json
        Console.WriteLine($"sentiment: {obj.nome}general root: {obj.cognome}how much: {obj.eta}");
    }
}
```


```json
{
    "nome": "unpaid",
    "cognome": "pain",
    "eta": 9
}
```
</pre>
</details>

### 19 più robe JSON

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
//necessita di un package specifico per essere usato appieno
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\somucheffortfornothing.json";
        string json=File.ReadAllText(path);
        dynamic obj=JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"sentiment: {obj.nome}, general root: {obj.cognome}, how much: {obj.eta}\nwhere it happened: {obj.indirizzo.via}, in the city of {obj.indirizzo.citta}");
    }
}
```


```json
{
    "nome": "unpaid",
    "cognome": "pain",
    "eta": 9,
    //puoi creare ulteriori object per contenere in modo più ordinato i dati
    "indirizzo": {
        "via": "un mero giochino di dadi",
        "citta": "un semplice programmino"
    }
}
```
</pre>
</details>

### 20 più oggetti json e scritta in csv

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
//necessita di un package specifico per essere usato appieno
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\somucheffortfornothing.json";
        string json=File.ReadAllText(path);
        dynamic obj=JsonConvert.DeserializeObject(json)!;
        //per creare un csv file
        string path2=@"JaSon\why.csv";
        File.Create(path2).Close();
        //inizializzazione del file csv
        File.WriteAllText(path2, "nome,cognome,eta,via,citta\n");
        for(int i=0; i<obj.Count;i++)
        {
            Console.WriteLine($"sentiment: {obj[i].nome}, general root: {obj[i].cognome}, how much: {obj[i].eta}\nwhere it happened: {obj[i].indirizzo.via}, in the city of {obj[i].indirizzo.citta}");
            //si aggiunge ogni oggetto del json usando anche il .Count d'esso
            File.AppendAllText(path2, $"{obj[i].nome},{obj[i].cognome},{obj[i].eta},{obj[i].indirizzo.via},{obj[i].indirizzo.citta}\n");
        }
    }
}
```


```json
//se si inseriscono più oggetti json, c'è bisogno delle quadre prima dell'insieme
[
    {
        "nome": "unpaid",
        "cognome": "pain",
        "eta": 9,
        "indirizzo": {
            "via": "un mero giochino di dadi",
            "citta": "un semplice programmino"
        }
    },
    {
        "nome": "coping",
        "cognome": "mechanism",
        "eta": 13,
        "indirizzo": {
            "via": "dormire",
            "citta": "bisogni estremamente primari"
        }
    }
]
```


```
nome,cognome,eta,via,citta
unpaid,pain,9,un mero giochino di dadi,un semplice programmino
coping,mechanism,13,dormire,bisogni estremamente primari
```
</pre>
</details>

### 21 THE OTHER WAY AROUND NOW

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\because.csv";
        string[] lines= File.ReadAllLines(path);
        string [][] prodotti=new string[lines.Length][];
        for(int i=0; i<lines.Length;i++)
        {
            prodotti[i]=lines[i].Split(',');
        }
        for(int i=0; i<prodotti.Length;i++)
        {
            string path2=@"JaSon\"+prodotti[i][0]+".json";
            File.Create(path2).Close();
            File.AppendAllText(path2, JsonConvert.SerializeObject(new{nome=prodotti[i][0],prezzo=prodotti[i][1]}));
            Console.WriteLine($"Primo di sto coso: {prodotti[i][0]}, Secondo invece {prodotti[i][1]}");
        }
    }
}
```


```
nome,cognome,eta,via,citta
refrain,worry,17,un mero giochino di dadi,un semplice programmino
respect,worry,16,livello altrui,imparare
```


```json
{"nome":"nome","prezzo":"cognome"}
```
```json
{"nome":"refrain","prezzo":"worry"}
```
```json
{"nome":"respect","prezzo":"worry"}
```
</pre>
</details>

### 22 più robe JSON

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\newstufftho.json";
        File.Create(path).Close();
        File.AppendAllText(path, "[\n");
        bool continua=true;
        while(continua)
        {
            Console.WriteLine("Me dica un nome ed un numerino");
            string nome=Console.ReadLine()!;
            string prezzo=Console.ReadLine()!;
            File.AppendAllText(path, JsonConvert.SerializeObject(new {nome, prezzo})+",\n");
            Console.WriteLine("Aight, again? (y/n)");
            string risposta=Console.ReadLine()!;
            if(risposta=="n")
            {
                continua=false;
            }
        }
        string file=File.ReadAllText(path);
        file=file.Remove(file.Length-2, 1);
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]");
    }
}
```


```json
//nomi: Che, pABLO, JaSon; prezzi: 30, 40, 3
[
{"nome":"Che","prezzo":"30"},
{"nome":"pABLO","prezzo":"40"},
{"nome":"JaSon","prezzo":"3"}
]
```
</pre>
</details>

## 08 SQL dentro al programma C

### Un menu per interagire con un file .db

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db";
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");
            connection.Open();
            string sql = @"
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita>=0));
                        INSERT INTO prodotti VALUES (NULL, 'p1', 3.99, 10);
                        INSERT INTO prodotti VALUES (NULL, 'p2', 3.99, 20);
                        INSERT INTO prodotti VALUES (NULL, 'p3', 2.99, 10);
            ";

            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 - inserisci\n2 - visualizza\n3 - elimina\n4 - esci\npigia, coglio");
            ConsoleKeyInfo chiavico = Console.ReadKey(true);
            switch (chiavico.Key)
            {
                case ConsoleKey.D1:
                    InserisciProdotto();
                    break;
                case ConsoleKey.D2:
                    VisualizzaTutto();
                    break;
                case ConsoleKey.D3:
                    EliminaProdotto();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("\n\nAddios");
                    return;
            }
        }
    }

    static void InserisciProdotto()
    {
        Console.Clear();
        Console.WriteLine("Dimmi un nome");
        string nome =Console.ReadLine()!;
        Console.WriteLine("Dimmi il prezzo");
        string prezzo =Console.ReadLine()!;
        Console.WriteLine("Dimmi quanti");
        string quanti =Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql=$"INSERT INTO prodotti VALUES (NULL, '{nome}', {prezzo}, {quanti});";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaTutto()
    {
        Console.Clear();
        SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;");
        connection.Open();
        string sql="SELECT * FROM prodotti;";
        SQLiteCommand command= new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        }
        connection.Close();
        Console.ReadKey();
    }

    static void EliminaProdotto()
    {
        Console.Clear();
        Console.WriteLine("Nome del giustiziato");
        string nome =Console.ReadLine()!;
        SQLiteConnection connection=new SQLiteConnection("Data Source=database.db;Version=3;");
        connection.Open();
        string sql=$"DELETE FROM prodotti WHERE nome = '{nome}';";
        SQLiteCommand command =new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}
```

## 09 AnsiConsole

### 01 Scritta sottolineata in un colore e tabella personalizzata

> ricorda di usarea i comandi "dotnet add package Spectre.Console" e lo stesso comando + ".Cli"

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
using System.Data.SQLite;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.Markup("[underline red]Hello[/] World!\n");

        var table= new Table();
        table.AddColumns("Columna 1", "Columna 2");
        table.AddRow("Valore 1", "Valore 2");
        table.AddRow("Valore 3", "Valore 4");
        AnsiConsole.Write(table);
    }
}
```
</pre>
</details>


## 10 Linee di codici sparsi

### 01 Menù

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 02 Riproduzione di una command line molto scheletrica

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 03 Try Catch coi file

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
            Console.WriteLine($"C'è stato un problema: {ex. Message}");
        }
    }
}
```
</pre>
</details>

### 04 Gestione del tempo (task)

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 05 Gestione del tempo (downgrade)

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 06 Classe random

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 07 Diversi comandi

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

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
</pre>
</details>

### 08 Classe random con l'array

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        //guess stavolta si guarderà ai random
        //Stringa di nomi predefinita
        string[] nomi= {"Rosario", "Peckneck", "Raymond", "Blackjack", "Handsome Jack"};
        //oggetto random per il metodo random
        Random ran=new Random();
        //selezione della roulette mortale
        int scelto= ran.Next(0, 5);
        //annuncio di chi è il vincitore
        Console.WriteLine($"lo sfortunato vincitore è {nomi[scelto]}");
    }
}
```
</pre>
</details>

### 09 Selezione tra persone

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Tempo di provare a fare na selezione:\n");
        //lista di nomi
        List<string> nomi= new List<string>{};
        //facciamo che non lo vogliano prefatto, ma decidere noi cosa mettere
        int i=0;
        //il while lo si usa per evitare casini
        //in questo caso è il primo livello di sicurezza: minimo 1 nome
        while(i<=0)
        {
            Console.WriteLine($"Quanti ne vuoi mettere?");
            //digitazione della quantità di nomi da strarre
            string secure=Console.ReadLine();
            //secondo livello di sicurezza: digitare un valore che sia effettivamente un intero
            if(int.TryParse(secure, out i))
            {
                i=Convert.ToInt32(secure);
                //una opzione personale mia, un messaggio diverso in base al numero di nomi
                if(i>1)
                {
                    Console.WriteLine($"\nBene, ne abbiamo {i}\n");
                    break;
                }
                Console.WriteLine($"\nQualcuno qui ha un pò di astio\n");
                break;
            }
            //messaggio di errore
            Console.WriteLine("\nSo che è difficile, ma almeno un nome lo dobbiamo mettere in questa roulette\n");
        }
        //da qui, si mettono i nomi
        for(int l=0; l<i; l++)
        {
            //aggiunta del nome
            Console.Write($"Mettiamo il numero {l+1}: ");
            nomi.Add(Console.ReadLine());
            Console.Write($"\n");
        }
        //random
        Random ran=new Random();
        //selezione
        int scelto= ran.Next(0, nomi.Count);
        //debug
        Console.Write($"Ne ho {nomi.Count}, di cui ho scelto il numero {scelto+1}");
        //si riprende la questione di un interazione speciale in base al numero di nomi
        if(i==1)
        {
            Console.Write($", sorprendentemente...");
        }
        //risultato
        Console.WriteLine($"\n\nLo sfortunato vincitore è {nomi[scelto]}");
    }
}
```
</pre>
</details>

### 10 Metodi Math e Riduzione dei decimali

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Da qui un numero\n");
        double x = double.Parse(Console.ReadLine());
        double result = 0;
        Console.WriteLine($"Hai 3 possibili operazioni:\n- Radice quadrata (metti 'v')\n- Quadrato (metti 'q')\n- Cubo (metti 'c')");
        while (true)
        {
            string opera = Console.ReadLine();
            bool fax = false;
            switch (opera)
            {
                case "v":
                    result = Math.Sqrt(x);
                    Console.WriteLine($"Radice selezionata");
                    break;
                case "q":
                    result = Math.Pow(x, 2);
                    Console.WriteLine($"Quadro selezionato");
                    break;
                case "c":
                    result = Math.Pow(x, 3);
                    Console.WriteLine($"Cubo selezionato");
                    break;
                default:
                    Console.WriteLine($"Operazione non valida");
                    fax=true;
                    break;
            }
            if(!fax)
            {
                break;
            }
        }
        Console.WriteLine($"\nTi mostrerò il risultato in 3 modi");
        var strano=result.ToString("#.##"); //è mera rappresentazione, i cancelletti son i decimali, il punto prima invece è generalizzazione
        double rocco= Math.Round(result, 4);
        Console.WriteLine($"Dal tronco: {Math.Truncate(result)}");  //tronca il numero fino all'integrale
        Console.WriteLine($"Dalla rotonda: {rocco}");               //arrotonda
        Console.WriteLine($"Da rappresentazione modificata {strano}");
    }
}
```
</pre>
</details>

### 11 Try Catch per prove

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        int lol=0;
        int swag=1/lol;
        Console.Clear();
        try
        {
            Console.WriteLine($"It is time for\n");
            int numero=int.Parse("10000000000000");
            Console.WriteLine($"\nHai scritto : {numero}");
        }
        catch(Exception e)
        {
            Console.WriteLine("c'è qualcosa di sbagliato...");
            Console.WriteLine("\n"+e.Message);
            Console.WriteLine("\nPuoi andare a vedere da qualche parte cosa corrisponde il seguente codice errore");
            Console.WriteLine("\n"+e.HResult);
            return;
        }
    }
}
```
</pre>
</details>

### 12 Funzioni con ritorni multipli

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">

```c#
class Program
{
    static void Main(string[] args)
    {
        int a=0;
        int b=0;
        Console.WriteLine($"Ammira come cambio {a} e {b} con una funzione");
        (a, b)=OneIntoTwo(2);
        Console.WriteLine($"Ecco a voi...   I NUOVI A E B: {a}, {b}");
    }

    static (int, int) OneIntoTwo(int numero)
    {
        int picco=0;
        int seco=0;
        if(numero%2==0)
        {
            picco=numero/2;
            seco=numero*2;
        }
        else
        {
            picco=numero;
            seco=numero;
        }
        return (picco, seco);
    }
}
```
</pre>
</details>
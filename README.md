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
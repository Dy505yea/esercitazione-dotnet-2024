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
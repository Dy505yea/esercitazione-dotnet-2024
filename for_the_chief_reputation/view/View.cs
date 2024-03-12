using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;
class View
{
    private Database Db;
    public View(Database db)
    {
        Db = db;
    }


    //Area dedicata al programma specifico
    
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Menù Dipendente");
        Console.WriteLine("2. Menù Cliente");
        Console.WriteLine("3. Esci");
    }
    /// <summary>
    /// Stampa del menù
    /// </summary>
    public void ShowArticoloMenu()
    {
        Console.WriteLine("1. Aggiungi articolo");
        Console.WriteLine("2. Leggi gli articoli");
        Console.WriteLine("3. Aggiorna un articolo");
        Console.WriteLine("4. Elimina un articolo");
        Console.WriteLine("5. Salva ed esci");
    }
    public void ShowControlloClientiMenu()
    {
        Console.WriteLine("1. Modifica/Aggiunta dei clienti");
        Console.WriteLine("2. Visualizzazione dei clienti");
        Console.WriteLine("3. Eliminazione di un cliente");
        Console.WriteLine("4. Esci dal controllo clienti");
    }
    public void ShowClientiMenu()
    {
        Console.WriteLine("1. Aggiungi un cliente");
        Console.WriteLine("2. Leggi cilenti");
        Console.WriteLine("3. Aggiorna un cliente");
        Console.WriteLine("4. Elimina un cliente");
        Console.WriteLine("5. Salva ed esci");
    }
    public void ShowFirstScreenCliente()
    {
        Console.WriteLine("Benvenuto nel negozio");
        Console.WriteLine("Posso avere il suo Nome e Cognome?");
    }
    public void ShowMenuForCliente()
    {
        //Ricorda, in futuro deve avere un modo per poter riconoscere l'utente se da dei dati già
        //presenti nella tabella, per cui ci sarà probabilmente un operazione prima ancora di questa
        Console.WriteLine("1. Cerca articolo");
        Console.WriteLine("2. Lista acquisti precedenti");
        Console.WriteLine("3. Aggiorna dati");
        Console.WriteLine("4. Esci");
    }
    public void ShowMenuDipendente()
    {
        Console.WriteLine("1. Menù degli articoli");
        Console.WriteLine("2. Menù del controllo dei clienti");
        Console.WriteLine("3. Esci");
    }
    /// <summary>
    /// Metodo per stampare tutte le categorie
    /// </summary>
    /// <param name="cates">Lista di categorie da stampare</param>
    public void ShowSeleCategories(List<Categoria> cates)
    {
        int i=1;
        foreach(var cate in cates)
        {
            Console.WriteLine($"{i}. {cate.Nome}");
            i++;
        }
    }
    /// <summary>
    /// Metodo per stampare cosa si vuol vedere dalla tabella di categorie
    /// </summary>
    public void ShowVisualArticoloMenu()
    {
        Console.WriteLine("1. Tutti gli articoli esistenti");
        Console.WriteLine("2. Tutti gli articoli di una categoria");
        Console.WriteLine("3. Tutti gli articoli di un gruppo");
    }
    public void ShowVisualClientiMenu()
    {
        Console.WriteLine("1. Tutti i clienti");
        Console.WriteLine("2. Solo i clienti con uno stesso articolo in comune");
    }
    /// <summary>
    /// Metodo per controllare che ci siano le 5 categorie richieste
    /// </summary>
    /// <param name="cates"></param>
    /// <returns></returns>
    public bool CheckCategorie(List<Categoria> cates)
    {
        //dato che son 5, la i conta il numero di quelli checkati
        int i=0;
        if(cates==null)
        {
            Console.WriteLine("La tabella non esiste");
            return false;
        }
        foreach(var cate in cates)
        {
            //il motivo di questo check è perchè le liste devono avere gli id già settati in un modo specifico:
            //son dall'1 al 5
            if(cate.Id<=0||cate.Id>5)
            {
                Console.WriteLine("Almeno una categoria non rispetta lo standard dell'id");
                return false;
            }
            i++;
        }
        if(i!=5)
        {
            Console.WriteLine("Le categorie non sono specificatamente 5");
            return false;
        }
        return true;
    }
    /// <summary>
    /// Metodo per stampare gli articoli di una lista di articoli
    /// </summary>
    /// <param name="arti">Lista di articoli</param>
    public void ShowArticoli(List<Articolo> arti)
    {
        foreach(var arto in arti)
        {
            Console.Write($"-------------\nNome: {arto.Nome}\nGruppo: {arto.Gruppo} | Quantità: {arto.Quantità} | ");
            Console.WriteLine($"Prezzo: {ChangePuntaToVirgola(arto.Prezzo.ToString())} | Categoria: {arto.Categoria!.Nome} | Id: {arto.Id}");
        }
    }
    public void ShowClienti(List<Cliente> clients)
    {
        foreach(var clie in clients)
        {
            Console.Write($"-------------\nNome: {clie.Nome} | Cognome: {clie.Cognome} | ");
            if(clie.Telefono!=0)
                Console.Write($"Numero: {clie.Telefono} | ");
            if(clie.Email!=null)
                Console.Write($"Email: {clie.Email}");
            Console.WriteLine();
        }
    }
    public void ShowFieldsTableArticolo()
    {
        Console.WriteLine("1. Nome listino");
        Console.WriteLine("2. Gruppo d'appartenenza");
        Console.WriteLine("3. Quantità in stock");
        Console.WriteLine("4. Prezzo di vendita");
        Console.WriteLine("5. Fine modifiche");
    }
    public void ShowFieldsTableCliente()
    {
        Console.WriteLine("1. Nome");
        Console.WriteLine("2. Cognome");
        Console.WriteLine("3. Numero telefonico");
        Console.WriteLine("4. Indirizzo email");
        Console.WriteLine("5. Fine modifiche");
    }


    //Area dedicata agli input, errori e formattazioni

    /// <summary>
    /// Per inserire un qualsiasi input
    /// </summary>
    /// <returns>La stringa inserita</returns>
    public string GetInput()
    {
        return Console.ReadLine()!;
    }
    /// <summary>
    /// Metodo per inserire un qualsiasi testo con almeno un carattere<br></br>
    /// Se non si inserisce una stringa con almeno un carattere,<br></br>
    /// facendo riscrivere la stringa da input
    /// </summary>
    /// <returns>La stringa con almeno un carattere</returns>
    public string TestoInput()
    {
        string text = GetInput();
        if (text == null||text.Length<=0)
        {
            Console.WriteLine("Richiedo almeno un carattere, riscrivere");
            return TestoInput();
        }
        return text;
    }
    /// <summary>
    /// Metodo per inserire una stringa e provare a convertirla in un valore intero<br></br>
    /// Se non è possibile, farà riscrivere la stringa finchè non rispetta le condizioni
    /// </summary>
    /// <returns>Valore intero da stringa</returns>
    public int ValoreIntInput()
    {
        int valore;
        try
        {
            valore=Convert.ToInt32(GetInput());
        }
        catch
        {
            Console.WriteLine("Ho bisogno di un numero intero, riscrivere");
            valore=ValoreIntInput();
        }
        return valore;
    }
    /// <summary>
    /// Metodo per inserire in input un valore entro un range<br></br>
    /// In caso il valore fosse più piccolo del limite minimo/più grande del limite massimo<br></br>
    /// si farà riscrivere il numero
    /// </summary>
    /// <param name="min">Il minimo valore accettabile</param>
    /// <param name="max">Il massimo valore accettabile</param>
    /// <returns>Numero intero entro i limiti del range</returns>
    public int ValoreIntEntroRange(int min, int max)
    {
        int valore=ValoreIntInput();
        if(valore<min||valore>max)
        {
            Console.WriteLine($"Il numero deve essere entro {min} e {max}, riscrivi");
            valore=ValoreIntEntroRange(min, max);
        }
        return valore;
    }
    /// <summary>
    /// Metodo per cambiare tutte le virgole di una stringa in punto<br></br>
    /// Fatto solo e specificatamente per creare un valore double con standard '.' per i decimali
    /// </summary>
    /// <param name="valore">Valore double in stringa</param>
    /// <returns>La stessa stringa con eventuale virgola cambiata in punto</returns>
    public string ChangeVirgolaToPunta(string valore)
    {
        return valore.Replace(",", ".");
    }
    /// <summary>
    /// Metodo per cambiare tutte le punte di una stringa in virgola<br></br>
    /// Fatto per quando bisogna presentare in stampa
    /// </summary>
    /// <param name="valore">Valore double in stringa</param>
    /// <returns>La stessa stringa con eventuale punto in virgola</returns>
    public string ChangePuntaToVirgola(string valore)
    {
        return valore.Replace(".", ",");
    }
    /// <summary>
    /// Metodo per controllare una stringa sia convertibile<br></br>e convertirlo in un valore decimale<br></br>
    /// Se non è un valore intero, farà riscrivere la stringa finchè non rispetta le condizioni
    /// </summary>
    /// <param name="stringa">Stringa da controllare e convertire</param>
    /// <returns>Valore decimale da stringa</returns>
    public double ValoreDoubleInput()
    {
        double valore;
        try
        {
            valore=Convert.ToDouble(ChangeVirgolaToPunta(GetInput()));
        }
        catch
        {
            Console.WriteLine("Ho bisogno di un numero decimale, riscrivere");
            valore=ValoreDoubleInput();
        }
        return valore;
    }
    /// <summary>
    /// Metodo per controllare che un valore intero abbia almeno X cifre<br></br>
    /// X è il numero di cifre volute
    /// </summary>
    /// <param name="valore">valore intero da controllare</param>
    /// <param name="minimo">numero di cifre minime</param>
    /// <returns>Vero finchè il valore ha almeno il minimo di cifre desiderato</returns>
    public bool CheckCifreMinimeDouble(double valore, int minimo)
    {
        string numero=valore.ToString();
        if(numero.Length>=minimo)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Metodo per controllare un numero abbia un minimo di cifre<br></br>
    /// In caso contrario, si fa riscrivere il valore intero da input finchè non rispetta la condizione
    /// </summary>
    /// <param name="minimo">Numero di cifre minime</param>
    /// <returns>Valore intero con il minimo di cifre</returns>
    public double ValoreDoubleConCifreMinime(int minimo)
    {
        double valore=ValoreDoubleInput();
        if(!CheckCifreMinimeDouble(valore, minimo))
        {
            Console.WriteLine($"Numero invalido, deve avere almeno {minimo} cifre");
            valore=ValoreDoubleConCifreMinime(minimo);
        }
        valore=ValoreDoubleSenzaDecimale(valore);
        return valore;
    }
    /// <summary>
    /// Metodo per rialzare il valore fino a che non esca dei decimali<br></br>
    /// Pensato nei casi uno non volesse le virgole nel valore (nel caso di questo esercizio, il numero telefonico)
    /// </summary>
    /// <param name="valore">Valore da convertire</param>
    /// <returns>Il valore "senza la virgola"</returns>
    public double ValoreDoubleSenzaDecimale(double valore)
    {
        decimal prova= Convert.ToDecimal(valore);
        while(valore%1!=0)
        {
            prova*=10;
            valore=Convert.ToDouble(prova);
        }
        return valore;
    }
    /// <summary>
    /// Metodo per forzare a scegliere tra 2 risposte<br></br>
    /// </summary>
    /// <param name="positiva">Scelta per far ritornare TRUE</param>
    /// <param name="negativa">Scelta per far ritornare FALSE</param>
    /// <returns>La scelta da input sottoforma di variabile boolean</returns>
    public bool RispostaDueScelte(string positiva, string negativa)
    {
        bool reply;
        string forcePositiva=positiva.ToUpper();
        string forceNegativa=negativa.ToUpper();
        string scelta=TestoInput().ToUpper();
        if(scelta==forcePositiva)
        {
            reply=true;
        }
        else if(scelta==forceNegativa)
        {
            reply=false;
        }
        else
        {
            Console.WriteLine($"Per favore, scegliere tra '{positiva}' e '{negativa}'");
            reply=RispostaDueScelte(positiva, negativa);
        }
        return reply;
    }
}
using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;
class Controller
{
    private Database Db;
    private View View;
    public Controller(Database db, View view)
    {
        Db = db;
        View = view;
    }


    /// <summary>
    /// Il programma principale del controller
    /// </summary>
    public void AvvioProgramma()
    {
        Preparation();
        MainMenu();
    }
    /// <summary>
    /// Un metodo per controllare ed eventualmente resettare la tabella delle categorie
    /// </summary>
    private void Preparation()
    {
        var cates = Db.DammiCategorie();
        if (!View.CheckCategorie(cates) || cates == null)
        {
            Console.WriteLine("La tabella categorie non rientra negli standard, reset in corso");
            Db.ResetDB();
            //Db.BackDb(Db.DammiArticoli());
        }
    }
    /// <summary>
    /// Main menù, da qui si divide tra dipendente e cliente
    /// </summary>
    private void MainMenu()
    {
        bool done = false;
        while (!done)
        {
            Console.Clear();
            View.ShowMainMenu();
            var input = View.ValoreIntEntroRange(1, 3);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    MenuDipendente();
                    break;
                case 2:
                    PrimaSchermataCliente();
                    break;
                case 3:
                    done = true;
                    break;
            }
        }
    }
    
    
    /// <summary>
    /// Menù per il dipendente<br></br>
    /// Comprende gestione degli articoli e dei clienti
    /// </summary>
    private void MenuDipendente()
    {
        bool done=false;
        while(!done)
        {
            View.ShowMenuDipendente();
            int input = View.ValoreIntEntroRange(1, 5);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    ArticoliMenu();
                    break;
                case 2:
                    Console.Clear();
                    ControlloClientiMenu();
                    break;
                case 3:
                    done=true;
                    break;
            }
            if (!done)
                Console.Clear();
        }
    }
    /// <summary>
    /// Menu degli articoli, solo un dipendente puo lavorarci
    /// </summary>
    private void ArticoliMenu()
    {
        bool done = false;
        while (!done)
        {
            View.ShowArticoloMenu();
            var input = View.ValoreIntEntroRange(1, 5);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    AddArticolo();
                    break;
                case 2:
                    Console.Clear();
                    VisArtMenu();
                    break;
                case 3:
                    Console.Clear();
                    ModificArticolo();
                    break;
                case 4:
                    Console.Clear();
                    EliminArticolo();
                    break;
                case 5:
                    done = true;
                    break;
                default:
                    break;
            }
            if (!done)
                Console.Clear();
        }
    }
    /// <summary>
    /// Metodo per aggiungere un articolo nella tabella
    /// </summary>
    private void AddArticolo()
    {
        Console.WriteLine("Scrivi il nome da listino:");
        string nome = View.TestoInput();
        Console.WriteLine("Scrivi il nome del gruppo d'appartenenza:");
        string gruppo = View.TestoInput();
        Console.WriteLine("Scrivi la quantità attuale in magazzino:");
        int quanti = View.ValoreIntInput();
        Console.WriteLine("Scrivi il suo prezzo di vendita:");
        double prezzo = View.ValoreDoubleInput();

        Console.WriteLine("Seleziona una delle seguenti categorie\n");
        MostraCategorie();
        int idCate = View.ValoreIntEntroRange(1, 5);
        Db.InserisciArticolo(nome, gruppo, quanti, prezzo, idCate);
    }

    /// <summary>
    /// Menu per la visualizzazione degli articoli, da qui uno sceglie quali si vuol vedere
    /// </summary>
    private void VisArtMenu()
    {
        //menu per la visualizzazione dell'articolo, vogliamo diverse opzioni, uno per tutti, uno per categoria e uno per gruppo
        Console.WriteLine("Seleziona come vuoi vedere:\n");
        View.ShowVisualArticoloMenu();
        int modo = View.ValoreIntEntroRange(1, 3);
        switch (modo)
        {
            case 1:
                MostrArticoli();
                Console.WriteLine("\nPremere qualsiasi pulsante per proseguire...");
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("Quale categoria si cerca in specifico?");
                MostraCategorie();
                int cate = View.ValoreIntEntroRange(1, 5);
                View.ShowArticoli(Db.DammiArticoliDaCategoria(cate));
                Console.WriteLine("\nPremere qualsiasi pulsante per proseguire...");
                Console.ReadKey();
                break;
            case 3:
                Console.WriteLine("\nScrivere il gruppo d'appartenenza:");
                string gruppo = View.TestoInput();
                View.ShowArticoli(Db.DammiArticoliDaGruppo(gruppo));
                Console.WriteLine("\nPremere qualsiasi pulsante per proseguire...");
                Console.ReadKey();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// metodo per mostrare tutti gli articoli del database
    /// </summary>
    private void MostrArticoli()
    {
        var arti = Db.DammiArticoli();
        View.ShowArticoli(arti);
    }
    /// <summary>
    /// Metodo per mostrare le categorie su console
    /// </summary>
    private void MostraCategorie()
    {
        var cates = Db.DammiCategorie();
        View.ShowSeleCategories(cates);
    }
    /// <summary>
    /// Mini menù per la modifica di un articolo
    /// </summary>
    private void ModificArticolo()
    {
        //pensa al db che deve modificare cose in base a cosa fai
        //di sicuro devi mostrare prima cosa c'è, poi farlo cercare ed infine far decidere che cambiare
        MostrArticoli();
        Console.WriteLine("\nScrivere l'id dell'articolo da modificare");
        int id = View.ValoreIntInput();
        bool done = false;
        while (!done)
        {
            Console.WriteLine("Quale dato vuoi modificare?\n");
            View.ShowFieldsTableArticolo();
            int column = View.ValoreIntEntroRange(1, 5);
            done = SeleCampoArticolo(id, column);
        }
        Console.WriteLine("Ritorno al menù");
        Thread.Sleep(750);
    }
    /// <summary>
    /// Metodo che richiama la funzione adatta per fare la modifica voluta o per uscire
    /// </summary>
    /// <param name="id">Id dell'articolo</param>
    /// <param name="column">Campo da modificare</param>
    /// <returns>Vero solo nel caso l'utente avesse finito di fare le modifiche</returns>
    private bool SeleCampoArticolo(int id, int column)
    {
        bool done = false;
        switch (column)
        {
            case 1:
                Console.WriteLine("Scrivi il nuovo nome da listino per l'articolo:");
                Db.ChangeNameArticolo(id, View.TestoInput());
                break;
            case 2:
                Console.WriteLine("Scrivi il nuovo gruppo d'appartenenza per l'articolo:");
                Db.ChangeGroupArticolo(id, View.TestoInput());
                break;
            case 3:
                Console.WriteLine("Scrivi la quantità in stock dell'articolo:");
                Db.ChangeNumberArticolo(id, View.ValoreIntInput());
                break;
            case 4:
                Console.WriteLine("Scrivi il nuovo prezzo di vendita per l'articolo:");
                Db.ChangePriceArticolo(id, View.ValoreDoubleInput());
                break;
            case 5:
                done = true;
                break;
            default:
                break;
        }
        return done;
    }

    /// <summary>
    /// Metodo per eliminare un articolo da id
    /// </summary>
    private void EliminArticolo()
    {
        MostrArticoli();
        Console.WriteLine("\nScrivi l'id dell'articolo da eliminare");
        int id = View.ValoreIntInput();
        Db.EliminArticolo(id);
    }


    /// <summary>
    /// Menù dedicato al CONTROLLO degli utenti da parte dello staff
    /// </summary>
    private void ControlloClientiMenu()
    {
        bool done=false;
        while(!done)
        {
            View.ShowControlloClientiMenu();
            int input=View.ValoreIntEntroRange(1, 4);
            switch(input)
            {
                case 1:
                    Console.Clear();
                    MenuModificAggiungiCliente();
                    break;
                case 2:
                    Console.Clear();
                    VisClientiMenu();
                    break;
                case 3:
                    Console.Clear();
                    EliminaCliente();
                    break;
                case 4:
                    done=true;
                    break;
            }
            if (!done)
                Console.Clear();
        }
    }
    /// <summary>
    /// Esegue un azione simile al LoginCliente()<br></br>
    /// ma a differenza di quest'ultima, da la scelta<br></br>
    /// se aggiungere un nuovo cliente o no, oltre a compiere<br></br>
    /// l'azione di modificare
    /// </summary>
    private void MenuModificAggiungiCliente()
    {
        bool done = false;
        while (!done)
        {
            Console.WriteLine("Scrivi il nome del cliente");
            string nome = View.TestoInput();
            Console.WriteLine("Scrivi il cognome del cliente");
            string cognome = View.TestoInput();
            var cliente = Db.DammiCliente(nome, cognome);
            Console.Clear();
            if (cliente != null)
            {
                ModificaCliente(cliente);
            }
            else
            {
                Console.WriteLine("Questo cliente non è mai stato registrato finora");
                Console.WriteLine("Vuole aggiungerlo?\n(S per si, N per no)");
                if (View.RispostaDueScelte("s", "n"))
                {
                    cliente = Db.InserisciCliente(nome, cognome);
                    Console.WriteLine("Voler assegnare un numero di telefono?\n(Inserire S per si, N per no)");
                    if (View.RispostaDueScelte("S", "n"))
                    {
                        Console.WriteLine("Inserire il numero:");
                        double numero = View.ValoreDoubleConCifreMinime(9);
                        Db.InserisciNumCliente(cliente, numero);
                    }
                    Console.WriteLine("Voler assegnare un indirizzo email?\n(Inserire S per si, N per no)");
                    if (View.RispostaDueScelte("S", "n"))
                    {
                        Console.WriteLine("Inserire l'indirizzo email:");
                        string email = View.TestoInput();
                        Db.InserisciEmCliente(cliente, email);
                    }
                }
            }
            Console.WriteLine("\nVoler modificare un altro cliente?\n(Inserire S per si, N per no)");
            if (!View.RispostaDueScelte("s", "n"))
            {
                done = true;
            }
        }
    }

    /// <summary>
    /// Menù per la visualizzazione dei clienti<br></br>
    /// Puoi vederli tutti o solo quelli con un articolo in comune
    /// </summary>
    private void VisClientiMenu()
    {
        //menu per la visualizzazione dei clienti, li visualizziamo tutti o per articolo in comune
        Console.WriteLine("Seleziona come vuoi vedere:\n");
        View.ShowVisualClientiMenu();
        if (View.RispostaDueScelte("1", "2"))
        {
            Console.Clear();
            MostraClienti();
            Console.WriteLine("\nPremere un qualsiasi pulsante per andare avanti...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Vuole visualizzare una lista di articoli?\n(S per si, N per no)");
            if (View.RispostaDueScelte("s", "n"))
            {
                VisArtMenu();
            }
            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("Scriva il nome dell'articolo con cui trovare degli utenti");
                string nomeArto = View.TestoInput();
                var arto = Db.DammiArticolo(nomeArto);
                if (arto == null)
                {
                    Console.WriteLine("Il nome non corrisponde a nessun articolo, voler riscrivere?\n(S per si, N per no)");
                    if (!View.RispostaDueScelte("s", "n"))
                    {
                        done = true;
                    }
                }
                else
                {
                    Console.Clear();
                    var clienti = Db.DammiClientiDaIdArto(arto.Id);
                    View.ShowClienti(clienti);
                    done = true;
                    Console.WriteLine("\nPremere un qualsiasi pulsante per andare avanti...");
                    Console.ReadKey();
                }
            }
        }
    }
    /// <summary>
    /// Metodo per vedere tuti i clienti presenti nel database
    /// </summary>
    private void MostraClienti()
    {
        var clienti=Db.DammiClienti();
        View.ShowClienti(clienti);
    }

    /// <summary>
    /// Metodo per Eliminare un cliente dal nome e cognome
    /// </summary>
    private void EliminaCliente()
    {
        MostraClienti();
        Console.WriteLine("\nScrivi il nome e cognome del cliente da eliminare");
        Console.Write("Nome: ");
        string nome=View.TestoInput();
        Console.Write("\nCognome: ");
        string cognome=View.TestoInput();
        Db.EliminaCliente(nome, cognome);
    }


    /// <summary>
    /// Schermata d'accesso del cliente
    /// </summary>
    private void PrimaSchermataCliente()
    {
        Console.Clear();
        View.ShowFirstScreenCliente();
        var cliente = LoginCliente();
        CustomerMenu(cliente);
    }
    /// <summary>
    /// Metodo per prendere un cliente dal DataBase<br></br>
    /// Per ora, il modo per riconoscere sta nella combinazione<br></br>
    /// Nome e Cognome<br></br>
    /// Se non esite, si crea un nuovo cliente invece
    /// </summary>
    /// <returns>Il cliente appena creato/aperto</returns>
    private Cliente LoginCliente()
    {
        Console.WriteLine("Scrivi il nome del cliente");
        string nome = View.TestoInput();
        Console.WriteLine("Scrivi il cognome del cliente");
        string cognome = View.TestoInput();
        var cliente = Db.DammiCliente(nome, cognome);
        if (cliente != null)
        {
            Console.WriteLine($"Bentornato/a, {nome}");
        }
        else
        {
            cliente = Db.InserisciCliente(nome, cognome);
            Console.WriteLine("Voler inserire un numero di telefono?\n(Inserire S per si, N per no)");
            if (View.RispostaDueScelte("S", "n"))
            {
                Console.WriteLine("Inserire il numero:");
                double numero = View.ValoreDoubleConCifreMinime(9);
                Db.InserisciNumCliente(cliente, numero);
            }
            Console.WriteLine("Voler inserire un indirizzo email?\n(Inserire S per si, N per no)");
            if (View.RispostaDueScelte("S", "n"))
            {
                Console.WriteLine("Inserire l'indirizzo email:");
                string email = View.TestoInput();
                Db.InserisciEmCliente(cliente, email);
            }
        }
        return cliente;
    }
    
    /// <summary>
    /// Menù dedicato al cliente<br></br>
    /// </summary>
    /// <param name="cliente">Oggetto cliente che necessitò del menu</param>
    private void CustomerMenu(Cliente cliente)
    {
        Db.IniziArticolo();
        bool done = false;
        while (!done)
        {
            View.ShowMenuForCliente();
            int input = View.ValoreIntEntroRange(1, 4);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    AcquistoMenu(cliente);
                    break;
                case 2:
                    Console.Clear();
                    CronologiaAcquisti(cliente);
                    break;
                case 3:
                    Console.Clear();
                    ModificaCliente(cliente);
                    break;
                case 4:
                    done = true;
                    break;
                default:
                    break;
            }
            if (!done)
                Console.Clear();
        }
    }
    /// <summary>
    /// Acquisto: unione della ricerca degli articoli e<br></br>
    /// aggiunta lista di id degli articoli per il cliente
    /// </summary>
    /// <param name="cliente">Oggetto cliente che effettua l'acquisto</param>
    private void AcquistoMenu(Cliente cliente)
    {
        Console.WriteLine("Ricerca articolo iniziata");
        bool done = false;
        List<Articolo> arti = new List<Articolo>();
        List<int> idArti = new List<int>();
        while (!done)
        {
            bool token = true;
            Console.Clear();
            while (token)
            {
                Console.WriteLine("Voler visualizzare una lista?\n(S per si, N per no)");
                if (View.RispostaDueScelte("s", "n"))
                {
                    VisArtMenu();
                    Console.WriteLine();
                }
                else
                {
                    token = false;
                }
            }
            token = true;
            while (token)
            {
                Console.WriteLine("Scrivi il nome dell'articolo desiderato");
                string nomeArto = View.TestoInput();
                var arto = Db.DammiArticolo(nomeArto);
                if (arto == null)
                {
                    Console.WriteLine("Il nome non corrisponde a nessun articolo, riscrivere?\n(S per si, N per no)");
                    if (!View.RispostaDueScelte("s", "n"))
                    {
                        token = false;
                    }
                }
                else
                {
                    arti.Add(arto);
                    idArti.Add(arto.Id);
                    Db.ChangeNumberArticolo(arto.Id, arto.Quantità - 1);
                    token = false;
                }
                if (!token)
                {
                    Console.WriteLine("Voler acquistare qualcos'altro?\n(S per si, N per no)");
                    if (!View.RispostaDueScelte("s", "n"))
                    {
                        done = true;
                    }
                }
                else
                    Console.Clear();
            }
        }
        Db.InserisciAcquiCliente(cliente, arti, idArti);
    }
    /// <summary>
    /// Metodo per visualizzare una lista di articoli acquistati<br></br>
    /// La lista viene presa dalla lista di id che il cliente dovrebbe avere
    /// </summary>
    /// <param name="cliente">Oggetto cliente da cui visualizzare</param>
    private void CronologiaAcquisti(Cliente cliente)
    {
        List<Articolo> art = new List<Articolo>();
        art = Db.DammiArticoliDaListaId(cliente.IdArticoli!);
        if (art.Count <= 0)
            Console.WriteLine("Finora non hai acquistato niente");
        else
            try
            {
                View.ShowArticoli(art);
            }
            catch
            {
                Console.WriteLine("Non son riuscito a recepire la tua cronologia, sono spiacente per il disagio");
            }
        Console.WriteLine("\nPremere un qualsiasi pulsante per continuare");
        Console.ReadKey();
    }    
    /// <summary>
    /// Metodo per modificare uno campi del cliente
    /// </summary>
    /// <param name="cliente">Oggetto cliente da modificare</param>
    private void ModificaCliente(Cliente cliente)
    {
        bool done = false;
        while (!done)
        {
            Console.WriteLine("Quale campo si vuole modificare?\n\n");
            View.ShowFieldsTableCliente();
            switch (View.ValoreIntEntroRange(1, 5))
            {
                case 1:
                    Console.WriteLine($"Il nome attuale è {cliente.Nome}");
                    Console.WriteLine("Inserire il nuovo nome");
                    string newName = View.TestoInput();
                    Db.ChangeNameCliente(cliente.Id, newName);
                    break;
                case 2:
                    Console.WriteLine($"Il cognome attuale è {cliente.Cognome}");
                    Console.WriteLine("Inserire il nuovo cognome");
                    string newSurname = View.TestoInput();
                    Db.ChangeSurnameCliente(cliente.Id, newSurname);
                    break;
                case 3:
                    if (cliente.Telefono == 0)
                        Console.WriteLine($"Attualmente non c'è nessun numero associato");
                    else
                        Console.WriteLine($"Il numero attuale è {cliente.Telefono}");
                    Console.WriteLine("Inserire il nuovo numero");
                    double newNumero = View.ValoreDoubleConCifreMinime(9);
                    Db.ChangeNumberCliente(cliente.Id, newNumero);
                    break;
                case 4:
                    if (cliente.Email == null)
                        Console.WriteLine($"Attualmente non c'è nessun indirizzo email associato");
                    else
                        Console.WriteLine($"Il numero attuale è {cliente.Email}");
                    Console.WriteLine("Inserire il nuovo indirizzo email");
                    string newAddress = View.TestoInput();
                    Db.ChangeEmailCliente(cliente.Id, newAddress);
                    break;
                case 5:
                    done = true;
                    break;
            }
        }
    }
}
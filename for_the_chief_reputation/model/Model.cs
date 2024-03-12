using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;



/// <summary>
/// Una categoria di strumenti musicali<br></br>
/// Sono 5 le possibili categoria di un articolo:<br></br>
/// Corda<br></br>
/// Fiato<br></br>
/// Tastiere<br></br>
/// Percussioni<br></br>
/// Altro
/// </summary>
class Categoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public List<Articolo>? Articoli { get; set; }
}

/// <summary>
/// Model:<br></br>
/// Categoria predefinita, collegata diversi articoli<br></br>
/// Articolo collegato ad un unica Categoria<br></br>
/// Cliente collegato ad un solo Articolo
/// </summary>
class Database : DbContext
{
    public DbSet<Categoria> Categorie { get; set; }
    public DbSet<Articolo> Articoli { get; set; }
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.SQLite");
    }


    //Area puntata sulle categorie

    /// <summary>
    /// Metodo per creare da zero la tabella delle categorie<br></br>
    /// Pensato per quando è da inizializzare o qualcosa non va con la tabella
    /// </summary>
    public void ResetDB()
    {
        var cont = Categorie.ToList();
        Categorie.RemoveRange(cont);
        var set = new List<Categoria>{
            new Categoria{Id=1, Nome= "Strumenti a Corda"},
            new Categoria{Id=2, Nome= "Strumenti a Fiato"},
            new Categoria{Id=3, Nome= "Strumenti a Percussioni"},
            new Categoria{Id=4, Nome= "Tastiera"},
            new Categoria{Id=5, Nome= "Altro"}
        };
        Categorie.AddRange(set);
        SaveChanges();
    }
    /// <summary>
    /// In caso ci fosserò già degli articoli, ma la tabella categoria è stata recentemente ricreata<br></br>
    /// Si mette una lista degli articoli che fanno parte di uno stesso id
    /// </summary>
    /// <param name="arti">Lista di tutti i record della tabella Articoli</param>
    public void BackDb(List<Articolo> arti)
    {
        foreach (var cate in Categorie)
        {
            foreach (var arto in arti)
            {
                if (cate.Id == arto.IdCategoria)
                {
                    cate.Articoli!.Add(arto);
                }
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per dare la lista delle caegorie
    /// </summary>
    /// <returns>Lista delle categorie nel database</returns>
    public List<Categoria> DammiCategorie()
    {
        var cate=Categorie.ToList();
        return cate;
    }


    //Area dedicata agli articoli
    
    /// <summary>
    /// Aggiunta di un nuovo articolo
    /// </summary>
    /// <param name="nome">Nome specifico, quello usato per la vendita (ex. "Violino Stradivario 3/4")</param>
    /// <param name="familia">Gruppo d'appartenenza dell'articolo</param>
    /// <param name="quanti">Quantità presente nel magazzino</param>
    /// <param name="prezzo">Prezzo di vendita</param>
    /// <param name="catenumero">Id della categoria d'appartenenza</param>
    public void InserisciArticolo(string nome, string familia, int quanti, double prezzo, int catenumero)
    {
        var art = new Articolo { Nome = nome, Gruppo = familia, Quantità = quanti, Prezzo = prezzo, IdCategoria = catenumero };
        foreach (var prova in Categorie)
        {
            if (prova.Id == art.IdCategoria)
            {
                art.Categoria = prova;
            }
        }
        Articoli.Add(art);
        SaveChanges();
    }
    /// <summary>
    /// Metodo per eliminare un articolo da id
    /// </summary>
    /// <param name="id">id dell'articolo da eliminare</param>
    public void EliminArticolo(int id)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                Articoli.Remove(arto);
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per dare la completa lista di articoli presenti
    /// </summary>
    /// <returns>Lista di articoli del database</returns>
    public List<Articolo> DammiArticoli()
    {
        var arti=Articoli.ToList();
        return arti;
    }
    /// <summary>
    /// Metodo per ottenere una lista di articoli appartenenti ad una specifica categoria
    /// </summary>
    /// <param name="idCate"></param>
    /// <returns></returns>
    public List<Articolo> DammiArticoliDaCategoria(int idCate)
    {
        var arti= new List<Articolo>();
        foreach(var arto in Articoli)
        {
            if(arto.IdCategoria==idCate)
            {
                arti.Add(arto);
            }
        }
        return arti;
    }
    public List<Articolo> DammiArticoliDaGruppo(string gruppo)
    {
        var arti= new List<Articolo>();
        foreach(var arto in Articoli)
        {
            if(arto.Gruppo==gruppo)
            {
                arti.Add(arto);
            }
        }
        return arti;
    }
     public List<Articolo> DammiArticoliDaListaId(List<int> idArti)
    {
        var arti=new List<Articolo>();
        foreach(var prova in Articoli)
        {
            foreach(var test in idArti)
            {
                if(prova.Id==test)
                    arti.Add(prova);
            }
        }
        return arti;
    }
    /// <summary>
    /// Metodo per cambiare il nome da listino dell'articolo
    /// </summary>
    /// <param name="id">Id dell'articolo da modificare</param>
    /// <param name="nome">Nuovo nome dell'articolo</param>   
    public void ChangeNameArticolo(int id, string nome)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                arto.Nome=nome;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per cambiare il gruppo d'appartenenza di un articolo
    /// </summary>
    /// <param name="id">Id dell'articolo da modificare</param>
    /// <param name="gruppo">Nuovo gruppo d'appartenenza</param>
    public void ChangeGroupArticolo(int id, string gruppo)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                arto.Gruppo=gruppo;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per cambiare la quantità in magazzino dell'articolo
    /// </summary>
    /// <param name="id">Id dell'articolo da modificare</param>
    /// <param name="quanti">Quantità attuale in stock dell'articolo</param>
    public void ChangeNumberArticolo(int id, int quanti)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                arto.Quantità=quanti;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per aggiornare il prezzo di vendita dell'articolo
    /// </summary>
    /// <param name="id">Id dell'articolo da modificare</param>
    /// <param name="prezzo">Nuovo prezzo dell'articolo</param>
    public void ChangePriceArticolo(int id, double prezzo)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                arto.Prezzo=prezzo;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per aggiornare la categoria d'appartenenza dell'articolo
    /// </summary>
    /// <param name="id">Id dell'articolo da modificare</param>
    /// <param name="idCate">Id della categoria in cui spostare l'articolo</param>
    public void ChangeCategoryArticolo(int id, int idCate)
    {
        foreach(var arto in Articoli)
        {
            if(arto.Id==id)
            {
                arto.IdCategoria=idCate;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per ricevere un articolo tramite il suo nome
    /// </summary>
    /// <param name="nomeSpecific"></param>
    /// <returns></returns>
    public Articolo DammiArticolo(string nomeSpecific)
    {
        var artoProva=new Articolo();
        artoProva=null;
        foreach(var arto in Articoli)
        {
            if(arto.Nome==nomeSpecific)
            {
                artoProva=arto;
            }
        }
        return artoProva!;
    }

    /// <summary>
    /// Metodo che non fa niente di per se, ma inizializza gli articoli<br></br>
    /// in modo che il cliente riesca a caricare la propria lista di articoli acquistati
    /// </summary>
    public void IniziArticolo()
    {
        foreach(var arto in Articoli)
        {
            
        }
    }


    //Area dedicata agli utenti

    /// <summary>
    /// Aggiunta di un cliente pagante
    /// </summary>
    /// <param name="nome">Nome del cliente</param>
    /// <param name="cognome">Cognome del cliente</param>
    /// <returns>Il cliente, in modo da far delle modifiche facoltative come aggiunta di numero o email</returns>
    public Cliente InserisciCliente(string nome, string cognome)
    {
        var clie = new Cliente { Nome = nome, Cognome = cognome, Articoli=new List<Articolo>(), IdArticoli=new List<int>()};
        Clienti.Add(clie);
        SaveChanges();
        return clie;
    }
    /// <summary>
    /// Aggiunta del numero di telefono, possibilmente con un previo controllo delle cifre
    /// </summary>
    /// <param name="clie">Oggetto cliente da modificare</param>
    /// <param name="numero">Numero da aggiungere</param>
    public void InserisciNumCliente(Cliente clie, double numero)
    {
        foreach (var prova in Clienti)
        {
            if (prova == clie)
            {
                prova.Telefono = numero;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Aggiunta dell'email del cliente
    /// </summary>
    /// <param name="clie">Oggetto cliente da modificare</param>
    /// <param name="email">Stringa contenente l'email</param>
    public void InserisciEmCliente(Cliente clie, string email)
    {
        foreach (var prova in Clienti)
        {
            if (prova == clie)
            {
                prova.Email = email;
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per aggiungere diversi articoli all'utente
    /// </summary>
    /// <param name="clie">Oggetto cliente da modificare</param>
    /// <param name="arti">Lista di articoli che il Cliente ha acquistato</param>
    public void InserisciAcquiCliente(Cliente clie, List<Articolo> arti)
    {
        foreach (var prova in Clienti)
        {
            if (prova == clie)
            {
                prova.Articoli!.AddRange(arti);
            }
        }
        SaveChanges();
    }
    /// <summary>
    /// Metodo per aggiungere diversi articoli all'utente, con anche gli id degl iarticoli
    /// </summary>
    /// <param name="clie">Oggetto cliente da modificare</param>
    /// <param name="arti">Lista di articoli che il Cliente ha acquistato</param>
    /// <param name="idArti">Lista di id di ciascun articolo</param>
    public void InserisciAcquiCliente(Cliente clie, List<Articolo> arti, List<int> idArti)
    {
        foreach (var prova in Clienti)
        {
            if (prova == clie)
            {
                prova.Articoli!.AddRange(arti);
                prova.IdArticoli!.AddRange(idArti);
            }
        }
        SaveChanges();
    }
    public void ChangeNameCliente(int id, string nome)
    {
        foreach(var clie in Clienti)
        {
            if(clie.Id==id)
            {
                clie.Nome=nome;
            }
        }
        SaveChanges();
    }
    public void ChangeSurnameCliente(int id, string cognome)
    {
        foreach(var clie in Clienti)
        {
            if(clie.Id==id)
            {
                clie.Cognome=cognome;
            }
        }
        SaveChanges();
    }
    public void ChangeNumberCliente(int id, double numero)
    {
        foreach(var clie in Clienti)
        {
            if(clie.Id==id)
            {
                clie.Telefono=numero;
            }
        }
        SaveChanges();
    }
    public void ChangeEmailCliente(int id, string address)
    {
        foreach(var clie in Clienti)
        {
            if(clie.Id==id)
            {
                clie.Email=address;
            }
        }
        SaveChanges();
    }
    public void EliminaCliente(string nome, string cognome)
    {
        foreach(var cliente in Clienti)
        {
            if(cliente.Nome==nome&&cliente.Cognome==cognome)
            {
                Clienti.Remove(cliente);
            }
        }
        SaveChanges();
    }
    public Cliente DammiCliente(string nome, string cognome)
    {
        var cerca= new Cliente();
        cerca=null;
        foreach(var cliente in Clienti)
        {
            if(cliente.Nome==nome&&cliente.Cognome==cognome)
            {
                cerca=cliente;
            }
        }
        return cerca!;
    }
    public List<Cliente> DammiClienti()
    {
        var clients=Clienti.ToList();
        return clients;
    }
    public List<Cliente> DammiClientiDaIdArto(int idArto)
    {
        var clients=new List<Cliente>();
        foreach(var cliente in Clienti)
        {
            if(cliente.IdArticoli!=null&&cliente.IdArticoli.Count>0)
                foreach(int arto in cliente.IdArticoli)
                {
                    if(arto==idArto)
                    {
                        clients.Add(cliente);
                    }
                }
        }
        return clients;
    }
}
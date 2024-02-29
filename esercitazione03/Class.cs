using Microsoft.EntityFrameworkCore;


class Cliente
{
    public string? nome { get; set; }
    public string? cognome { get; set; }
    public int id { get; set; }
    public string? telefono { get; set; }
    public List<Prodotto>? Prodotti { get; set; }    //foreignkey
}
class Prodotto
{
    public string? nome { get; set; }
    public double prezzo { get; set; }
    public int id { get; set; }
    public int clienteId { get; set; }  //fireugb key
    public Cliente? Cliente { get; set; }
}


class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; } //tabella
    public DbSet<Prodotto> Prodotti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.SQLite");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();

    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList();
        //var clienti = Clienti.ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.id} - {c.nome} {c.cognome}");
            foreach (var p in c.Prodotti!)
            {
                Console.WriteLine($"\t{p.id} - {p.nome} - {p.prezzo}");
            }
        }
    }
    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);
        SaveChanges();
    }
    public void StampaProdotti()
    {
        var prodotti = Prodotti.ToList();
        foreach (var p in Prodotti)
        {
            Console.WriteLine($"{p.id} - {p.nome} - {p.prezzo} - {p.Cliente!.nome} {p.Cliente.cognome}");
        }
    }
}


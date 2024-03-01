class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            Random ran= new Random();
            var clienti= new List<Cliente>
            {
                new Cliente{nome="Mario", cognome="Stoooon", telefono = "1234567890"},
                new Cliente{nome="Luigi", cognome="Stoooon", telefono = "1234567890"},
                new Cliente{nome="Carlito", cognome="Jackson", telefono = "1234567890"},
                new Cliente{nome="Frieren", cognome="Shiun", telefono = "1234567890"},
            };
            db.InserisciClienti(clienti);
            db.SaveChanges();

            db.StampaClienti();
            
            var prodi= new List<Prodotto>
            {
                new Prodotto{nome="Sofa", prezzo=89.99, clienteId=1},
                new Prodotto{nome="Sedia", prezzo=59.99, clienteId=2},
                new Prodotto{nome="Birillo", prezzo=9.99, clienteId=1},
                new Prodotto{nome="Faro", prezzo=129.99, clienteId=3},
                new Prodotto{nome="Gianfranco", prezzo=0.99, clienteId=1},
                new Prodotto{nome="Vaso Ceramica", prezzo=39.99, clienteId=4},
                new Prodotto{nome="Pala", prezzo=9.99, clienteId=3},
                new Prodotto{nome="I TOOOOOOOOOOOOOOOOOl", prezzo=1.99, clienteId=1},
            };
            Console.WriteLine();
            db.InserisciProdotti(prodi);
            db.StampaProdotti();
        }
    }

}
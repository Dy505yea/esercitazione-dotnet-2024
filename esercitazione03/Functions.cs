using System.Data.SQLite;
using Spectre.Console;

namespace Function
{
    class Intern
    {
        public Intern used = new Intern();

        public void VisualizzaGen(string sottoGen, SQLiteConnection connection)
        {
            Console.Clear();
            //inizialmente non doveva esserci la ricerca della categoria, ma dopo aver visto la necessità di cercarlo in un altra funzione associata
            //mi è toccato farlo... magari potrei far in modo da chiamare la funzione dedicata in caso riconoscesse sia una categoria
            string sql = $"SELECT * FROM merce JOIN categorie ON merce.id_categoria = categorie.id WHERE nomeGen = '{sottoGen}' OR nome = '{sottoGen}';";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            var table = new Table();
            table.AddColumns("Nome", "Sottogruppo", "Prezzo", "Quantità", "Categoria");
            while (reader.Read())
            {
                string nome = reader["nomeSpec"].ToString()!;
                string gen = reader["nomeGen"].ToString()!;
                string prezzo = reader["prezzo"].ToString()!;
                string quanti = reader["quantita"].ToString()!;
                string cate = reader["nome"].ToString()!;
                table.AddRow(nome, gen, prezzo, quanti, cate);
                //ricorda, se hai 2 o più variabili con lo stesso nome in diverse tabelle, ti tocca rinominare preventivamente dette variabili perchè il reader tende ad ignorare
                //le occorrenze, priorizzando le variabili della prima tabella menzionata nella SELECT
                //Console.WriteLine($"id: {reader["id"]}, nome: {reader["nomeSpec"]}, sottogruppo: {reader["nomeGen"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria {reader["nome"]}");
            }
            AnsiConsole.Write(table);
        }

        public void VisualizzaCate(SQLiteConnection connection)
        {
            Console.Clear();
            bool done = false;
            int idCate = 0;

            while (idCate <= 0)
            {
                //per evitare di ristampare di nuovo dopo la prima volta
                if (!done)
                {
                    Console.WriteLine("Seleziona la categoria da visualizzare:\n\n1 - Aerofoni\n2 - Cordofoni\n3 - Membranofoni\n4 - Idiofoni\n5 - Miscellanea");
                    done = true;
                }
                ConsoleKeyInfo chiavico = Console.ReadKey(true);
                switch (chiavico.Key)
                {
                    case ConsoleKey.D1:
                        idCate = 1;
                        break;
                    case ConsoleKey.D2:
                        idCate = 2;
                        break;
                    case ConsoleKey.D3:
                        idCate = 3;
                        break;
                    case ConsoleKey.D4:
                        idCate = 4;
                        break;
                    case ConsoleKey.D5:
                        idCate = 5;
                        break;
                }
            }
            Console.Clear();
            string sql = $"SELECT * FROM merce JOIN categorie ON merce.id_categoria = categorie.id WHERE id_categoria = {idCate};";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            var table = new Table();
            table.AddColumns("Nome", "Sottogruppo", "Prezzo", "Quantità", "Categoria");
            while (reader.Read())
            {
                string nome = reader["nomeSpec"].ToString()!;
                string gen = reader["nomeGen"].ToString()!;
                string prezzo = reader["prezzo"].ToString()!;
                string quanti = reader["quantita"].ToString()!;
                string cate = reader["nome"].ToString()!;
                table.AddRow(nome, gen, prezzo, quanti, cate);
            }
            AnsiConsole.Write(table);
        }


        //funzione per fare una prova, per vedere se si riesce a rilevare qualcosa nella select
        public bool TestSelect(string colon, string ric, SQLiteConnection connection)
        {
            //ric si riferisce alla parola ricercata, colon invece alla colonna in cui si sta cercando
            //connection è necessario per continuare a ricevere dal file .db
            string prova = $"SELECT * FROM merce JOIN categorie ON merce.id_categoria = categorie.id WHERE {colon} = '{ric}';";
            SQLiteCommand provando = new SQLiteCommand(prova, connection);
            SQLiteDataReader reader = provando.ExecuteReader();
            if (reader.Read() != false)
            {
                return true;
            }
            return false;
        }

        //funzione per lasciar la scelta di tornare al menù se non si è trovato niente da eliminare
        public bool VuoiTornare()
        {
            Console.WriteLine("Non ho trovato niente, annullare l'operazione?\n(Prema S per si, N per no)");
            while (true)
            {
                ConsoleKeyInfo chiave = Console.ReadKey();
                if (chiave.Key == ConsoleKey.N || chiave.Key == ConsoleKey.S)
                {
                    if (chiave.Key == ConsoleKey.S)
                    {
                        Console.WriteLine("\nRitorno al menù");
                        Thread.Sleep(750);
                        return true;
                    }
                    break;
                }
            }
            return false;
        }
    }
    class Insert : Intern
    {

        public void InserisciMerce()
        {
            bool done = false;
            Console.Clear();
            Console.WriteLine("Seleziona la categoria a cui appartiene:\n");
            int idCate = 0;

            while (idCate <= 0)
            {
                //per evitare di ristampare di nuovo dopo la prima volta
                if (!done)
                {
                    Console.WriteLine("1 - Aerofoni\n2 - Cordofoni\n3 - Membranofoni\n4 - Idiofoni\n5 - Miscellanea\n");
                    done = true;
                }
                ConsoleKeyInfo chiavico = Console.ReadKey(true);
                switch (chiavico.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Hai scelto gli Aerofoni");
                        idCate = 1;
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Hai scelto i Cordofoni");
                        idCate = 2;
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Hai scelto i Membranofoni");
                        idCate = 3;
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Hai scelto gli Idiofoni");
                        idCate = 4;
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Hai scelto Miscellanea");
                        idCate = 5;
                        break;
                }
            }


            Console.WriteLine("Dimmi Il nome specifico");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Dimmi a che sottogruppo appartiene");
            string gruppo = Console.ReadLine()!;
            Console.WriteLine("Dimmi il prezzo");
            string prezzo = Console.ReadLine()!;
            Console.WriteLine("Dimmi quanti");
            string quanti = Console.ReadLine()!;
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
            connection.Open();
            string sql = $"INSERT INTO merce VALUES (NULL, '{nome}', '{gruppo}', {prezzo}, {quanti}, {idCate});";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    class Visual : Intern
    {
        public void VisualizzaTutto()
        {
            Console.Clear();
            SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;");
            connection.Open();
            string sql = "SELECT * FROM merce JOIN categorie ON merce.id_categoria = categorie.id;";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            var table = new Table();
            table.AddColumns("Nome", "Sottogruppo", "Prezzo", "Quantità", "Categoria");
            while (reader.Read())
            {
                string nome = reader["nomeSpec"].ToString()!;
                string gen = reader["nomeGen"].ToString()!;
                string prezzo = reader["prezzo"].ToString()!;
                string quanti = reader["quantita"].ToString()!;
                string cate = reader["nome"].ToString()!;
                table.AddRow(nome, gen, prezzo, quanti, cate);
                //ricorda, se hai 2 o più variabili con lo stesso nome in diverse tabelle, ti tocca rinominare preventivamente dette variabili perchè il reader tende ad ignorare
                //le occorrenze, priorizzando le variabili della prima tabella menzionata nella SELECT
                //Console.WriteLine($"id: {reader["id"]}, nome: {reader["nomeSpec"]}, sottogruppo: {reader["nomeGen"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria {reader["nome"]}");
            }
            AnsiConsole.Write(table);
            connection.Close();
        }

        public void VisualizzaGruppo()
        {
            Console.Clear();
            SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;");
            connection.Open();
            Console.WriteLine("Si cerca per sottogruppo o per categoria?\n\n1 - Sottogruppo\n2 - Categoria\n3 - Annulla");
            bool done = false;
            while (!done)
            {
                ConsoleKeyInfo chiave = Console.ReadKey(true);
                switch (chiave.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Mi dica che sottogruppo sta cercando");
                        string ric = Console.ReadLine()!;
                        bool mostrato = true;
                        while (!done)
                        {
                            done = used.TestSelect("nomeGen", ric, connection);
                            mostrato = done;
                            if (!done)
                            {
                                done = VuoiTornare();
                                if (!done)
                                {
                                    Console.WriteLine();
                                    ric = Console.ReadLine()!;
                                }
                            }
                        }
                        VisualizzaGen(ric, connection);
                        if (mostrato)
                        {
                            Console.WriteLine("\n\nPremere qualsiasi pulsante per continuare");
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D2:
                        VisualizzaCate(connection);
                        Console.WriteLine("\n\nPremere qualsiasi pulsante per continuare");
                        Console.ReadKey();
                        done = true;
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Ritorno al menù");
                        Thread.Sleep(750);
                        return;
                }
            }
            connection.Close();
        }
    }
    class Elim : Intern
    {
        public void EliminaMerceSpecifica()
        {
            Console.WriteLine("Mi scriva il nome del prodotto da eliminare dalla tabella sovrastante");
            string nome = Console.ReadLine()!;
            SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;");
            connection.Open();
            bool done = false;
            while (!done)
            {
                done = TestSelect("nomeSpec", nome, connection);
                if (!done)
                {
                    done = VuoiTornare();
                    if (!done)
                    {
                        nome = Console.ReadLine()!;
                    }
                }
            }

            string sql = $"DELETE FROM merce WHERE nomeSpec = '{nome}';";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void EliminaMerceRicerca()
        {
            /*vuoi poter prima cercare un termine, in sto caso solo ed esclusivamente il sottogruppo, dato che in questo database non ci sono caratteristiche
            utile per quando la tabella è troppo fitta*/
            Console.WriteLine("A che sottogruppo appartiene il prodotto?");
            string gen = Console.ReadLine()!;
            SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;");
            connection.Open();
            bool done = false;
            //aggiungo anche un secondo bool che servirà ad indicare se ha trovato una categoria invece
            bool node = false;
            //il seguente bool serve per evitare di fare alcune procedure in un caso specifico
            bool gone = false;
            while (!done)
            {
                done = TestSelect("nomeGen", gen, connection);
                //creo una stringa temporanea, a differenza dei sottogruppi, voglio che le categorie sian più facilmente trovabili anche se si
                //sbaglia a mettere o meno delle lettere maiuscole o minuscole
                string prova = gen.ToLower();
                prova = char.ToUpper(prova[0]) + prova.Substring(1);
                node = TestSelect("nome", prova, connection);
                //il motivo di ciò è per lasciar passare quando si è trovata la categoria
                if (node)
                {
                    done = node;
                    gen = prova;
                }
                if (!done)
                {
                    done = VuoiTornare();
                    if (!done)
                    {
                        Console.WriteLine();
                        gen = Console.ReadLine()!;
                    }
                    else
                    {
                        //in questo caso, l'utente vuole tornare al menù, quindi gone eviterà di fare alcune procedure
                        gone = true;
                    }
                }
            }


            if (!gone)
            //gone determina se la ricerca del sottogruppo è stata terminata precariamente
            {
                VisualizzaGen(gen, connection);
                Console.WriteLine("Seleziona il prodotto da eliminare");
                string nome = Console.ReadLine()!;
                done = false;
                while (!done)
                {
                    done = TestSelect("nomeSpec", nome, connection);
                    if (!done)
                    {
                        done = VuoiTornare();
                        if (!done)
                        {
                            Console.WriteLine();
                            nome = Console.ReadLine()!;
                        }
                    }
                }

                string sql = $"DELETE FROM merce WHERE nomeSpec = '{nome}';";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            //infatti la procedura sovrastante accade solo se si ha trovato un sottogruppo
            connection.Close();

        }
    }

}

namespace Theory{
    /*I'm just gonna use this as a sort of way to think what is the best course of action---
    So, for now the product is an instrument, with some data and connected to one of the 5 categories
    now, what we need from this db?
    for now it has 3 main functions: add, show and delete
    when we add, the program so far already tells all the stuff to put inside a db...
    when we show, there's already a way to research from db...
    when we delete, is something connected with showing stuff...
    
    what classes could add to the overall functionality?
    so, a class could be used to create a list, a list of one type of object, maybe use it as a way to store data without having to deal with the db file until
    it's really necessary and there are only 2 cases: add and delete
    now, the visualize could be the main reason for this thing, putting a list of various articles with all the data, name of category included
    a way to not have to access all the time with the db file, doing the thing only after everything was done
    so open and close the connection only in the moment of the action
    
    alright, let's start from the very beggining: checking the db
    when you open the program, the first thing should be checking the db and collecting all the data (just now i though about merging with json)
    from the db file, this list of object will be collected and then the connection will be closed 'till the next necessary connection
    
    add: first, the user must put stuff, all of that must be put inside the object and only when finished, the db fil will be accessed
    from then on, the object will be the one putting the data, then close it right away
    
    show: this is only done with the object, try to find a way to make a sort of select with just
    
    
    
    
    
    allright, let's change everything to use json.... each json file will be built just like the one you did in programmino folder
    in this case, the object will be influenced by both db and json standard, all in order to contain the needed information
    
    so... the db file will contain the least info necessary, while json will have a bit of extra, however the problem will rise when in db
    there's something that json doesn't, description will have nothing, so maybe a way to change some information in teh future
    in the add, you should add a description field, something that will not interfere with db but will help*/
}



namespace Basedata
{
    class Articolo
    {
        private int id;
        private int id_cate;
        public string nomeSpec;
        public string nomeGen;
        public float prezzo;
        public int quantita;
        public Articolo(string nomeSpec, string nomeGen, float prezzo, int quantita)
        {
            this.nomeSpec = nomeSpec;
            this.nomeGen = nomeGen;
            this.prezzo = prezzo;
            this.quantita = quantita;
        }
        public Articolo(int id, string nomeSpec, string nomeGen, float prezzo, int quantita, int id_cate)
        {
            this.nomeSpec = nomeSpec;
            this.nomeGen = nomeGen;
            this.prezzo = prezzo;
            this.quantita = quantita;
            this.id = id;
            this.id_cate = id_cate;
        }
        public void SetArticoloIds(int id, int id_cate)
        {
            this.id = id;
            this.id_cate = id_cate;
        }
        public (int, string, string, float, int, int) GetWholeArticolo()
        {
            return (id, nomeSpec, nomeGen, prezzo, quantita, id_cate);
        }
        public void StampArticolo()
        {
            Console.WriteLine($"Id: {id}\nNome completo: {nomeSpec}\nGruppo d'appartenenza: {nomeGen}\nPrezzo: {prezzo}\nQuantità: {quantita}\nId della categoria: {id_cate}");
        }
    }
    class Categoria
    {
        private int id;
        public string nome {get; set;}
        public Categoria(string nome)
        {
            this.nome = nome;
        }
        public void SetIdCate(int id)
        {
            this.id = id;
        }
        public (int, string) GetWholeCate()
        {
            return (id, nome);
        }
        public void StampaCate()
        {
            Console.WriteLine($"Id: {id}\nNome: {nome}");
        }
    }
}
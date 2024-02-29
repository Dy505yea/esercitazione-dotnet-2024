using System.Data.SQLite;
using Spectre.Console;

using Function;

class Programm
{
    /*
        uwuwuewue olumuwuewue ossas
        the old days of chansing down shadows
        what remains are vain memories
        as if a   fire swept right over me
        i must look just like a candle



    Se vuoi un idea di aggiungere un qualcosaltro, pensa ai produttori di strumenti musicali,
    fai una tabella apposita per collegarli anche ai strumenti dove serve, chi appartiene alla categoria Misc avrà
    un altro tipo di produttore, dato che non si tratta di strumenti musicali, ma cose relative ad esse
    */

    /*static void Main(string[] args)
    {
        Insert ins = new Insert();
        Visual vis = new Visual();
        Elim el = new Elim();

        string path = @"database.db";
        string sqlpath = @"database through sql\scrFirsTime.sql";
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");
            connection.Open();
            string sql = "";
            try
            {
                sql = File.ReadAllText(sqlpath);
            }
            catch
            {
                Console.WriteLine("File sql non trovato... tocca per proseguire");
                Console.ReadKey();
                sql = @"
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita>=0));
                        INSERT INTO prodotti VALUES (NULL, 'p1', 3.99, 10);
                        INSERT INTO prodotti VALUES (NULL, 'p2', 3.99, 20);
                        INSERT INTO prodotti VALUES (NULL, 'p3', 2.99, 10);
            ";
            }
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 - inserisci\n2 - visualizza tutto\n3 - visualizza un sottogruppo\n4 - elimina da nome\n5 - elimina da sottogruppo\n6 - esci\nScegli");
            ConsoleKeyInfo chiavico = Console.ReadKey(true);
            switch (chiavico.Key)
            {
                case ConsoleKey.D1:
                    ins.InserisciMerce();
                    break;
                case ConsoleKey.D2:
                    vis.VisualizzaTutto();
                    Console.WriteLine("\n\nPremere qualsiasi pulsante per continuare");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    vis.VisualizzaGruppo();
                    break;
                case ConsoleKey.D4:
                    //credo sia meglio se si potesse anche vedere cosa c'è nel database, in modo da non obbligare di ricordare a memoria
                    vis.VisualizzaTutto();
                    //Console.Clear();
                    el.EliminaMerceSpecifica();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    el.EliminaMerceRicerca();
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("\n\nAddios");
                    return;
            }
        }
    }*/
}
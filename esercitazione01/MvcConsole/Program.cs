using System.ComponentModel.Design;
using System.Data.Entity;
using System.Data.SQLite;
using Microsoft.VisualBasic;

namespace ModVisCon
{
    class Program
    {
        static void Main(string[] args)
        {
            Database model = new Database();
            View view = new View(model);
            Controller control = new Controller(model, view);
            control.MainMenu();
        }
    }
    class Database
    {
        private SQLiteConnection _connection;
        public Database()
        {
            _connection = new SQLiteConnection("Data Source=database.db");
            _connection.Open();
            var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (ID INTEGER PRIMARY KEY, name TEXT)", _connection);
            command.ExecuteNonQuery();
        }
        public void AddUser(string name)
        {
            var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
            command.ExecuteNonQuery();
        }
        public void DeleteUser(string name)
        {
            var command = new SQLiteCommand($"DELETE FROM users WHERE (name) = ('{name}')", _connection);
            command.ExecuteNonQuery();
        }
        public List<string> GetUsers()
        {
            var command = new SQLiteCommand("SELECT name FROM users", _connection);
            var reader = command.ExecuteReader();
            var users = new List<string>();
            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }
            return users;
        }
        public void UpdateUser(string name, string target)
        {
            var command = new SQLiteCommand($"UPDATE users SET (name) = ('{name}') WHERE (name) = ('{target}')", _connection);
            command.ExecuteNonQuery();
        }
    }

    class View
    {
        private Database _db;
        public View(Database db)
        {
            _db = db;
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("1. Aggiungi user");
            Console.WriteLine("2. Leggi user");
            Console.WriteLine("3. Aggiorna user");
            Console.WriteLine("4. Elimina user");
            Console.WriteLine("5. Esci");
        }
        public void ShowUsers(List<string> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
        public string GetInput()
        {
            return Console.ReadLine()!;
        }
    }
    class Controller
    {
        private Database _db;
        private View _view;
        public Controller(Database db, View view)
        {
            _db = db;
            _view = view;
        }
        public void MainMenu()
        {
            while (true)
            {
                _view.ShowMainMenu();
                var input = _view.GetInput();
                if (input == "1")
                {
                    AddUser();
                }
                else if (input == "2")
                {
                    ShowUser();
                }
                else if (input == "3")
                {
                    UpdateUser();
                }
                else if (input == "4")
                {
                    DeleteUser();
                }
                else if (input == "5")
                {
                    break;
                }
            }
        }
        private void AddUser()
        {
            Console.WriteLine("Enter user name:");
            var name = _view.GetInput();
            _db.AddUser(name);
        }
        private void ShowUser()
        {
            var users = _db.GetUsers();
            _view.ShowUsers(users);
        }
        private void DeleteUser()
        {
            var users = _db.GetUsers();
            _view.ShowUsers(users);
            Console.WriteLine("\nEnter user to delete:");
            var name = _view.GetInput();
            _db.DeleteUser(name);
        }
        private void UpdateUser()
        {
            var users = _db.GetUsers();
            _view.ShowUsers(users);
            Console.WriteLine("\nEnter user to modify:");
            var target = _view.GetInput();
            Console.WriteLine("\nEnter new name:");
            var name = _view.GetInput();
            _db.UpdateUser(name, target);
            users = _db.GetUsers();
            _view.ShowUsers(users);
        }
    }
}
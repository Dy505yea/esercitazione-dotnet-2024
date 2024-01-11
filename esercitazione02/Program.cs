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
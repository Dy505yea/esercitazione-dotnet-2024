class Program
    {
        static void Main(string[] args)
        {
            string[] nomi=new string[] {"Mario", "Luigi", "Giorgio"};
            foreach(string nome in nomi)
            {
                Console.WriteLine($"Ciao {nome}");
            }
        }
    }
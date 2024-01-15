class Program
    {
        static void Main(string[] args)
        {
            List<string> nomi=new List<string>();
            nomi.Add("Rossi");
            nomi.Add("Luigi");
            nomi.Add("Lorenzo");
            int i=0;
            while(i<nomi.Count)
            {
                Console.WriteLine($"Ciao {nomi[i]}");
                i++;
            }
        }
    }
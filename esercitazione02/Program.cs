class Program
    {
        static void Main(string[] args)
        {
            int i=1;
            int subject=16;
            Console.WriteLine($"Fammi contare almeno dopo il 2, poi ti dico cosa può già dividere il numero {subject}");
            while((subject%i)!=0||i<=2)
            {
                if(i==1)
                    Console.WriteLine($"{i} sasso");
                else
                    Console.WriteLine($"{i} sassi");
                Console.WriteLine($"Passo\n");
                i++;
            }
            Console.WriteLine($"Per dividere il numero {subject}, va bene il numero {i}");
        }
    }
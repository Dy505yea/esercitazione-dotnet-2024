class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear(); // Pulisce la console ad ogni iterazione
        int i=0;
        while(true)
        {
            Console.WriteLine("Hai 3 opzioni:\n\n-1 Per fare na piccola prova col cursore\n-2 Per pulire la console\n-3 per beepare\n-4 titolo");
            i= Convert.ToInt32(Console.ReadLine());
            if(i<5&&i>0)
            {
                break;
            }
        }
        Console.Title="Na piccola provetta";
        string titolo=Console.Title;
        switch(i)
        {
            case 1:
                Console.CursorVisible=false;
                Console.WriteLine("Dimmi quando vuoi fermarti pigiando qualsiasi cosa");
                Console.ReadKey();
                Console.CursorVisible=true;
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Tutto pulito");
                break;
            case 3:
                Console.Beep();
                Console.Beep(750, 300);
                Console.WriteLine($"Fatto");
                break;
            case 4:
                Console.WriteLine($"{titolo}");
                break;
        };
    }
}
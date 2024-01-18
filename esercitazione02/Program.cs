class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Da qui un numero\n");
        double x = double.Parse(Console.ReadLine());
        double result = 0;
        Console.WriteLine($"Hai 3 possibili operazioni:\n- Radice quadrata (metti 'v')\n- Quadrato (metti 'q')\n- Cubo (metti 'c')");
        while (true)
        {
            string opera = Console.ReadLine();
            bool fax = false;
            switch (opera)
            {
                case "v":
                    result = Math.Sqrt(x);
                    Console.WriteLine($"Radice selezionata");
                    break;
                case "q":
                    result = Math.Pow(x, 2);
                    Console.WriteLine($"Quadro selezionato");
                    break;
                case "c":
                    result = Math.Pow(x, 3);
                    Console.WriteLine($"Cubo selezionato");
                    break;
                default:
                    Console.WriteLine($"Operazione non valida");
                    fax=true;
                    break;
            }
            if(!fax)
            {
                break;
            }
        }
        Console.WriteLine($"\nTi mostrerò il risultato in 3 modi");
        var strano=result.ToString("#.##"); //è mera rappresentazione, i cancelletti son i decimali, il punto prima invece è generalizzazione
        double rocco= Math.Round(result, 4);
        Console.WriteLine($"Dal tronco: {Math.Truncate(result)}");  //tronca il numero fino all'integrale
        Console.WriteLine($"Dalla rotonda: {rocco}");               //arrotonda
        Console.WriteLine($"Da rappresentazione modificata {strano}");
    }
}
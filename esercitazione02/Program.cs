class Program
{
    static void Main(string[] args)
    {
        /*
        txt 2-3 linee
        nome
        punteggio
        partita aggiorna punteggio
        */
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella
        string pathFin=@"..\esercitazione02\la provetta\kricko.txt";

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        Random ran= new Random();
        int indx= ran.Next(lines.Length);
        Console.WriteLine($"{lines[indx]}");
        if(!File.Exists(pathFin))
            File.Create(pathFin).Close();
        if(!File.ReadAllLines(pathFin).Contains(lines[indx]))
            File.AppendAllText(pathFin, lines[indx]+"\n");
        else
            Console.WriteLine("Capooh, noi già abiamo meso la frase");
    }
}
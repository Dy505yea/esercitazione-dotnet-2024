class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //la @ dovrebbe indicare la cartella in cui il programma viene eseguito
        //se fosse stato nel desktop, sarebbe come aver messo "C:\Users\Utente\Desktop\filechevuoite.txt"
        string path=@"..\esercitazione02\la provetta\test.txt"; //su c# almeno, i ".." indicano andare su di una cartella

        string[] lines=File.ReadAllLines(path);                 //legge tutte le linee separatamente, mettendole in un array
        Random ran= new Random();
        int indx= ran.Next(lines.Length);
        Console.WriteLine($"{lines[indx]}");
        string pathFin=@"..\esercitazione02\la provetta\kricko.txt";
        File.Create(pathFin).Close();
        File.AppendAllText(pathFin, lines[indx]+"\n");
    }
}
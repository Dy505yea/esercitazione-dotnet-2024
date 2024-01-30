class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string path=@"..\esercitazione01\provadicsv\jason.csv";
        string[] lines=File.ReadAllLines(path);//a differenza di un file di testo, pare che ogni linea sia un array, generando quindi una matrice invece di un solo array
        string[][] nomi= new string[lines.Length][];//per questo motivo, per copiare il testo, si necessita di una matrice di string
        for(int i=0; i<lines.Length; i++)
        {
            nomi[i]=lines[i].Split("|");//uno può utilizzare ciò che vuole, ma è alquanto importante decidere cosa usare per via della memoria usata per lo split in base al carattere
        }
        foreach(string[] nome in nomi)
        {
            string path2=@"..\esercitazione01\provadicsv\"+nome[0]+".csv";
            File.Create(path2).Close();
            for(int i=1; i<nome.Length; i++)
            {
                File.AppendAllText(path2, nome[i]+"\n");
            }
        }
        //File.Delete("nome.csv");
    }
}
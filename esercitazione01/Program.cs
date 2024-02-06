using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path=@"JaSon\newstufftho.json";
        File.Create(path).Close();
        File.AppendAllText(path, "[\n");
        bool continua=true;
        while(continua)
        {
            Console.WriteLine("Me dica un nome ed un numerino");
            string nome=Console.ReadLine()!;
            string prezzo=Console.ReadLine()!;
            File.AppendAllText(path, "\t"+JsonConvert.SerializeObject(new {nome, prezzo}));
            Console.WriteLine("Aight, again? (y/n)");
            string risposta=Console.ReadLine()!;
            if(risposta=="n")
            {
                continua=false;
                File.AppendAllText(path, "\n");
            }
            else
            {
                File.AppendAllText(path, ",\n");
            }
        }
        string file=File.ReadAllText(path);
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]");
    }
}
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using sostanzialmenterazor.Pages;

public class Jsonator{
    public Dictionary<string, dynamic> Prototype{get; set;}
    public List<Dictionary<string, dynamic>> ListProto{get; set;}
    public Jsonator(List<Prodotti> pro){
        foreach(var prodotto in pro)
        {
            tryAdd("nome", prodotto.Nome);
            tryAdd("prezzo", prodotto.Prezzo);
            tryAdd("descrizione", prodotto.Descrizione);
            ListProto.Add(Prototype);
        }
    }
    public void Serialization()
    {
        string path=@"data\Prodotti.json";
        if(!File.Exists(path))
        {
            File.Create(path).Close();
            File.WriteAllText(path, "[\n\n]");
        }
        string[] testo=File.ReadAllLines(path);
    }
    public void tryAdd(string key, dynamic value)
    {
            try{
                Prototype.Add(key, value);
            }
            catch
            {
                Prototype[key]=value;
            }
    }
}
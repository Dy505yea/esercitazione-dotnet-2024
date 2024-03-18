using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using sostanzialmenterazor.Pages;

public class Jsonator{
    public Dictionary<string, dynamic> Prototype{get; set;}
    public List<Dictionary<string, dynamic>> ListProto{get; set;}
    public Jsonator(IEnumerable<Prodotti> pro){
        foreach(var prodotto in pro)
        {
            tryAdd("nome", prodotto.Nome!);
            tryAdd("prezzo", prodotto.Prezzo);
            tryAdd("descrizione", prodotto.Descrizione!);
            ListProto!.Add(Prototype!);
        }
    }
    public void NewSerialization()
    {
        string path=@"..\data\Prodotti.json";
        if(!File.Exists(path))
        {
            File.Create(path).Close();
            File.WriteAllText(path, "[\n\n]");
        }
        List<string> jsonList=new List<string>();
        jsonList.Add("[");
        string[] testo=File.ReadAllLines(path);
        foreach(var proto in ListProto)
        {
            jsonList.Add("{");
            jsonList.Add(JsonConvert.SerializeObject(new{Nome=proto["nome"], Prezzo=proto["prezzo"], Descrizione=proto["descrizione"]}, Formatting.Indented));
            jsonList.Add("},");
        }
        jsonList.Add("]");
        File.WriteAllLines(path, jsonList.ToArray<string>());

        //prendo dati delle classi
        //li converto in dati json
        //li serializzo
        //li salvo mettendo un ] alla fine identato possibilmente
        //il salvataggio deve essere sovrascrittura
        //in questa funzione, si aggiunge e basta, non si modifica da 0
        /*
        scusatemi, oggi proprio il mio cervello non funziona
        non soppravivrò laffuori....
        magari mi sarà di lezione
        */
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
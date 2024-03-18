using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace sostanzialmenterazor.Pages
{
    public class ProdottoModel : PageModel
    {
        public Prodotti? Prodotto { get; set; }
        public void OnGet(string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotti>>(json);
            Prodotto = prodotti!.FirstOrDefault(p => p.Nome == nome);
                /*
                si crea p
                i prodotti sono presi da json, deserializzati
                da stringa a oggetto (o meglio, in lista di oggetti)
                p diviene il primo oggetto con il nome ricercato in lambda
                prodotto prende quell'oggetto
                */
        }
    }
}
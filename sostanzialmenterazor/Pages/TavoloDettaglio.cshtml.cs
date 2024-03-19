using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace sostanzialmenterazor.Pages
{
    public class TavoloDettaglioModel : PageModel
    {
        public Tavolo Tavolo{ get; set; }
        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText("Pages/Tavoli.json");
            var tavoli = JsonConvert.DeserializeObject<List<Tavolo>>(json);
            Tavolo = tavoli!.FirstOrDefault(t => t.Id == id);
        }
    }
}
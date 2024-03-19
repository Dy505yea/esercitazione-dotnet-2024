using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace sostanzialmenterazor.Pages;

public class TavoloModel : PageModel
{
    public IEnumerable<Tavolo> Tavoli{get; set;}
    private readonly ILogger<TavoloModel> _logger;

    public TavoloModel(ILogger<TavoloModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("Pages/Tavoli.json");
        Tavoli = JsonConvert.DeserializeObject<List<Tavolo>>(json);
    }
}

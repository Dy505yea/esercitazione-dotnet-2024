using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sostanzialmenterazor.Pages;

public class ProdottoModel : PageModel
{
    public Prodotti? Prodotto { get; set; }
    private readonly ILogger<ProdottoModel>? _logger;
    public ProdottoModel(ILogger<ProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string nome, string dettaglio, decimal prezzo)
    {
        Prodotto = new Prodotti{ Nome = nome, Prezzo = prezzo, Descrizione = dettaglio};
        //log per possibili debug in caso di necessità
        _logger!.LogInformation("Stai guardando dei dettagli del prodotto scelto");
    }
}

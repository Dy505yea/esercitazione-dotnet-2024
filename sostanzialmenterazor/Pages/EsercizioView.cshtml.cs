using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace sostanzialmenterazor.Pages;

public class ViewModel : PageModel
{
    public IEnumerable<Persona> Persone{get; set;}
    private readonly ILogger<ViewModel> _logger;

    public ViewModel(ILogger<ViewModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("Pages/DylannZambrano.json");
        Persone = JsonConvert.DeserializeObject<List<Persona>>(json);

    }
}


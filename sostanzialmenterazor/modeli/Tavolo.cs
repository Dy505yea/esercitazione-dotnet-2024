using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
public class Tavolo
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Materiale {get; set;}
    public string? Colore {get; set;}
    public decimal Larghezza {get; set;}
    public decimal Lunghezza {get; set;}
    public decimal Altezza {get; set;}
    public decimal Prezzo {get; set;}
}
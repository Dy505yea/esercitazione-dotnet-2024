using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;
/// <summary>
/// Informazioni di un cliente che ha comprato dal negozio<br></br>
/// Il suoi nome e cognome<br></br>
/// Il suo numero di cellulare/telefono, se lo ha dato<br></br>
/// Il suo indirizzo email, se lo ha dato<br></br>
/// La lista degli articoli che ha comprato dal negozio
/// </summary>
class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public double Telefono { get; set; }
    public string? Email { get; set; }
    public List<Articolo>? Articoli { get; set; }
    public List<int>? IdArticoli {get; set;}
}
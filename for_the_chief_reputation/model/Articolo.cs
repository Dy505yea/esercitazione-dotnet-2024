using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Un articolo<br></br>
/// Contiene il nome completo che si mostrerà su internet/targhetta in negozio<br></br>
/// Un nome più generico (esempio: Il gruppo di un Violino Stradivario 3/4 è Violino)<br></br>
/// La quantità nel magazzino<br></br>
/// Il prezzo di vendita<br></br>
/// L'id della categoria associata<br></br>
/// </summary>
class Articolo
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Gruppo { get; set; }
    public int Quantità { get; set; }
    public double Prezzo { get; set; }
    public int IdCategoria { get; set; }
    public Categoria? Categoria { get; set; }

    

}
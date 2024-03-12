using System.Data.SQLite;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;


/// <summary>
/// Classe acquisto<br></br>
/// Con acquisto, si intende un articolo acquistato che appartiene a uno o più clienti<br></br>
/// Il motivo dietro all'aggiunta di questa classe è per ovviare al problema degi clienti<br></br>
/// in competizione per uno stesso articolo
/// <br></br>L'acquisto contiene sia l'id del cliente che dell'articolo d'appartenenza
/// <br></br>Avrà anche un proprio id, quindi deve essere possibile creare molti
/// </summary>
class Acquisto
{
    public int Id {get; set;}
    public int IdCliente {get; set;}
    public int IdArticolo {get; set;}
    //public Cliente cliente {get; set;}
    //public Articolo articolo {get; set;}
}
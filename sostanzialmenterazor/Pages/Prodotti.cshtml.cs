using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sostanzialmenterazor.Pages;
public class ProdottiModel : PageModel
{
    public IEnumerable<Prodotti>? Prodotti {get; set;}
    private readonly ILogger<ProdottiModel>? _logger;
    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }


    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        Prodotti=new List<Prodotti>
        {
            new Prodotti{Nome= "Stufato Precotto", Prezzo=5.99m, Descrizione="Stufato preparato, cucinato, fatto in industria,pronto da riscaldare al microonde o in bollitura per 4 minuti"},
            new Prodotti{Nome= "Provetta", Prezzo=18.99m, Descrizione= "Prova per provare se la provetta di provole provava profazioni"},
            new Prodotti{Nome= "Kricko", Prezzo=100m, Descrizione="Uno de los pinguinos de malavascas: kricko :D"},
            new Prodotti{Nome= "Prova 04", Prezzo=405.32m, Descrizione="Prova 04"},
            new Prodotti{Nome= "Prova 05", Prezzo=1.45m, Descrizione="Prova 05"},
            new Prodotti{Nome= "Prova 06", Prezzo=184.51m, Descrizione="Prova 06"},
            new Prodotti{Nome= "Prova 07", Prezzo=73.43m, Descrizione="Prova 07"},
            new Prodotti{Nome= "Prova 08", Prezzo=934m, Descrizione="Prova 08"},
            new Prodotti{Nome= "Prova 09", Prezzo=312m, Descrizione="Prova 09"},
            new Prodotti{Nome= "Prova 10", Prezzo=300m, Descrizione="Prova 10"},
        };
        string min="";
        string max="";
        if(minPrezzo.HasValue)
        {
            Prodotti=Prodotti.Where(p=> p.Prezzo>=minPrezzo);
            min=", il minimo è "+minPrezzo;
        }
        if(maxPrezzo.HasValue)
        {
            Prodotti=Prodotti.Where(p=> p.Prezzo<=maxPrezzo);
            max=", il massimo è "+maxPrezzo;
        }
        /*
        prova a immagazzinare il tutto su un file json


        il json dovrà essere tipo:
        [
            {
                "id":3,
                "nome":"",
                "prezzo":4.5,
                "descrizione":"",
            },
            {
                ...
            },
            ...
            ...,
            }
        ]

        pensa ad un modo di farli identati come mostrato, in modo da poter modificare l'ultima parte e
        metterla in scrittura
        magari usa una lista di dizionari, in modo da trovare il dizionario che ha X attributo a Y,
        da li modificare ciò che vuoi e possibilimente più oggetti alla volta e da lì
        metteli sul json n una volta sola fatto le modifiche/aggiunte/eliminazioni (si, basta rimuovere un dizionario dalla lista di dizonari)
        */
        
        //Prodotti=Prodotti.Skip(((pageIndex ?? 1)-1)*2).Take(2);
        //log per possibili debug in caso di necessità
        _logger!.LogInformation("Prodotti filtrati per prezzo"+min+max);
    }
}
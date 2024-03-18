using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace sostanzialmenterazor.Pages
{
    public class ProdottiModel : PageModel
    {
        public IEnumerable<Prodotti>? Prodotti { get; set; }
        private readonly ILogger<ProdottiModel>? _logger;
        public ProdottiModel(ILogger<ProdottiModel> logger)
        {
            _logger = logger;
        }
        public int numeroPagine { get; set; }
        public void OnGet(decimal? min, decimal? max, int? pageIndex)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            Prodotti = JsonConvert.DeserializeObject<List<Prodotti>>(json);
            if (min.HasValue)
            {
                Prodotti = Prodotti!.Where(p => p.Prezzo >= min);
                /*
                si crea p
                p deve essere l LIST di prodotti DOVE il prezzo ha almeno il min
                */
            }
            if (max.HasValue)
            {
                Prodotti = Prodotti!.Where(p => p.Prezzo <= max);
                /*
                si crea p
                p deve essere l LIST di prodotti DOVE il prezzo non supera il max
                */
            }
            numeroPagine = (int)Math.Ceiling(Prodotti!.Count() / 5.0);
            /*
            si prende il numero di pagine tra cui si possano visualizzare i prodotti
            si divide per quanti prodotti si hanno per pagina
            */
            Prodotti = Prodotti!.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
            /*
            si riducono i numeri di prodoti visualizzabili per un massimo di 5 alla volta
            page index indica in quale pagina si è, da lì si sceglie da quale prodotto, per andare in giù
            visualizzare la pagine, per un massimo di (in questo caso) 5 (take è il numero di oggetti massimi da poter prendere)
            */


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
            _logger!.LogInformation("Prodotti filtrati per prezzo" + min + max);



        }
    }
}
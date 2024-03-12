# Entity Framework del negozio di strumenti musicali

## Definizione della struttura

Il database avrà per ora 3 tabelle: le categorie degli strumenti, gli articoli ed i clienti che hanno comprato da lì

Le categorie avranno:
- Nome della categoria
- Id
- Lista degli articoli associati
<p>
La categoria è predefinita: sono 5 e sono strumenti a corda, a fiato, a percussioni, tastiere e altro per ciò che non è uno strumento principale<br>
</p>
Gli articoli avranno:

- Nome completo, cioè un nome come "Violino Stradivario 3/4", dato che possono esserci molti modelli per lo stesso strumento
- Id
- Gruppo, inteso come gruppo di appartenenza, famiglia di strumenti o anche solo una speie di categoria a parte, come "Violino" per "Violino Stradivario 3/4"
- Quantità in stock nel magazzino
- Prezzo di vendita
- La categoria di appartenenza
- Id della categoria

I clienti avranno:
- Nome (obbligatorio)
- Cognome (obbligatorio)
- Telefono
- Email
- Lista di articoli comparti dal negozio

## Funzionamento
<p>
Il programma avrà 2 funzionalità:<br>
Gestione del negozio (articoli e clienti)<br>
Menu per il cliente<br>

La gestione degli articoli conterrà queste funzioni:

    - Aggiunta di un articolo
    - Visualizzazione degli articoli (con 3 diversi modi di visualizzarli: per intero, per categoria o per gruppo d'appartenenza)
    - Modifica di un singolo articolo
    - Eliminazione di un articolo

"Vendita di x articoli ad un cliente":

    - Azione di vendita per un cliente ripetibile
    - Imissione di almeno dati necessari del cliente
    - Selezione di articolo
    - Cambio dati nel magazzino alla fine del processo con possibilità di eliminare in una condizione specifica
Visualizzazione dei clienti per intero<br>
// per articolo che hanno comprato in comune (per ora faccio tramite una categoria che degli articoli comprati avevano in comune)<br>
Visualizzazione di un cliente specifico e di ciò che ha comprato<br>
</p>

## Modello MVC: Suddivisione dei compiti
<p>

Model conterrà sia le classi da cui basare la struttura che le funzioni di cui agiranno sul database:
- Aggiunta di un record
- Eliminazione di un record
- Modifica di un record
- Get di tutti i record di x tabella
- // di record con y attributi in comune di x tabella

Inoltre alcune funzioni dovranno ritornare vero o falso (o qualche altro tipo di dato) in caso di qualche problema

View tratterà di tutto ciò che riguarda alla visualizzazione, tra cui stampe di informazioni, errori e anche dell'input:
- Gestione dei possibili errori da input
- Visualizzazione dei record e la gestione degli errori nella ricerca

Controller è la cosa principale:<br>
All'inizio c'è un controllo se la tabella dei generi è già formattata con le 5 categorie, altrimenti la si rifà
> pensavo anche ad un ulteriore controllo per vedere se gli articoli fosserò collegati alle categorie, in modo da riprendere i dati e metterle nelle categorie

Da lì, si farà un ciclo while condizionato da una variabile bool che verrà modificata alla fine di una qualsiasi operazione:<br>
Quindi l'operazione principale viene eseguita da una funzione:<br>
La funzione effettuerà lo using con il menù e quantaltro, ma finirà sempre dopo una qualsiasi operazione<br>
Ritornerà sempre falso finchè l'utente non decide di uscire

Ora, il menù avrà le opzioni elencate nel funzionamento, magari suddivise in funzioni correlate agli articoli e quelle correlate ai clienti<br>
Principalmente si occuperà di unire a modo le funzioni di view e model
</p>
# BETA TESTING PROGRAMMA "Traccia Alimenti Frigo" DI SIMONE

## Richiesta

Controllo di vari bug, priorizzando la gestione dei vari errori

## Problematiche Durante Il Test

### Collegate alla richiesta

- Se il file csv per l'importazione non aveva più di una riga, non conta come errore, ignorando cosa c'è dentro, dicendo però all'utente che ha importato qualcosa
- Se c'è gia un file "inserito.csv" nella cartella files/temp, avviene un errore non gestito quando si prova ad importare un altro file "inserisci.csv"

### Rilevate senza tener troppo conto dell'obbiettivo

#### Grafico

- Quando richiede di premere invio per continuare, il programma non tiene conto di che tasto viene usato, andando avanti comunque premendo un qualsiasi altro pulsante
- Durante l'eliminazione di un alimento, se il frigo è vuoto, invece di dare il solito messaggio "premi invio per andare avanti...", non da nessun messaggio, quindi non avvisa all'utente cosa deve fare per procedere

#### Gestione file

- (Caso non inerente alla situazione dell'utente target) Se la cartella "files\JSON" viene in qualche modo cancellato drante l'esecuzione del programma, non si può più uscire dalla sezione dell'inserimento dell'alimento da tastiera

## Conclusione

L'unico problema notevole è un tentativo di importare più volte degli alimenti da csv, per il resto riesce a gestire abbastanza bene gli errori
# Gioco di dadi... Indovina, Osperà

## In che consiste

<p>Basically, ci son 6 dadi, 2 son del giocatore (nominati dadi Osperà) e 4 del gioco in sé (nominati Dadispera)<br>
I 2 dadi verranno usati come aiuto extra, dato che qui sarà un gioco sulla fortuna

Il giocatore deciderà 2 numeri: Il 1° il numero base di un dado ed il 2° è una possibile somma... oppure un altro numero base<br>
I 4 Dadispera son da indovinare, se il giocatore ha beccato un numero base, otterrà dei punti, se becca una somma, otterrà metà dei punti in più, se
becca ambo, otterrà 3 volte i punti base<br>
I 2 dadi verranno tirati nello stesso momento dei Dadispera: se il giocatore lo vorrà, può richiedere l'aiuto dei dadi Osperà, ma il loro
il punteggio verrà diminuito (per ora pensavo di un quarto in questo caso, arrotondato per eccesso)<br>
Anche se il giocatre ha indovinato, può lo stesso richiedere l'aiuto dei dadi Osperà, tho il punteggio totale verrà dimezzato per quel turno<br>
Se c'è un doppio tra i Dadispera, il punto verrà aumentato della metà se si è indovinata la somma, raddoppiato + mezzo punto in caso si fosse indovinato il punto base<br>
Volendo, i dadi Osperà possono essere ritirati più volte, ma il giocatore deve dare dei punti per farlo (still thinking quanto esattamente... per ora sarà solo come cosa extra)<br>
Il giocatore vince se arriva ad un certo punteggio alla fine dei turni</p>

## Definizione dei requisiti

- [x] 6 variabili dadi, separati tra Osperà e Dadispera, 2 variabili per le azzardate del giocatore
- [x] calcolo delle somme dei Dadispera
- [x] confronto delle risposte del giocatore coi Dadispera
- [x] rispettare un token per rivelare i dadi Osperà
- [ ] sottrazione punti per ritiro dadi Osperà
- [x] gestione del punteggio da come il giocatore azzecca i numeri
- [x] gestione sottrazione dei punti se il giocatore richiede i dadi Osperà
- [x] gestione del caso speciale del doppio numero
- [x] scrittura dei dati in file a parte della partita in caso di inaspettato termine programma
- [x] lettura dei dati da file per ripresa della partita salvata
- [x] scrittura messaggio di errore in caso di lettura di dati di un tipo non adatto
- [x] utilizzo dei float per il calcolo del punteggio
- [x] richiesta di un rematch verso il termine del programma, in caso il giocatore volesse riprovare

## Interfaccia utente

- [x] Introduzione personalizzata, ma per mera presentazione
- [x] Regole spiegate all'inizio
- [x] Possibilmente anche per ogni rematch, ma solo su richiesta
- [x] Quando si menziona qualcosa riguardante ai dadi Osperà (o qualche buon evento), si evidenzia con un colore, stessa cosa per i Dadispera (e magari qualche cattivo evento)
- [x] Richiesta di conferma, o anceh solo forzare a premere invio, per evitare che il giocatore per sbaglio scelga la scelta non voluta
- [x] Se la partita era precariamente terminata prima della fine della manche, l'utente potrà decidere se riprendere dall'ultimo salvataggio, che avverrà ad ogni fine turno
> - [ ] (Facoltativo) Il gioco userà una frase diversa casualmente in certi momenti della partita, le frasi saranno presi da un file esterno
- [x] Il punteggio deve rimanere presente, in modo che l'utente tenga presente di quanto ha
- [ ] Ogni qualvolta, si ricorda al giocatore quanti punti necessita per effettivamente vincere

## Definizione dei file

### salvaOspera.txt

- Essendo un salvataggio per necessità, lo scopo è solo di permettere al giocatore di finire la partita se per qualche motivo la partita è crashata

- [x] Nome del giocatore della partita interrotta, quindi necessità di sapere preventivamente il nome del giocatore
- [x] Numero del turno
- [x] Punteggio totale
- [x] Boolean per sapere se la partita era in corso o meno
> - [ ] (Facoltativo) Magari una cronologia del punteggio, che duri nel tempo o solo per confrontare in un periodo di tempo breve (stessa partita)

### I csv

- Son prescritti, è necessario la loro presenza perchè contengono:

- [x] Testo
- [x] Colore
- [x] Quanti spazi a capo si aggiungeranno dopo la stampa
- [x] Alternativa: ci saranno diverse alternative in modo da rendere i commenti da parte del computer meno ripetitivi

## Possibili migliorie future

<p>Il gioco è nato col concetto di essere single-player, ma magari fare in modo da permettere di giocare con più giocatori, magari a turno:

Ogni giocatore fa la manche proprio come farebbe in singleplayer, quindi l'unica cosa che cambierebbe e dover ripetere per il numero di giocatori
Se si applica il file, magari farsì che si crei una struttura per tenere presente i dati di ogni giocatore
</p>
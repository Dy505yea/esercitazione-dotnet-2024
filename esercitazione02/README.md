# Gioco di dadi... Indovina, Osperà

## In che consiste

<p>Basically, ci son 6 dadi, 2 son del giocatore (nominati dadi Osperà) e 4 del gioco in sé (nominati dadispera)<br>
I 2 dadi verranno usati come aiuto extra, dato che qui sarà un gioco sulla fortuna

Il giocatore deciderà 2 numeri: Il 1° il numero base di un dado ed il 2° è una possibile somma... oppure un altro numero base<br>
I 4 dadi dadispera son da indovinare, se il giocatore ha beccato un numero base, otterrà dei punti, se becca una somma, otterrà metà dei punti in più, se
becca ambo, otterrà 3 volte i punti base<br>
I 2 dadi verranno tirati nello stesso momento dei dadi dadispera dadi: se il giocatore lo vorrà, può richiedere l'aiuto dei dadi Osperà, ma
il punteggio verrà diminuito (per ora pensavo di un quarto in questo caso, arrotondato per eccesso)<br>
Anche se il giocatre ha indovinato, può lo stesso richiedere l'aiuto dei dadi Osperà, tho il punteggio totale verrà dimezzato per quel turno<br>
Se c'è un doppio tra i dadi dadispera, il punto verrà aumentato della metà se si è indovinata la somma, raddoppiato + mezzo punto in caso si fosse indovinato il punto base<br>
Volendo, i dadi Osperà possono essere ritirati più volte, ma il giocatore deve dare dei punti per farlo (still thinking quanto esattamente... per ora sarà solo come cosa extra)<br>
Il giocatore vince se arriva ad un certo punteggio alla fine dei turni (per ora pensavo a 5 giocate)</p>

## Dati e Requisiti

- [x] 6 variabili dadi, separati tra Osperà e dadispera, 2 variabili per le azzardate del giocatore
- [ ] calcolo delle somme degli dadispera
- [x] confronto delle risposte del giocatore con gli dadispera
- [x] rispettare un token per rivelare i dadi Osperà
- [ ] sottrazione punti per ritiro dadi Osperà
- [x] gestione del punteggio da come il giocatore azzecca i numeri
- [x] gestione sottrazione dei punti se il giocatore richiede i dadi Osperà
- [ ] gestione del caso speciale del doppio numero
- [ ] scrittura dei dati in file a parte della partita in caso di inaspettato termine programma
- [ ] lettura dei dati da file per ripresa della partita salvata
- [x] scrittura messaggio di errore in caso di lettura di dati di un tipo non adatto
- [x] utilizzo dei float per il calcolo del punteggio
- [ ] richiesta di un rematch verso il termine del programma, in caso il giocatore volesse riprovare
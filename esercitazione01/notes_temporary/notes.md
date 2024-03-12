# PATTERN CLASSI, DATABASE  

Applica robe su entity frameork
ieri erano sulla strada

# MVC
é un pttern architetturale che separa i dati, la logica di business e l'interfaccia utente in 3 componenti distinti

- Model: rapptesenta i dati e la logica di business e l'interfaccia
- View: rappresenta l'interfaccia utente
- Controller: gestisce le interazioni tra l'utente e il modello

In uno scenario lavoratico si potreve avere un team di sciluppatori che si occupa del modello, un team che si occupa della vista e un team che si occupa del controller.

## ESEMPIO CLASSICO: app che permette di creare un darabase SQLite e di visualizzarne il contenuto

- Model: classe che rappresenta il database
- View: interfaccia grafica
- Controller: classe che gestisce le interazioni tra l'utente e il modello

comando dotnet per creare l'app


"dotnet new console -n MvcConsole"

"dotnet add package System.Data.SQLite"


### mh

di solito li si fa in 3 cartelle separate
modello
vista
controllo

sono 3 oggetti: Database, View e Controller
Modello()
View(Modello)
Controller(Modello, View)
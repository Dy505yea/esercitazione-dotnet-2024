CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE merce (id INTEGER PRIMARY KEY AUTOINCREMENT, nomeSpec TEXT UNIQUE, nomeGen TEXT, prezzo REAL, quantita INTEGER CHECK (quantita>=0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
INSERT INTO categorie VALUES (NULL, 'Aerofoni'), (NULL, 'Cordofoni'), (NULL, 'Membranofoni'), (NULL,  'Idiofoni'), (NULL, 'Miscellaneous');
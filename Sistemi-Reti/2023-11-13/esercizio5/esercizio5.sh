#!/bin/bash
#Marco Balducci

echo "________________________"
cat testo.txt                  #con cat leggo il contenuto del file testo.txt e lo mando in output
echo "________________________"

echo ""
echo -e "_________-Grep-_________"
cat testo.txt | grep "esempio" #concatenando grep a cat, cat passa a grep il contenuto del file e questo ricerca la riga che contiene "esempio" e manda in output solo quella
echo "________________________"

testo="Questa è la nuova linea da aggiungere al file."
echo "$testo" >> testo.txt     #aggiungo il contenuto di testo al file testo.txt
contenuto=$(cat testo.txt)     #leggo il contenuto di testo.txt e lo memorizzo in una variabile

echo "$contenuto" #stampo a video il contenuto della variabile
